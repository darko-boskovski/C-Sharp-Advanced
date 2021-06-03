using ConsoleTables;
using E_Shop.Domain.Core.Entities;
using E_Shop.Domain.Core.Enums;
using E_Shop.Domain.Db;
using E_Shop.Services.Services.Implementations;
using E_Shop.Services.Services.Interfaces;
using Newtonsoft.Json;
using SEDC.TryBeingFit.Services.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;


namespace E_Shop.App
{
    class Program
    {

        public static IBicycleService<Bicycle> _bicycleService = new BicycleService<Bicycle>();
        public static IDb<Bicycle> _bicycleDataBase = new BicycleDb<Bicycle>();

        static void Main(string[] args)
        {
            try
            {

                List<Bicycle> bicyclesToJson = _bicycleService.GetAllProducts();
                BicycleGenerator.RandBikeGenerator(bicyclesToJson, 20);
                bicyclesToJson.ForEach(x => _bicycleDataBase.Insert(x));

                List<Bicycle> products = new List<Bicycle>();

                products = _bicycleDataBase.GetAll();

                var vendors = Enum.GetValues(typeof(Brand)).Cast<Brand>().ToList();

                List<User> userHistory = new List<User>();

                bool exitProgramme = true;
                while (exitProgramme)
                {

                    Console.Clear();
                    Console.WriteLine("====================================================================================");
                    Console.WriteLine("               Welcome to the Bicycle e-shop. Please enter your Name                ");
                    Console.WriteLine("====================================================================================");

                    string userName = Console.ReadLine();

                    if (ValidationHelper.ValidateString(userName) == null)
                    {
                        Console.ReadLine();
                        continue;
                    };

                    User user = new User(userName);
                    int id = 1;
                    Console.WriteLine("\t============================");
                    Console.WriteLine($"\t\tHello: {userName}!");

                    EShopServices._userService.ShowMainMenu();

                    bool mainExit = true;

                    while (mainExit)
                    {
                        bool userMainInput = int.TryParse(Console.ReadLine(), out int mainInput);
                        switch (mainInput)
                        {
                            case 1:
                                EShopServices.BrowseProducts(user, id, vendors, products);
                                break;
                            case 2:
                                EShopServices.SearchProducts(id, user, products);
                                break;
                            case 3:
                                EShopServices._userService.ShoppingCart(user);
                                break;
                            case 4:
                                EShopServices._userService.GetReceipt(user, userHistory);
                                break;
                            case 5:
                                EShopServices.PayMethod(user);
                                break;
                            case 6:
                                EShopServices.ShipingMethod(user);
                                break;
                            case 7:
                                EShopServices.OrderHistory(userHistory);
                                break;
                            case 9:
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("\t==================");
                                Console.WriteLine("\t No such choice!");
                                Console.WriteLine("\t==================");
                                Console.Clear();
                                mainExit = false;
                                break;
                        }
                        if (mainInput == 9)
                        {
                            Console.Clear();
                            Console.WriteLine("\t==============================================");
                            Console.WriteLine("\t Thank your for choosing our Bicycle E-Shop!\n");
                            Console.WriteLine("\t==============================================");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            EShopServices._userService.ShowMainMenu();
                            mainExit = true;
                        }
                    }
                    userHistory.Add(user);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.Color("We apologize for the inconvenience, but we are experiencing technical difficulties.\nWe are working hard to try and resolve the issue as soon as possible. Please Try Again later.\nThank you for your understanding.\n", ConsoleColor.Green);

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadLine();
        }

    }
}
