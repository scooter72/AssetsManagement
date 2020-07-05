using System;
using AssetsManagement.Model;

namespace AssetsManagement.DAL
{
    public interface IAssetManagementDataAccess
    {
        int AddRentalAgreement(RentalAgreement rentalAgreement);
        int AddAsset(Asset asset);
        int AddOwner(Owner owner);
        int AddTenant(Tenant tenant);
        int AddCity(City city);
        int AddCity(City[] cities);
        City[] GetCities();
        Owner[] GetOwners();
        Tenant[] GetTenants();
        RentalAgreement[] GetRentalAgreement();
        Asset FindAssetByAddress(Address address);
        Owner FindOwnerById(int id);
        Tenant FindTenatById(int id);
        RentalAgreement FindRentalAgreementtByAssetId(int id);
        Asset[] GetAssets();
    }
}
