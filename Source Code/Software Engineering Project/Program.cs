using System;
using System.Windows.Forms;
using Software_Engineering_Project.Forms;
namespace Software_Engineering_Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DBConnector.AddStuff();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm form = new LoginForm();
            form.Show();
            Application.Run();
        }
    }
}