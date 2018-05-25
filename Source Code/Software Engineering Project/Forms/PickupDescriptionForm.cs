using System;
using System.Windows.Forms;
using Entities;
namespace Software_Engineering_Project.Forms
{
    public partial class PickupDescriptionForm : Form
    {
        private PickupControl controller;
        public PickupDescriptionForm(Vehicle v, PickupControl c)
        {
            InitializeComponent();
            Make_label.Text += " " + v.Make;
            Model_label.Text += " " + v.Model;
            Year_label.Text += " " + v.Year;
            License_label.Text += " " + v.LicenseNum;
            //
            //This might not format the lines correctly
            //
            DescriptionBox.Text = v.Description;

            controller = c;
        }

        public void Approve()
        {
            controller.ApproveSelection();
            this.Close();
        }

        private void Approve_btn_Click(object sender, EventArgs e)
        {
            Approve();
        }
    }
}
