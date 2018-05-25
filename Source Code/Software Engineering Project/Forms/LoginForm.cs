using System;
using System.Windows.Forms;

namespace Software_Engineering_Project.Forms
{
    public partial class LoginForm : Form
    {
        private VerifyControl controller;
        public LoginForm()
        {
            InitializeComponent();
            controller = new VerifyControl(this);
        }

        public void submit()
        {
            //submit the username and password for verification
            controller.Verify(UsernameBox.Text, PasswordBox.Text);
        }

        public void loginError(string message)
        {
            this.Error_lbl.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            submit();
        }
    }
}
