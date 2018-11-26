using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AU_ACM_Site.Models.Mapping;

namespace AU_ACM_Site.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DefaultConnection")
        { }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("AU_ACM");

            modelBuilder.Configurations.Add(new EventMap());
        }
    }
}