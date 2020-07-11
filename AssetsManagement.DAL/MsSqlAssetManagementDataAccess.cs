using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Threading;
using AssetsManagement.Model;

namespace AssetsManagement.DAL
{
    public class MsSqlAssetManagementDataAccess : IAssetManagementDataAccess
    {
        private readonly string ConnectionString;

        public MsSqlAssetManagementDataAccess()
        {
            ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
            
            if (string.IsNullOrEmpty(ConnectionString)) 
            {
                throw new Exception("Database sonnection string is not defined");
            }

            using (var conn = new SqlConnection(ConnectionString)) 
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error openning connection to database {ex.Message}", ex);
                }
            }
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
            String query = "INSERT INTO RentalAgreement (Asset,Tenant,StartDate,EndDate) VALUES (@asset,@tenant,@start,@end);" +
                           "SELECT scope_identity();";
            int id;

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = query;
                command.Parameters.AddWithValue("@asset", rentalAgreement.AssetId);
                command.Parameters.AddWithValue("@tenant", rentalAgreement.Tenant);
                command.Parameters.AddWithValue("@start", rentalAgreement.Start);
                command.Parameters.AddWithValue("@end", rentalAgreement.End);

                id = Convert.ToInt32(command.ExecuteScalar());
            }

            return id;
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

        public void DeleteAsset(int id)
        {
            String query = "DELETE Asset WHERE Id = @id";

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = query;
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCity(int symbol)
        {
            String query = "DELETE City WHERE Symbol = @symbol";
            
            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = query;
                command.Parameters.AddWithValue("@symbol", symbol);
                command.ExecuteNonQuery();
            }
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
            RentalAgreement rentalAgreement = null;
            String query = "SELECT Id,Asset,Tenant,StartDate,EndDate FROM RentalAgreement WHERE Asset = @id";

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = query;
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    rentalAgreement = new RentalAgreement { 
                        Id = reader.GetInt32(0), 
                        AssetId = reader.GetInt32(1),
                        Tenant  = reader.GetInt32(2),
                        Start  = reader.GetDateTime(3),
                        End  = reader.GetDateTime(4),
                    };
                }
            }

            return rentalAgreement;
        }

        public Tenant FindTenatById(int id)
        {
            Tenant tenant = null;
            String query = "SELECT Id,Name FROM Tenant WHERE Id = @id";

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = query;
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    tenant = new Tenant { Id = reader.GetInt32(0), Name = reader.GetString(1) };
                }
            }

            return tenant;
        }

        public Asset[] GetAssets()
        {
            string sql = "SELECT [Asset].[Id], [Owner].[Id], [Owner].[Name], [City].[Symbol], [City].[Name], " +
                         "[Address].[Street], [Address].[HouseNumber]" +
                         "FROM [Asset]" +
                         "INNER JOIN [Owner] on [Asset].[Owner] = [Owner].[Id]" +
                         "INNER JOIN [Address] on [Asset].[Address] = [Address].[Id]" +
                         "INNER JOIN [City] on [Address].[City] = [City].[Symbol]";
            List<Asset> assets = new List<Asset>();

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = sql;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assets.Add(
                        new Asset
                        {
                            Id = reader.GetInt32(0),
                            Owner = new Owner { Id = reader.GetInt32(1), Name = reader.GetString(2) },
                            Address = new Address
                            {
                                City = new City { Symbol = reader.GetInt32(3), Name = reader.GetString(4) },
                                Street = reader.GetString(5),
                                HouseNumber = reader.GetInt32(6)
                            }
                        }
                    );
                }
            }

            return assets.ToArray();
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

        public RentalAgreement[] GetRentalAgreements()
        {
            List<RentalAgreement> rentalAgreements = new List<RentalAgreement>();
            String query = "SELECT Id,Asset,Tenant,StartDate,EndDate FROM RentalAgreement";

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    rentalAgreements.Add(
                        new RentalAgreement
                        {
                            Id = reader.GetInt32(0),
                            AssetId = reader.GetInt32(1),
                            Tenant = reader.GetInt32(2),
                            Start = reader.GetDateTime(3),
                            End = reader.GetDateTime(4),
                        }
                    );
                }
            }

            return rentalAgreements.ToArray();
        }

        public Tenant[] GetTenants()
        {
            List<Tenant> tenants = new List<Tenant>();
            String query = "SELECT Id,Name FROM Tenant";

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tenants.Add(new Tenant { Id = reader.GetInt32(0), Name = reader.GetString(1) });
                }
            }

            return tenants.ToArray();
        }
    }
}
