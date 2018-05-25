using System;
using System.Windows.Forms;
using Entities;

namespace Software_Engineering_Project.Forms
{
    
    public partial class ReturnLookupForm : Form
    {
        private ReturnControl controller;
        private Rental r;
        public ReturnLookupForm(ReturnControl cont)
        {
            InitializeComponent();
            controller = cont;
        }

        public void Submit()
        {
            Display(controller.getRental(this.LicenseEntry.Text));
        }

        public void Return()
        {
            controller.ReturnRental(r);
            this.Close();
        }

        public void Cancel()
        {
            controller.Cancel();
            this.Close();
        }

        public void Display(Rental r)
        {
            this.r = r;
            Make_lbl.Text += " " + r.Vehicle.Make;
            Model_lbl.Text += " " + r.Vehicle.Model;
            Year_lbl.Text += " " + r.Vehicle.Year.ToString();
            Name_lbl.Text += " " + r.CustInfo.Name;
            Date_lbl.Text += " " + r.RentalStart.ToShortDateString();
        }

        private void Return_btn_Click(object sender, EventArgs e)
        {
            Return();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Enter_btn_Click(object sender, EventArgs e)
        {
            Submit();
        }
    }
}
