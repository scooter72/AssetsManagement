using System;
using System.Linq;
using AssetsManagement.DAL;
using AssetsManagement.Model;

namespace AssetsManagement.BLL
{

    public class AssetManager : IAssetManager
    {
        private readonly IAssetManagementDataAccess dataAccess;

        public AssetManager()
        {
            dataAccess = AssetManagementDataAccessFactory.Instance.GetDataAccess(AssetManagementDataAccessFactory.DataAccessType.MS_SQL);
        }

        public int AddAsset(Asset asset)
        {
            if (asset == null || asset.Owner == null)
            {
                throw new ArgumentException("Null input");
            }

            if (dataAccess.FindOwnerById(asset.Owner.Id) == null)
            {
                throw new ArgumentException("owner not found");
            }

            ValidateAddress(asset.Address);

            return dataAccess.AddAsset(asset);
        }

        private void ValidateAddress(Address address)
        {
            if (address == null)
            {
                throw new ArgumentException("address cannot be null");
            }

            ValidateCity(address.City);

            if (FindCityByName(address.City.Name) == null)
            {
                throw new ArgumentException("City not found");
            }

            if (string.IsNullOrEmpty(address.Street))
            {
                throw new ArgumentException("Street cannot be empty");
            }


            if (address.HouseNumber <= 0)
            {
                throw new ArgumentException("Invalid house number");
            }
        }

        public void AddCity(City city)
        {
            ValidateCity(city);

            dataAccess.AddCity(city);
        }

        private void ValidateCity(City city)
        {
            if (city == null)
            {
                throw new ArgumentException("Null input");
            }

            if (string.IsNullOrEmpty(city.Name))
            {
                throw new ArgumentException("City name cannot be empty");
            }

            if (city.Symbol <= 0)
            {
                throw new ArgumentException("Invalid city symbol");
            }
        }

        public void AddOwner(Owner owner)
        {
            if (owner == null)
            {
                throw new ArgumentException("Null input");
            }

            if (string.IsNullOrEmpty(owner.Name) )
            {
                throw new ArgumentException("Name cannot be empty");
            }

            if (owner.Id <= 0 )
            {
                throw new ArgumentException("Invalid id");
            }

            dataAccess.AddOwner(owner);
        }

        public City FindCityByName(string name)
        {
            return dataAccess.GetCities()
                .FirstOrDefault(c => c.Name.Equals(name));
        }

        public Owner FindOwnerById(int id)
        {
            return dataAccess.FindOwnerById(id);
        }

        public void AddTenant(Tenant tenant)
        {
            dataAccess.AddTenant(tenant);
        }

        public City[] GetCities()
        {
            return dataAccess.GetCities();
        }

        public Owner[] GetOwners()
        {
            return dataAccess.GetOwners();
        }

        public Asset[] GetAssets()
        {
           return dataAccess.GetAssets();
        }

        public Tenant[] GetTenats()
        {
            return dataAccess.GetTenants();
        }

        public void AddRentalAgreement(RentalAgreement rentalAgreement)
        {
            dataAccess.AddRentalAgreement(rentalAgreement);
        }

        public RentalAgreement FindRentalAgreement(int assetId)
        {
            return dataAccess.FindRentalAgreementtByAssetId(assetId);
        }

        public Tenant FindTenantById(int tenantId)
        {
            return dataAccess.FindTenatById(tenantId);
        }

        public RentalAgreement[] GetRentalAgreements()
        {
            return dataAccess.GetRentalAgreements();
        }

        public void DeleteAsset(int id)
        {
            dataAccess.DeleteAsset(id);
        }
    }
}
