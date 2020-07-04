using System;
using System.Data.SqlClient;
using AssetsManagement.Model;

namespace AssetsManagement.DAL
{
    public class MsSqlAssetManagementDataAccess : IAssetManagementDataAccess
    {
        private readonly string ConnectionString;

        public MsSqlAssetManagementDataAccess()
        {
        }

        public int AddAsset(Asset asset)
        {
            throw new NotImplementedException();
        }

        public int AddCity(City city)
        {

            String query = "INSERT INTO dbo.City (Symbol,Name) VALUES (@symbol,@name)";

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@symbol", city.Symbol);
                command.Parameters.AddWithValue("@name", city.Name);

                command.ExecuteNonQuery();
            }
            return city.Symbol;
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
