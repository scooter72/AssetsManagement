using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AssetsManagement.Model;

namespace AssetsManagement.DAL
{
    internal sealed class MsSqlAssetManagementDataAccess : IAssetManagementDataAccess
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
 
            return ExecuteScalar
            (
              sql,
              new Dictionary<string, object>()
              {
                  ["@city"] = asset.Address.City.Symbol,
                  ["@street"] = asset.Address.Street,
                  ["@house_number"] = asset.Address.HouseNumber,
                  ["@owner"] = asset.Owner.Id
              }
            );
        }

        public int AddCity(City city)
        {
            ExecuteNonQuery
            (
               "INSERT INTO City (Symbol,Name) VALUES (@symbol,@name)",
               new Dictionary<string, object>()
               {
                   ["@symbol"] = city.Symbol,
                   ["@name"] = city.Name
               }
            );

            return city.Symbol;
        }

        public int AddCity(City[] cities)
        {
            throw new NotImplementedException();
        }

        public int AddOwner(Owner owner)
        {

            ExecuteNonQuery
            (
               "INSERT INTO Owner (id,Name) VALUES (@id,@name)",
               new Dictionary<string, object>() 
               { 
                   ["@id"] = owner.Id,
                   ["@name"] = owner.Name
               }
            );

            return owner.Id;
        }

        public int AddRentalAgreement(RentalAgreement rentalAgreement)
        {
            String query = "INSERT INTO RentalAgreement (Asset,Tenant,StartDate,EndDate) VALUES (@asset,@tenant,@start,@end);" +
                           "SELECT scope_identity();";
            
            return ExecuteScalar
            (
              query,
              new Dictionary<string, object>()
              {
                  ["@asset"] = rentalAgreement.AssetId,
                  ["@tenant"] = rentalAgreement.Tenant,
                  ["@start"] = rentalAgreement.Start,
                  ["@end"] = rentalAgreement.End
              }
            );
        }

        private int ExecuteScalar(string sql, Dictionary<string, object> parameters = null)
        {

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = sql;
                foreach (var item in parameters)
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public int AddTenant(Tenant tenant)
        {
            ExecuteNonQuery
            (
               "INSERT INTO Tenant (id,Name) VALUES (@id,@name)",
               new Dictionary<string, object>() 
               { 
                   ["@id"] = tenant.Id,
                   ["@name"] = tenant.Name
               }
            );

            return tenant.Id;
        }

        public void DeleteAsset(int id)
        {
           ExecuteNonQuery
           (
               "DELETE Asset WHERE Id = @id",
               new Dictionary<string, object>() { ["@id"] = id }
           );
        }

        public void DeleteCity(int symbol)
        {
            ExecuteNonQuery
            (
                "DELETE City WHERE Symbol = @symbol",
                new Dictionary<string, object>() { ["@symbol"] = symbol }
            );
        }

        private int ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null)
        {

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = sql;
                foreach (var item in parameters)
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }

                return command.ExecuteNonQuery();
            }
        }

        public Asset FindAssetByAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public Owner FindOwnerById(int id)
        {
            Owner owner = null;

            ExecuteReader("SELECT Id,Name FROM Owner WHERE Id = @id",
               row =>
               {
                   owner = new Owner 
                   { 
                       Id = row.GetInt32(0), 
                       Name = row.GetString(1) 
                   };
               },
               new Dictionary<string, object>() { ["@id"] = id }
             );


            return owner;
        }

        public RentalAgreement FindRentalAgreementtByAssetId(int id)
        {
            RentalAgreement rentalAgreement = null;

            ExecuteReader("SELECT Id,Asset,Tenant,StartDate,EndDate FROM RentalAgreement WHERE Asset = @id",
              row =>
              {
                  rentalAgreement = new RentalAgreement
                  {
                      Id = row.GetInt32(0),
                      AssetId = row.GetInt32(1),
                      Tenant = row.GetInt32(2),
                      Start = row.GetDateTime(3),
                      End = row.GetDateTime(4),
                  };
              },
              new Dictionary<string, object>() { ["@id"] = id }
            );

            return rentalAgreement;
        }

        public Tenant FindTenatById(int id)
        {
            Tenant tenant = null;

            ExecuteReader("SELECT Id,Name FROM Tenant WHERE Id = @id",
              row =>
              {
                  tenant =
                      new Tenant
                      {
                          Id = row.GetInt32(0),
                          Name = row.GetString(1)
                      };
              },
              new Dictionary<string, object>() { ["@id"] = id }
            );

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

            ExecuteReader(sql,
              row =>
              assets.Add(
                  new Asset
                  {
                      Id = row.GetInt32(0),
                      Owner = new Owner { Id = row.GetInt32(1), Name = row.GetString(2) },
                      Address = new Address
                      {
                          City = new City { Symbol = row.GetInt32(3), Name = row.GetString(4) },
                          Street = row.GetString(5),
                          HouseNumber = row.GetInt32(6)
                      }
                  }
                )
              );
            return assets.ToArray();
        }

        public City[] GetCities()
        {
            List<City> cities = new List<City>();

            ExecuteReader("SELECT Symbol,Name FROM City",
              row =>
              cities.Add(
                  new City 
                  { 
                      Symbol = row.GetInt32(0), 
                      Name = row.GetString(1) 
                  }
                )
              );

            return cities.ToArray();
        }

        public Owner[] GetOwners()
        {
            List<Owner> owners = new List<Owner>();
 
            ExecuteReader("SELECT Id, Name FROM Owner",
               row =>
               owners.Add(
                   new Owner 
                   { 
                       Id = row.GetInt32(0), 
                       Name = row.GetString(1) 
                   }
                 )
               );

            return owners.ToArray();
        }


        public RentalAgreement[] GetRentalAgreements()
        {
            List<RentalAgreement> rentalAgreements = new List<RentalAgreement>();

            ExecuteReader("SELECT Id,Asset,Tenant,StartDate,EndDate FROM RentalAgreement",
                row =>
                rentalAgreements.Add(
                       new RentalAgreement
                       {
                           Id = row.GetInt32(0),
                           AssetId = row.GetInt32(1),
                           Tenant = row.GetInt32(2),
                           Start = row.GetDateTime(3),
                           End = row.GetDateTime(4),
                       }
                    )
                );

            return rentalAgreements.ToArray();
        }

        public Tenant[] GetTenants()
        {
            List<Tenant> tenants = new List<Tenant>();

            ExecuteReader("SELECT Id, Name FROM Tenant",
                row =>
                tenants.Add(
                        new Tenant 
                        { 
                            Id = row.GetInt32(0), 
                            Name = row.GetString(1) 
                        }
                    )
                );

            return tenants.ToArray();
        }

        public User[] GetUsers()
        {
            List<User> users = new List<User>();

            ExecuteReader("SELECT [Id], [Username], [Password], [FirstName], [LastName], [Email], [Role] FROM [User]",
                row =>
                users.Add(
                        new User
                        {
                            Id = row.GetInt32(0),
                            Username = row.GetString(1),
                            Password = row.GetString(2),
                            FirstName = row.GetString(3),
                            LastName = row.GetString(4),
                            Email = row.GetString(5),
                            Role = row.GetInt32(6)
                        }
                    )
                );
            
            return users.ToArray();
        }

        
        private void ExecuteReader(string query, Action<IDataReader> rowConsumer, Dictionary<string, object> parameters = null)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = query;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        command.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    rowConsumer.Invoke(reader);
                }
            }
        }
    }
}
