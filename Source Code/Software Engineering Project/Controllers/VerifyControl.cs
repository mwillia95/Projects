using Entities;
using Software_Engineering_Project.Forms;

namespace Software_Engineering_Project
{
    public class VerifyControl
    {
        private LoginForm loginForm;
        public void Verify(string userName, string password) //TODO: Store if a successful login occured
        {
            //username will not be case-sensitive
            userName = userName.ToLower();
            //get the account from the database with the username (UN-COMMENT WHEN DBCONNECTOR IS IMPLEMENTED
            Account account = DBConnector.getAccount(userName);
            //if the database did not return an account
            if (account == null)
            {
                loginForm.loginError("Invalid username");
                return;
            }

            if (Verify(password, account)) //if this password is valid for the account
            {
                DBConnector.StoreLogin(account); //store successful login
                //decide which homepage to open
                if (account.Role == "Technician")
                {
                    HomepageTech form = new HomepageTech(account);
                    form.Show();
                }
                else
                {
                    HomepageAgent form = new HomepageAgent(account);
                    form.Show();
                }
                loginForm.Close();
                
            }
            else //invalid password
            {
                loginForm.loginError("Invalid password");
            }
        }

        public bool Verify(string password, Account account)
        {
            return account.ValidPass(password);
        }

        public VerifyControl(LoginForm l)
        {
            loginForm = l;
        }
    }
}
