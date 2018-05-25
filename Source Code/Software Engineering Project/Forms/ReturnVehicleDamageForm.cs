using System;
using System.Windows.Forms;

namespace Software_Engineering_Project.Forms
{
    public partial class ReturnVehicleDamageForm : Form
    {
        private ReturnControl controller;
        public ReturnVehicleDamageForm(string description, ReturnControl c)
        {
            InitializeComponent();
            this.Description_box.Text = description;
            controller = c;
        }

        public void Approve()
        {
            string cost = Cost_box.Text.TrimStart('$'); //remove $ at the beginning if there is one
            controller.ApproveRental(this.Description_box.Text, double.Parse(cost));
            this.Close();
        }

        private void Approve_btn_Click(object sender, EventArgs e)
        {
            Approve();
        }
    }
}
