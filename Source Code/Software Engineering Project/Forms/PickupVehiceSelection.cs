using System;
using System.Windows.Forms;
using Entities;
namespace Software_Engineering_Project.Forms
{
    //Currently, a reference is required to the object isntance of the controller classes because the methods are not static
    public partial class PickupVehicleSelection : Form
    {
        private VehicleList vehicles;
        private PickupControl controller;
        public PickupVehicleSelection(VehicleList v, PickupControl c)
        {
            InitializeComponent();
            vehicles = v;
            foreach(Vehicle vehicle in vehicles.List)
                VehicleListBox.Items.Add(string.Format("{0,-30} {1,-30} {2}", vehicle.Make, vehicle.Model, vehicle.Year));
            controller = c;
        }

        public void select(Vehicle v)
        {
            label2.Text = string.Format("{0:c}", v.Price);
            label2.Visible = true;
        }

        public void select()
        {
            int index = VehicleListBox.SelectedIndex;
            if(index == -1)
            {
                //the index was changed to nothing, don't display the price anymore
                //may not be possible to occur, but it would be worth to check just in case
                label2.Visible = false;
                return;
            }
            Vehicle v = vehicles.List[index];
            select(v);
        }

        public void Next()
        {
            int index = VehicleListBox.SelectedIndex;
            if(index == -1)
            {
                //
                //Do nothing
                //
                return;
            }
            Vehicle v = vehicles.List[index];
            controller.Submit(v);
            this.Close();
        }

        public void Cancel()
        {
            controller.Cancel();
            this.Close();
        }

        private void Rent_btn_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void VehicleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            select();
        }
    }
}
