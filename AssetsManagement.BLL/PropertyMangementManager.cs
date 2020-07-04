using System;
using System.Linq;
using AssetsManagement.DAL;
using AssetsManagement.Model;

namespace AssetsManagement.BLL
{

    public class PropertyMangementManager : IPropertyMangementManager
    {
        private readonly IPropertyManagement propertyManagement;

        public PropertyMangementManager()
        {
            propertyManagement = PropertyManagementFactory.Instance.get();
        }

        public void AddAsset(Asset asset)
        {
            if (asset == null || asset.Owner == null)
            {
                throw new ArgumentException("Null input");
            }

            if (propertyManagement.FindOwnerById(asset.Owner.Id) == null)
            {
                throw new ArgumentException("owner not found");
            }

            ValidateAddress(asset.Address);

            propertyManagement.AddAsset(asset);
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

            propertyManagement.AddCity(city);
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

            propertyManagement.AddOwner(owner);
        }

        public City FindCityByName(string name)
        {
            return propertyManagement.GetCities()
                .FirstOrDefault(c => c.Name.Equals(name));
        }

        public Owner FindOwnerById(int id)
        {
            return propertyManagement.FindOwnerById(id);
        }
    }
}
