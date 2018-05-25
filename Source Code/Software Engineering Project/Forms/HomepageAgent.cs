using System;
using System.Windows.Forms;
using Entities;
namespace Software_Engineering_Project.Forms
{
    public partial class HomepageAgent : Form
    {
        private PickupControl controller;
        private Account account;

        public HomepageAgent(Account account)
        {
            InitializeComponent();
            controller = new PickupControl(account);
            this.account = account;
        }

        public void StartRental()
        {
            controller.StartRental();
            this.Close();
        }

        public void Logout()
        {
            UserControl logController = new UserControl(this.account, this);
            logController.TryLogout();
        }

        private void button1_Click(object sender, EventArgs e) //rental button
        {
            StartRental();
        }

        private void button2_Click(object sender, EventArgs e) //logout button
        {
            Logout();
        }
    }
}
