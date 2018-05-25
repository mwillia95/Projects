using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Entities;

namespace Software_Engineering_Project
{
    //TODO: HAVE ALL METHODS SANITIZE USER INPUT
    class DBConnector
    {
      
        private static string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mitchell\Source\Repos\csci4711\Project Solution\Software Engineering Project\Software Engineering Project\Database.mdf;Integrated Security = True";
        public static Account getAccount(string uName) //CLEANED
        {
            string command = "SELECT uName, passHash, role FROM Account WHERE uName = @uName";
            SqlCommand cmd = new SqlCommand(command);
            cmd.Parameters.Add("@uName", SqlDbType.VarChar, 50);
            cmd.Parameters["@uName"].Value = uName;
            object[] items = SafeQuery(cmd);
            if (items == null)
                return null;
            return new Account((string)items[0], (int)items[1], (string)items[2]);
        }

        //get a VehicleList object containing all vehicles available to be rented
        public static VehicleList getVehicleList()
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            //select the relevant vehicle information for every vehicle that does not appear in the rental table
            //HOPE THIS WORKS
            cmd.CommandText = "SELECT v.licenseNum, v.make, v.model, v.year, v.description, v.price FROM Vehicle as v LEFT JOIN Rental as r ON r.vehicleID = v.vehicleID WHERE r.vehicleID IS NULL;";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            VehicleList vList = new VehicleList();
            vList.List = new List<Vehicle>();
            while (reader.Read())
            {
                object[] items = new object[reader.FieldCount];
                reader.GetValues(items);
                Vehicle v = new Vehicle((string)items[0], (string)items[1], (string)items[2], (int)items[3], (string)items[4], (double)(decimal)items[5]);
                vList.List.Add(v);
            }


            conn.Close();
            return vList;

        }

        private static object[] Query(string command)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = command;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            conn.Open();
            reader = cmd.ExecuteReader();

            if (!reader.Read()) //there was nothing to read, don't return anything
            {
                conn.Close();
                return null;

            }
           
            else
            {
                object[] items = new object[reader.FieldCount];
                reader.GetValues(items);
                conn.Close();
                return items;
            }
        }

        private static object[] SafeQuery(SqlCommand cmd)
        {
            
            SqlConnection conn = new SqlConnection(connection);
            SqlDataReader reader;

            cmd.Connection = conn;
            conn.Open();
            reader = cmd.ExecuteReader();

            if (!reader.Read()) //there was nothing to read, don't return anything
            {
                conn.Close();
                return null;

            }

            else
            {
                object[] items = new object[reader.FieldCount];
                reader.GetValues(items);
                conn.Close();
                return items;
            }
        }

        public static Rental getRental(string License)
        {
            //retrieve the relevant rental rows that match the license
            
            string command = "SELECT r.rentalID, r.rentalDate, r.transID, r.vehicleID FROM Rental as r, Vehicle as v WHERE v.vehicleID = r.vehicleID AND v.licenseNum = @License";
            SqlCommand cmd = new SqlCommand(command);
            cmd.Parameters.Add("@License", SqlDbType.VarChar, 50);
            cmd.Parameters["@License"].Value = License;
            object[] items = SafeQuery(cmd);

            Rental r = new Rental();
            r.RentalStart = (DateTime)items[1];

            int transID = (int)items[2];
            int vehID = (int)items[3];

            //retrieve the vehicle object from the given vehicleID
            command = "SELECT * FROM Vehicle WHERE vehicleID = " + vehID;
            items = Query(command);
            Vehicle v = new Vehicle((string)items[1], (string)items[2], (string)items[3], (int)items[4], (string)items[5], (double)(decimal)items[6]);
            r.Vehicle = v;

            //retrieve the customerTransaction object with given transID

            command = "SELECT * FROM CustTrans WHERE transID = " + transID;
            items = Query(command);

            CustomerTransaction c = new CustomerTransaction();
            c.Name = (string)items[1] + " " + (string)items[2];
            c.Address = (string)items[3];
            c.PhoneNumber = (string)items[4];
            c.InsuranceNumber = (string)items[5];

            CreditCard cc = new CreditCard();
            cc.CardNumber = (string)items[6];

            //retrieve the CreditCard object with given card number

            command = "SELECT * FROM CreditCard WHERE cardNo = '" + cc.CardNumber + "'";
            items = Query(command);

            cc.ExpMonth = (int)items[1];
            cc.ExpYear = (int)items[2];
            cc.CVV = (int)items[3];
            c.Card = cc;
            r.CustInfo = c;

            return r;
        }
        
        //rental is being returned, remove the rental from the DB
        public static void ReturnRental(Rental r)
        {
            //find which vehicle has the license stored in the rental object

            string command = "SELECT vehicleID FROM Vehicle WHERE licenseNum = '" + r.Vehicle.LicenseNum + "'";
            object[] items = Query(command);
            int vehID = (int)items[0];

            //delete the entry in the Rental table that has this vehicleID

            command = "DELETE FROM Rental WHERE vehicleID = " + vehID;
            Query(command);
        }

        //overloaded, for use when a rental has been damaged
        public static void ReturnRental(Rental r, string report, double cost)
        {
            //find which vehicle has the license stored in the rental object
            string command = "SELECT vehicleID FROM Vehicle WHERE licenseNum = '" + r.Vehicle.LicenseNum + "'";
            object[] items = Query(command);
            int vehID = (int)items[0];

            //delete the entry in the Rental table that has this vehicle ID
            command = "DELETE FROM Rental WHERE vehicleID = " + vehID;
            Query(command);

            //update the entry in the Vehicle table to reflect the new report
            command = "UPDATE Vehicle SET description = @report WHERE vehicleID = " + vehID;
            SqlCommand cmd = new SqlCommand(command);
            cmd.Parameters.Add("@report", SqlDbType.VarChar, 300);
            cmd.Parameters["@report"].Value = report;
            SafeQuery(cmd);
        }

        //rental is being made, store in DB
        public static void StoreRental(Rental r)
        {
            //find the vehicleID of the license

            string command = "SELECT vehicleID from Vehicle WHERE licenseNum = '" + r.Vehicle.LicenseNum + "'"; 
            object[] items = Query(command);

            int vehID = (int)items[0];
            CustomerTransaction i = r.CustInfo;
            CreditCard card = i.Card;

           
            //string ccValues = card.CardNumber + "," + card.ExpMonth + "," + card.ExpYear + "," + card.CVV;
            command = "SELECT COUNT(*) FROM CreditCard WHERE cardNo = @num";
            SqlCommand cmd = new SqlCommand(command);
            cmd.Parameters.Add("@num", SqlDbType.VarChar, 50);
            cmd.Parameters["@num"].Value = card.CardNumber;
            items = SafeQuery(cmd);
            int count = (int)items[0];
            if (count == 0) //for now, check to make sure the cc isn't already in there, if it is, skip this step
            {
                //create the card entry
                command = "INSERT INTO CreditCard VALUES(@num, @month, @year, @cvv);";
                cmd = new SqlCommand(command);
                cmd.Parameters.Add("@num", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@month", SqlDbType.Int);
                cmd.Parameters.Add("@year", SqlDbType.Int);
                cmd.Parameters.Add("@cvv", SqlDbType.Int);

                cmd.Parameters["@num"].Value = card.CardNumber;
                cmd.Parameters["@month"].Value = card.ExpMonth;
                cmd.Parameters["@year"].Value = card.ExpYear;
                cmd.Parameters["@cvv"].Value = card.CVV;
                SafeQuery(cmd);
            }



            //use the max + 1 transID for the new transID
            command = "SELECT COALESCE(MAX(transID), 0) FROM CustTrans";
            items = Query(command);
            int transID;
            transID = ((int)items[0]) + 1;

            //create the customertransaction entry

            string values = string.Format("{0}, @fName, @lName, @address, @phone, @insurance, @cardNum", transID);
            command = "INSERT INTO CustTrans VALUES(" + values + ");";
            cmd = new SqlCommand(command);
            cmd.Parameters.Add("@fName", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@lName", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@address", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@phone", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@insurance", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@cardNum", SqlDbType.VarChar, 50);

            cmd.Parameters["@fName"].Value = i.Name.Split(' ')[0];
            cmd.Parameters["@lName"].Value = i.Name.Split(' ')[1];
            cmd.Parameters["@address"].Value = i.Address;
            cmd.Parameters["@phone"].Value = i.PhoneNumber;
            cmd.Parameters["@insurance"].Value = i.InsuranceNumber;
            cmd.Parameters["@cardNum"].Value = i.Card.CardNumber;

            SafeQuery(cmd);

            //find the max rentalID, use that + 1
            int rentalID;
            //COALESCE will return second argument if first argument is null (returns 0 if the table is empty)
            command = "SELECT COALESCE(MAX(rentalID), 0) FROM Rental";
            items = Query(command);
            rentalID = (int)items[0] + 1;

            //create the rental entry
            values = string.Format("{0}, '{1}', {2}, {3}", rentalID, DateTime.Today.ToString(), transID, vehID);
            command = "INSERT INTO Rental VALUES(" + values + ");";
            Query(command);

            //done!
        }

        public static void StoreLogout(Account a)
        {
            //find the max ID from account_logout, then add one
            int id;
            string command = "SELECT COALESCE(MAX(id), 0) FROM account_logout";
            object[] items = Query(command);
            id = (int)items[0] + 1;

            //find the ID of the account
            int accID;
            command = "SELECT AccountID FROM Account WHERE uName = '" + a.Username + "'";
            items = Query(command);
            accID = (int)items[0];

            //add an entry to the account_logout table
            string values = string.Format("{0}, '{1}', {2}", id, DateTime.Now.ToString(), accID);
            command = "INSERT INTO account_logout VALUES(" + values + ");";
            Query(command);

            //done!

        }

        public static void StoreLogin(Account a)
        {
            //find the max ID from account_logout, then add one
            int id;
            string command = "SELECT COALESCE(MAX(id), 0) FROM account_login";
            object[] items = Query(command);
            id = (int)items[0] + 1;

            //find the ID of the account
            int accID;
            command = "SELECT AccountID FROM Account WHERE uName = '" + a.Username + "'";
            items = Query(command);
            accID = (int)items[0];

            //add an entry to the account_logout table
            string values = string.Format("{0}, '{1}', {2}", id, DateTime.Now.ToString(), accID);
            command = "INSERT INTO account_login VALUES(" + values + ");";
            Query(command);
        }
    }
}
