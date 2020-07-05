using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AssetsManagement.Model;

namespace AssetsManagement.DAL
{
    public class MsSqlAssetManagementDataAccess : IAssetManagementDataAccess
    {
        private readonly string ConnectionString = "Server=.;Database=AssetsManagement;User Id=amuser;Password=Pa$$W0Rd;";

        public MsSqlAssetManagementDataAccess()
        {
        }

        public int AddAsset(Asset asset)
        {
            string sql = "BEGIN TRANSACTION;"+
                         "DECLARE @AddressID int;" +
                         "DECLARE @AssetID int;" +
                         "INSERT INTO dbo.Address (City, Street, HouseNumber) VALUES (@city, @street, @house_number);" +
                         "SELECT @AddressID = scope_identity();" +
                         "INSERT INTO Asset (Owner, Address) VALUES (@owner, @AddressID);" +
                         "SELECT scope_identity();" + 
                         "COMMIT";
            int assetId = -1;

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("@city", asset.Address.City.Symbol);
                command.Parameters.AddWithValue("@street", asset.Address.Street);
                command.Parameters.AddWithValue("@house_number", asset.Address.HouseNumber);
                command.Parameters.AddWithValue("@owner", asset.Owner.Id);

                assetId = Convert.ToInt32(command.ExecuteScalar());
            }

            return assetId;
        }

        public int AddCity(City city)
        {
            String query = "INSERT INTO City (Symbol,Name) VALUES (@symbol,@name)";

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = query;
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
            String query = "INSERT INTO Owner (id,Name) VALUES (@id,@name)";

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())

            {
                conn.Open();
                command.CommandText = query;
                command.Parameters.AddWithValue("@id", owner.Id);
                command.Parameters.AddWithValue("@name", owner.Name);

                command.ExecuteNonQuery();
            }

            return owner.Id;
        }

        public int AddRentalAgreement(RentalAgreement rentalAgreement)
        {
            throw new NotImplementedException();
        }

        public int AddTenant(Tenant tenant)
        {
            String query = "INSERT INTO Tenant (id,Name) VALUES (@id,@name)";

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = query;
                command.Parameters.AddWithValue("@id", tenant.Id);
                command.Parameters.AddWithValue("@name", tenant.Name);

                command.ExecuteNonQuery();
            }

            return tenant.Id;
        }

        public Asset FindAssetByAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public Owner FindOwnerById(int id)
        {
            Owner owner = null;
            String query = "SELECT Id,Name FROM Owner WHERE Id = @id";

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = query;
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    owner = new Owner { Id = reader.GetInt32(0), Name = reader.GetString(1) };
                }
            }

            return owner;
        }

        public RentalAgreement FindRentalAgreementtByAssetId(int id)
        {
            throw new NotImplementedException();
        }

        public Tenant FindTenatById(int id)
        {
            throw new NotImplementedException();
        }

        public Asset[] GetAssets()
        {
            throw new NotImplementedException();
        }

        public City[] GetCities()
        {
            List<City> cities = new List<City>();
            String query = "SELECT Symbol,Name FROM City";

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cities.Add(new City { Symbol = reader.GetInt32(0), Name = reader.GetString(1) });
                }
            }

            return cities.ToArray();
        }

        public Owner[] GetOwners()
        {
            List<Owner> owners = new List<Owner>();
            String query = "SELECT Id,Name FROM Owner";

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    owners.Add(new Owner { Id = reader.GetInt32(0), Name = reader.GetString(1) });
                }
            }

            return owners.ToArray();
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
