using System;


namespace AssetsManagement.Model
{
    public class Address
    {
        public string Street { get; set; }
        public City City { get; set; }
        public int HouseNumber { get; set; }

        public override string ToString()
        {
            return $"Address: [City = {City}, Street = {Street}, " +
                $"HouseNumber: {HouseNumber}]";
        }
    }
}
