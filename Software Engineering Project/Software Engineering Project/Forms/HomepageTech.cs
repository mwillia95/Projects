using System;
using System.Windows.Forms;
using Entities;
namespace Software_Engineering_Project.Forms
{
    public partial class HomepageTech : Form
    {
        private Account account;
        private ReturnControl controller;
        public HomepageTech(Account account)
        {
            InitializeComponent();
            this.account = account;
            controller = new ReturnControl(account);
        }

        public void Rental()
        {
            controller.Return();
            this.Close();
        }

        public void Logout()
        {
            UserControl logController = new UserControl(account, this);
            logController.TryLogout();
        }

        private void Return_btn_Click(object sender, EventArgs e)
        {
            Rental();
        }

        private void Logout_btn_Click(object sender, EventArgs e)
        {
            Logout();
        }
    }
}
