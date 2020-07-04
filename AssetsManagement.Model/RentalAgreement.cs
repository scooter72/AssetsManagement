using System;
namespace AssetsManagement.Model
{
    public class RentalAgreement
    {
        public RentalAgreement()
        {
        }

        public int Id { get; set; }
        public int AssetId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Tenant { get; set; }
        public int Owner { get; set; }
    }
}
