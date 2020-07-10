using System;


namespace AssetsManagement.Model
{
    public class Address : IComparable<Address>
    {
        public string Street { get; set; }
        public City City { get; set; }
        public int HouseNumber { get; set; }

        public int CompareTo(Address other)
        {
            if (other == null)
            {
                return -1;
            }

            return other.City.Symbol.CompareTo(City.Symbol) == 0 
                && CompareStreet(other.Street) == 0 
                && other.HouseNumber.CompareTo(HouseNumber) == 0
                ? 0 : -1;
        }

        private int CompareStreet(string street)
        {
            if (street == null && Street == null) 
            {
                return 0;
            }

            if (street == null && Street != null)
            {
                return 1;
            }

            if (street != null && Street == null)
            {
                return -1;
            }

            return Street.CompareTo(street);
        }

        public override string ToString()
        {
            return $"Address: [City = {City}, Street = {Street}, " +
                $"HouseNumber: {HouseNumber}]";
        }
    }
}
