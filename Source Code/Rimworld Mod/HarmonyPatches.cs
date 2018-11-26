using System;
using System.Collections;
using System.Collections.Generic;
using Harmony;
using RimWorld;
using Verse;
using System.Reflection;
namespace LazyStockpiles
{
    
    /// <summary>
    /// Various methods and classes that utilize Harmony library to inject code after specific methods run/before they start
    /// The goal of these methods is to implement the Cache/Buffer behavior to hauling jobs, which includes
    /// 
    /// Cache: A cache functions similar to a crafting job's "Until you have X" condition.
    /// If a stockpile is a cache, the entire stockpile has a single stack threshold, for example, 33%.
    /// If a cell within the stockpile has a stack of items, and that stack meets or exceeds that threshold,
    ///     that specific cell will no longer accept hauling jobs to it.
    /// A cache is useful as a high priority stockpile that supplies a nearby crafting station.
    /// 
    /// Buffer: A buffer is intended to store recently created products nearby until a full (or near full) stack can be hauled to another, more distant stockpile.
    /// If a stockpils is a buffer, the entire stockpile has a single stack threshold, for example, 75%.
    /// If a cell within the stockpile has a stack of items, and that stack meets or exceeds that threshold,
    ///     that specific cell will attempt to force the stack out of the stockpile entirely.
    ///     This includes hauling the stack to a lower priority stockpile.
    /// Additionally, a buffer will never accept items that are coming from another stockpile
    /// 
    /// </summary>
    public static class ThingExtension
    {
        public static float Ratio(this Thing t)
        {
            if(t.def.IsApparel || t.def.IsWeapon)
            {
                return 1f;
            }
            return (float)t.stackCount / (float)t.def.stackLimit;
        }
    }

    [HarmonyPatch(typeof(ZoneManager), "RebuildZoneGrid")]
    public static class RebuildZoneGrid_Patch
    {
        [HarmonyPostfix]
        public static void Convert_Old_Stockpiles_To_Lazy(ZoneManager __instance, Zone[] ___zoneGrid)
        {
            Zone[] zoneGrid = ___zoneGrid;
            ZoneManager manager = __instance;
            Map map = manager.map;
            CellIndices cellIndices = manager.map.cellIndices;
            List<Zone> zones = manager.AllZones;
            List<Zone_Stockpile> deregister = new List<Zone_Stockpile>();
            List<Lazy_Stockpile> register = new List<Lazy_Stockpile>();


            for (int i = 0; i < zones.Count; i++)
            {
                Zone z = zones[i];
                if (z as Zone_Stockpile != null && z as Lazy_Stockpile == null)
                {
                    Lazy_Stockpile tmp = new Lazy_Stockpile(z as Zone_Stockpile);
                    manager.AllZones.Remove(z);
                    manager.AllZones.Add(tmp);
                    foreach (IntVec3 c in tmp)
                        zoneGrid[cellIndices.CellToIndex(c)] = tmp;
                    //deregister.Add(z as Zone_Stockpile);
                    //register.Add(tmp);
                    Log.Message($"The stockpile {z.label} has been converted to a lazy stockpile");
                }
            }

        }
    }

    [HarmonyPatch(typeof(Designator_ZoneAddStockpile))]
    public static class Designator_ZoneAddStockpile_Constructor_Patch
    {
        [HarmonyPostfix]
        public static void Override_zoneTypeToPlace(Designator_ZoneAddStockpile __instance, ref Type ___zoneTypeToPlace)//, ref Type ___zoneTypeToPlace)
        {
            ___zoneTypeToPlace = typeof(Lazy_Stockpile);
        }
    }


    //Override the standard stockpile created and replace it with a lazy stockpile (with same variables)
    [HarmonyPatch(typeof(Designator_ZoneAddStockpile), "MakeNewZone")]
    public static class ConvertAllToLazy
    {
        [HarmonyPostfix]
        public static void MakeNewZone(ref Zone __result)
        {
            __result = new Lazy_Stockpile(__result as Zone_Stockpile);
        }
    }


    [HarmonyPatch(typeof(StoreUtility), "NoStorageBlockersIn")]
    public static class NoStorageBlockersIn_LazyPatch
    {
        //Consider a cache cell to be blocked if the stack size already in the cell is greater than 33% (or threshold)
        //Consider a buffer cell to be blocked if thing is already stored within the same stockpile
        [HarmonyPostfix]
        private static void NoStorageBlockersIn_Lazy_PostFix(IntVec3 c, Map map, Thing thing, ref bool __result)
        {
            Zone_Stockpile generic = map.zoneManager.ZoneAt(c) as Zone_Stockpile;
            if (__result && generic != null && generic as Lazy_Stockpile != null)
            {
                LazySettings stockPile = generic.settings as LazySettings;
                if (stockPile == null)
                {
                    //Log.Error("The stockpile settings are not Lazy. Will not utilize lazy settings at all.");
                    return;
                }
                if (stockPile.type == LazyType.Cache)
                {
                    List<Thing> list = map.thingGrid.ThingsListAt(c);
                    for (int i = 0; i < list.Count; i++)
                    {
                        Thing potentialBlocker = list[i];
                        if (potentialBlocker.def.EverStorable(false) && potentialBlocker.Ratio() > stockPile.CacheThreshold)
                        {
                            __result = false;
                            return;
                        }
                    }
                }
                else if (stockPile.type == LazyType.Buffer)
                {
                    //if the thing we are trying to place is trying to go into the same stockpile that it is already in, and the stockpile is a lazy buffer, do not let it place itself back in
                    //this should only be reached because the buffer is trying to get rid of the stack (greater than the threshold)
                    LazySettings thingStock = thing.GetSlotGroup()?.Settings as LazySettings;
                    __result = stockPile != thingStock;
                }
            }
        }
    }


    //Consider a thing to be not be in a valid (and best) storage if its ratio >= 75% and it is stored in a lazy buffer
    //To force haul checks on that item
    [HarmonyPatch(typeof(StoreUtility), "IsInValidBestStorage")]
    public static class IsInValidBestStorage_BufferPatch
    {
        [HarmonyPostfix]
        public static void IsInValidBestStorage(Thing t, ref bool __result)
        {

            if (__result) //to prevent uneccessary work
            {
                StorageSettings test = t.GetSlotGroup()?.Settings;
                if(test != null)
                {
                    LazySettings settings = test as LazySettings;
                    if(settings != null)
                    {
                        __result = !(settings.type == LazyType.Buffer && t.Ratio() >= settings.BufferThreshold);
                    }
                }
    
            }
        }
    }

    //modify whether a storage is allowed to accept an item
    //If the storage target is a buffer
    //Do not allow the item if it is coming from a different storage
    [HarmonyPatch(typeof(StorageSettings), "AllowedToAccept", new Type[] {typeof(Thing) })]
    public static class AllowedToAccept_BufferPatch
    {
        [HarmonyPostfix]
        public static void AllowedToAccept_Postfix(ref bool __result, ref StorageSettings __instance, Thing t)
        {
            if (__result)
            {
                LazySettings target = __instance as LazySettings;

                if (target?.type == LazyType.Buffer)
                {
                   
                    SlotGroup sourceGroup = t.GetSlotGroup();
                    if (sourceGroup == null)
                        return;
                    //if the item is targetting its own buffer and ratio is too high, IsInValidBestStorage harmony patch will take care of it
                    __result = sourceGroup.Settings == target;
                }
            }

        }
    }

    [HarmonyPatch(typeof(StoreUtility), "TryFindBestBetterStoreCellFor")]
    public static class TryFindBestBetterStoreCellFor_BufferPatch
    {
        //If a thing is stored within a lazy buffer, and the ratio of the thing is >= 75%, consider it to not have been stored at all(Unstored)
        [HarmonyPrefix]
        public static void TryFindBestBetterStoreCellFor_Prefix(Thing t, ref StoragePriority currentPriority)
        {
            LazySettings l = t.GetSlotGroup()?.Settings as LazySettings;
            if (l != null)
            {
                if (l.type == LazyType.Buffer)
                {
                    if (t.Ratio() >= l.BufferThreshold)
                        currentPriority = StoragePriority.Unstored; //Have the method consider the thing to not be stored at all
                }
            }
        }
    }
}


/*
 * A critical buffer has a 100% stack. The stack is taken to another normal stockpile, and is merged with a stack. 
 * The remaining stack is 60%.
 * Because the buffer is critical, the remaining 60% is taken back to the buffer.
 * 
 * 
 * 
 * 
 * 
 * 
 */



