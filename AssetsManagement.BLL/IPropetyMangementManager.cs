﻿using System;
using AssetsManagement.Model;

namespace AssetsManagement.BLL
{
    public interface IPropertyMangementManager
    {
        void AddAsset(Asset asset);
        void AddCity(City city);
        void AddOwner(Owner owner);
        Owner FindOwnerById(int id);
        City FindCityByName(string name);
    }
}
