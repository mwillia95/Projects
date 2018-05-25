namespace Entities
{
    public class Account
    {
        //considering changing to use MD5/SHA-256 hash
        private int mPasswordHash; //read-only, set once at the constructor
        public string Username;
        public string Role; //will always either be "Technician" or "Rental Agent"
        public bool ValidPass(string pass) //public check if a password is valid for a given account
        {
            //simple built-in hash function
            return pass.GetHashCode() == mPasswordHash;
        }

        public Account(string username, int passHash, string role)
        {
            Username = username;
            mPasswordHash = passHash; //only time password hash can be set
            Role = role;
        }

    }
}
