using System;
using System.Windows.Forms;
using Entities;
namespace Software_Engineering_Project.Forms
{
    public partial class ReturnDescriptionForm : Form
    {
        private Rental rental;
        private ReturnControl controller;
        public ReturnDescriptionForm(Rental r, ReturnControl cont)
        {
            InitializeComponent();
            rental = r;
            controller = cont;
            this.Description_box.Text = rental.Vehicle.Description;
        }

        public void Approve()
        {
            controller.ApproveRental();
            this.Close();
        }

        public void Report()
        {
            controller.Report();
            this.Close();
        }

        private void Approve_btn_Click(object sender, EventArgs e)
        {
            Approve();
        }

        private void Report_btn_Click(object sender, EventArgs e)
        {
            Report();
        }
    }
}
