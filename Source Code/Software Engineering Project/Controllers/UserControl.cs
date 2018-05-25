using System;
using System.Windows.Forms;
using Entities;
using Software_Engineering_Project.Forms;

namespace Software_Engineering_Project
{
    public class UserControl
    {
        private Form homepage;
        private Account account;
        public void TryLogout() //open the message box
        {
            string text = "Are you sure you want to logoff?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(text, "Logout", buttons);
            if (result == DialogResult.Yes)
                Logout();
            //else do nothing
        }

        public void Logout()
        {
            DBConnector.StoreLogout(account);

            Form login = new LoginForm();
            login.Show();
            homepage.Hide();
        }

        public UserControl(Account a, Form page)
        {
            account = a;
            homepage = page;
        }
    }
}
