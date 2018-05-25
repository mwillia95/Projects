namespace Entities
{
    public class Vehicle
    {
        public string LicenseNum;
        public string Make;
        public string Model;
        public int Year;
        public string Description; //description of vehicles current condition
        public double Price; //price per day to rent the vehicle

        public Vehicle(string l, string ma, string mo, int y, string d, double p)
        {
            LicenseNum = l;
            Make = ma;
            Model = mo;
            Year = y;
            Description = d;
            Price = p;
        }
    }
}
