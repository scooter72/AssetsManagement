using System;
using System.Linq;
using System.Collections.Generic;
using AssetsManagement.Model;

namespace AssetsManagement.DAL
{
    /// <summary>
    /// Implementation of IPropertyManagement which stores the data in
    /// memory.
    /// This class is useful for testing.
    /// </summary>
    class InMemAssetManagementDataAccess : IAssetManagementDataAccess
    {
        /// <summary>
        /// Stores cities in key->value map
        /// </summary>
        private Dictionary<int, City> cities = new Dictionary<int, City>();

        private Dictionary<int, Asset> assets = new Dictionary<int, Asset>();
        private Dictionary<int, Owner> owners = new Dictionary<int, Owner>();
        private Dictionary<int, RentalAgreement> rentalAgreements =
            new Dictionary<int, RentalAgreement>();
        private Dictionary<int, Tenant> tenants = new Dictionary<int, Tenant>();


        public int AddCity(City city)
        {
            cities[city.Symbol] = city;
            Console.WriteLine($"City '{city}' added to inventory");
            return city.Symbol;
        }

        public int AddCity(City[] cities)
        {
            foreach (var c in cities)
            {
                AddCity(c);
            }
            return cities.Length;
        }

        public int AddAsset(Asset asset)
        {
            asset.Id = assets.Count + 1;
            assets[asset.Id] = asset;
            Console.WriteLine($"Asset '{asset}' added to inventory");
            return asset.Id;
        }

        public int AddOwner(Owner owner)
        {            
            owners[owner.Id] = owner;
            Console.WriteLine($"Owner '{owner}' added to inventory");
            return owner.Id;
        }

        public int AddRentalAgreement(RentalAgreement rentalAgreement)
        {
            rentalAgreement.Id = rentalAgreements.Count + 1;
            rentalAgreements[rentalAgreement.Id] = rentalAgreement;
            return rentalAgreement.Id;
        }

        public int AddTenant(Tenant tenant)
        {
            tenants[tenant.Id] = tenant;
            return tenant.Id;
        }

        public Asset FindAssetByAddress(Address address)
        {
            return assets.Values.FirstOrDefault(a => a.Address.Equals(address));
        }

        public Owner FindOwnerById(int id)
        {
            return owners.Values.FirstOrDefault(o => o.Id == id);
        }

        public Tenant FindTenatById(int id)
        {
            return tenants.Values.FirstOrDefault(o => o.Id == id);
        }


        public RentalAgreement FindRentalAgreementtByAssetId(int id)
        {
            return rentalAgreements.Values.FirstOrDefault(o => o.AssetId == id);
        }


        public City[] GetCities()
        {
            return cities.Values.ToArray();
        }

        public Owner[] GetOwners()
        {
            return owners.Values.ToArray();
        }

        public Tenant[] GetTenants()
        {
            return tenants.Values.ToArray();
        }

        public RentalAgreement[] GetRentalAgreements()
        {
            return rentalAgreements.Values.ToArray();
        }

        public Asset[] GetAssets()
        {
            return assets.Values.ToArray();
        }

        public void DeleteAsset(int id)
        {
            var rentalAgreemnt = rentalAgreements.Values.FirstOrDefault(i => i.AssetId == id);
            
            if (rentalAgreemnt != null)
            { 
                rentalAgreements.Remove(rentalAgreemnt.Id); 
            }
            assets.Remove(id);
        }

        public void DeleteCity(int symbol)
        {
            cities.Remove(symbol);
        }
    }
}
