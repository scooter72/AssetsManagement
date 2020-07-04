using System;
using AssetsManagement.Model;

namespace AssetsManagement.DAL
{
    public class SqlPropertyManagementDataAccess : IPropertyManagement
    {
        public SqlPropertyManagementDataAccess()
        {
        }

        public int AddAsset(Asset asset)
        {
            throw new NotImplementedException();
        }

        public int AddCity(City city)
        {
            throw new NotImplementedException();
        }

        public int AddCity(City[] cities)
        {
            throw new NotImplementedException();
        }

        public int AddOwner(Owner owner)
        {
            throw new NotImplementedException();
        }

        public int AddRentalAgreement(RentalAgreement rentalAgreement)
        {
            throw new NotImplementedException();
        }

        public int AddTenant(Tenant tenant)
        {
            throw new NotImplementedException();
        }

        public Asset FindAssetByAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public Owner FindOwnerById(int id)
        {
            throw new NotImplementedException();
        }

        public RentalAgreement FindRentalAgreementtByAssetId(int id)
        {
            throw new NotImplementedException();
        }

        public Tenant FindTenatById(int id)
        {
            throw new NotImplementedException();
        }

        public City[] GetCities()
        {
            throw new NotImplementedException();
        }

        public Owner[] GetOwners()
        {
            throw new NotImplementedException();
        }

        public RentalAgreement[] GetRentalAgreement()
        {
            throw new NotImplementedException();
        }

        public Tenant[] GetTenants()
        {
            throw new NotImplementedException();
        }
    }
}
