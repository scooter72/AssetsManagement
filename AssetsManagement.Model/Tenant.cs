using System;
namespace AssetsManagement.Model
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
