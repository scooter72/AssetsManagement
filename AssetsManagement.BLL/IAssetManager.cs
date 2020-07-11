using System;
using AssetsManagement.Model;

namespace AssetsManagement.BLL
{
    public interface IAssetManager
    {
        int AddAsset(Asset asset);
        void AddCity(City city);
        void AddOwner(Owner owner);
        Owner FindOwnerById(int id);
        City FindCityByName(string name);
        void AddTenant(Tenant tenant);
        City[] GetCities();
        
        Asset[] GetAssets();

        Owner[] GetOwners();
        Tenant[] GetTenats();
        void AddRentalAgreement(RentalAgreement rentalAgreement);
        RentalAgreement FindRentalAgreement(int assetId);
        Tenant FindTenantById(int tenant);
        RentalAgreement[] GetRentalAgreements();
        void DeleteAsset(int id);
        void DeleteCity(int symbol);
    }
}
