using AssetsManagement.BLL;
using AssetsManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagementForms
{
    class ConsoleView
    {
        private readonly IAssetManager manager;
        private const int Retries = 3;
        public ConsoleView(IAssetManager manager)
        {
            this.manager = manager;
        }

        public void Start()
        {
            try
            {
                Console.WriteLine("Welcome to the Property Management System");
                Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void Run()
        {
            while (true)
            {
                PrintOptions();

                if (!int.TryParse(Console.ReadLine(), out var opt))
                {
                    Console.WriteLine("Option not supported");
                }

                switch (opt)
                {
                    case 1:
                        AddCity();
                        break;
                    case 2:
                        AddOwner();
                        break;
                    case 3:
                        AddAsset();
                        break;
                    default:
                        Console.WriteLine("Option not supported");
                        break;
                }
            }
        }

        private void PrintOptions()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine("Please type an option:");
            Console.WriteLine("1: Add city");
            Console.WriteLine("2: Add asset owner");
            Console.WriteLine("3: Add an asset (requires to add city and owner " +
                "to the system first)");
            Console.WriteLine("----------------------");

        }

        private void AddCity()
        {
            try
            {
                int symbol = ReadInt("Please input city symbol:");
                Console.WriteLine("Please input city name:");
                string name = Console.ReadLine();
                manager.AddCity(new City { Symbol = symbol, Name = name });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding city: {ex}");
            }
        }

        private void AddOwner()
        {
            try
            {
                int id = ReadInt("Please input owner id:");
                Console.WriteLine("Please input owner name:");
                string name = Console.ReadLine();
                manager.AddOwner(new Owner { Id = id, Name = name });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding owner: {ex}");

            }
        }

        private void AddAsset()
        {
            Console.WriteLine("Adding an asset requires that a city and owner " +
                "exists in the system first.");
            Console.WriteLine("Would you like to continue? (y,n)");

            if (!(Console.ReadLine().Equals("y")))
            {
                return;
            }

            try
            {
                Owner owner = GetAssetOwner();
                Address address = GetAssetAddress();


                if (owner != null && address != null)
                {
                    manager.AddAsset(new Asset
                    {
                        Owner = owner,
                        Address = address
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding asset: {ex}");
            }
        }

        private Owner GetAssetOwner()
        {
            Owner owner = null;

            // attempts to get a valid owner id
            for (int i = 0; i < Retries; i++)
            {
                int ownerId = ReadInt("Please input asset owner id:");
                owner = manager.FindOwnerById(ownerId);

                if (owner == null)
                {
                    Console.WriteLine("Owner not found");
                    if (i == 2)
                    {
                        return null;
                    }
                }
                else
                {
                    break;
                }
            }

            return owner;
        }

        private Address GetAssetAddress()
        {
            City city = null;
            // attempts to get a valid city
            for (int i = 0; i < Retries; i++)
            {
                Console.WriteLine("Please input asset city address");
                string cityName = Console.ReadLine();
                city = manager.FindCityByName(cityName);
                if (city == null)
                {
                    Console.WriteLine("City not found");
                    if (i == 2)
                    {
                        return null;
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Please input asset street address");
            string street = Console.ReadLine();
            int houseNumber = ReadInt("Please input asset house number:");

            return new Address
            {
                City = city,
                Street = street,
                HouseNumber = houseNumber
            };
        }

        private int ReadInt(string message)
        {
            // attempts to get a valid number
            for (int i = 0; i < Retries; i++)
            {
                Console.WriteLine(message);
                bool validNumberInput = int.TryParse(Console.ReadLine(),
                    out var result);

                if (!validNumberInput)
                {
                    Console.WriteLine("Not a valid number");
                    if (i == 2)
                    {
                        return -1;
                    }
                    else
                    {
                        continue;
                    }
                }

                return result;
            }

            return -1;
        }
    }
}

