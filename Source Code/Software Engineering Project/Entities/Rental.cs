using System;

namespace Entities
{
    public class Rental
    {
        public Vehicle Vehicle
        {
            get;
            set;
        }

        public DateTime RentalStart
        {
            get;
            set;
        }

        public CustomerTransaction CustInfo
        {
            get;
            set;
        }
    }
}
