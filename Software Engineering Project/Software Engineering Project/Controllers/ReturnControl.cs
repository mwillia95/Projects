using Entities;
using Software_Engineering_Project.Forms;

namespace Software_Engineering_Project
{
    public class ReturnControl
    {
        private Account account;
        private Rental rental; //for use once the rental being returned has already been decided
        public void Return()
        {
            ReturnLookupForm f = new ReturnLookupForm(this);
            f.Show();
        }

        public Rental getRental(string LicenseNum)
        {
            return DBConnector.getRental(LicenseNum);
        }

        public void ReturnRental(Rental rental)
        {
            this.rental = rental;
            ReturnDescriptionForm f = new ReturnDescriptionForm(rental, this);
            f.Show();
        }

        public void Report() //report damage
        {
            ReturnVehicleDamageForm f = new ReturnVehicleDamageForm(this.rental.Vehicle.Description, this);
            f.Show();
        }

        public void ApproveRental()
        {
            DBConnector.ReturnRental(rental);
            HomepageTech f = new HomepageTech(account);
            f.Show();
        }

        public void ApproveRental(string Damage, double Cost)
        {
            DBConnector.ReturnRental(rental, Damage, Cost);
            HomepageTech f = new HomepageTech(account);
            f.Show();
        }

        public void Cancel()
        {
            HomepageTech f = new HomepageTech(account);
            f.Show();
        }

        public ReturnControl(Account a)
        {
            account = a;
        }
    }
}

