using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entities;
using Software_Engineering_Project.Forms;
namespace Software_Engineering_Project
{
    public class PickupControl
    {
        private Vehicle mVehicle;
        private Account account;

        public PickupControl(Account a)
        {
            account = a;
        }

        public void StartRental()
        {
            VehicleList vehicles = DBConnector.getVehicleList();
            Form selectionForm = new PickupVehicleSelection(vehicles, this);
            selectionForm.Show();
            //let the homepage close itself
        }

        public void Submit(Vehicle vehicle)
        {
            mVehicle = vehicle;
            Form f = new PickupDescriptionForm(vehicle, this);
            f.Show();
        }

        public  void ApproveSelection()
        {
            Form f = new PickupCustomerInfoForm(this);
            f.Show();
        }

        public void Submit(string name, string cc, string address, string exp, string cvv, string city, string state, string zip, string phone, string insurance)
        {
            CreditCard card = new CreditCard();
            card.CardNumber = cc;
            card.CVV = int.Parse(cvv);
            card.ExpMonth = int.Parse(exp.Substring(0, 2)); //1st and 2nd character
            card.ExpYear = int.Parse(exp.Substring(3, 2)); //3rd and 4th character

            CustomerTransaction trans = new CustomerTransaction();
            trans.Address = address;
            trans.Card = card;
            trans.InsuranceNumber = insurance;
            trans.Name = name;
            trans.PhoneNumber = phone;

            Rental r = new Rental();
            r.CustInfo = trans;
            r.Vehicle = mVehicle;
            r.RentalStart = DateTime.Today;

            DBConnector.StoreRental(r);

            Form f = new HomepageAgent(account);
            f.Show();
        }

        public  void Cancel()
        {
            Form f = new HomepageAgent(account);
            f.Show();
        }
    }
}
