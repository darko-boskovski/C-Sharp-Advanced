using ConsoleTables;
using E_Shop.Domain.Core.Entities;
using E_Shop.Domain.Core.Enums;
using E_Shop.Domain.Db;
using E_Shop.Services.Services.Interfaces;
using SEDC.TryBeingFit.Services.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace E_Shop.Services.Services.Implementations
{


    public class UIService<T> : IUIService<T> where T : User
    {


        #region Menus
        public void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\t================================");
            Console.WriteLine("\t Select number to choose what would you like to do? \n");
            Console.WriteLine("\n\t 1) - See All available Bicycles");
            Console.WriteLine("\n\t 2) - Browse Bicycles");
            Console.WriteLine("\n\t 3) - Shopping cart");
            Console.WriteLine("\n\t 4) - Get Receipt");
            Console.WriteLine("\n\t 5) - Payment method");
            Console.WriteLine("\n\t 6) - Shipping");
            Console.WriteLine("\n\t 7) - Orders history");
            Console.WriteLine("\n\t 9) - Exit");
            Console.WriteLine("\t================================");
        }

        public void ShowProductsMenu()
        {

            Console.WriteLine("\t================================");
            Console.WriteLine("\tChoose action: \n");
            Console.WriteLine("\n\t 1) - List Bicycle brands");
            Console.WriteLine("\n\t 2) - List all available Bicycles");
            Console.WriteLine("\n\t 3) - Browse Bicycles");
            Console.WriteLine("\n\t 9) - Back to main menu");
            Console.WriteLine("\t================================");
        }

        public void ShowSearchMenu()
        {
            Console.WriteLine("\t================================");
            Console.WriteLine("\tSet search parameters:");
            Console.WriteLine();
            Console.WriteLine("\n\t 1) - Search Bicycles by brand name");
            Console.WriteLine("\n\t 2) - Search Bicycle by model");
            Console.WriteLine("\t================================");
        }

        public void OrderMenu()
        {

            Console.WriteLine("\t================================");
            Console.WriteLine("\n\t Would you like to make an order? \n");
            Console.WriteLine("\n\t 1) - Make order");
            Console.WriteLine("\n\t 9) - Go back");
            Console.WriteLine("\t================================");
            Console.ResetColor();
        }

        public void SortMenu()
        {

            Console.WriteLine("\t================================");
            Console.WriteLine("\n\t Sort products by: \n");
            Console.WriteLine("\n\t 1) - Price (ascending)");
            Console.WriteLine("\n\t 2) - Price (descending)");
            Console.WriteLine("\n\t 3) - Model (ascending)");
            Console.WriteLine("\n\t 4) - Model (descending)");
            Console.WriteLine("\n\t 9) - Go back");
            Console.WriteLine("\t================================");
            Console.ResetColor();
        }

        public void PaymentMenu()
        {

            Console.WriteLine("\t================================");
            Console.WriteLine("\t Choose payment method: \n");
            Console.WriteLine("\n\t 1) - Pay with credit card");
            Console.WriteLine("\n\t 2) - Pay with PayPal");
            Console.WriteLine("\n\t 9) - Go back");
            Console.WriteLine("\t================================");
            Console.ResetColor();
        }

        public void ShippingMenu()
        {

            Console.WriteLine("\t================================");
            Console.WriteLine("\t Choose shipping method: \n");
            Console.WriteLine("\n\t 1) - Makedonska Posta");
            Console.WriteLine("\n\t 2) - Delco");
            Console.WriteLine("\n\t 9) - Go back");
            Console.WriteLine("\t================================");
            Console.ResetColor();
        }

        public void SeeHisotryMenu()
        {

            Console.WriteLine("\t================================");
            Console.WriteLine("\t Choose orders history option: \n");
            Console.WriteLine("\n\t 1) - Orders smaller than 30000 MKD");
            Console.WriteLine("\n\t 2) - Orders larger than 30000 MKD");
            Console.WriteLine("\n\t 9) - Go back");
            Console.WriteLine("\t================================");
            Console.ResetColor();
        }
        #endregion
        public bool ShoppingCart(T user)
        {
            Console.Clear();
            Console.WriteLine("\t===================================");
            Console.WriteLine("\n\t SHOPPING CART");
            Console.WriteLine("\t===================================");
            if (user.ListOrder.GetCount() != 0)
            {

                user.ListOrder.Print();
                Console.WriteLine("\t=========================================================");
                do
                {
                    Console.WriteLine("\tWould you like to remove an item from the shopping cart?");
                    Console.WriteLine("\t============");
                    Console.WriteLine("\t Press Y/N... ");
                    Console.WriteLine("\t=============");
                    string userRemoveChoice = Console.ReadLine().ToUpper();
                    if (userRemoveChoice == "Y")
                    {
                        Console.WriteLine("\t=========================================================");
                        Console.WriteLine("\tChoose an id of the Bicycle you would like to remove");
                        Console.WriteLine("\t=========================================================");

                        bool boolInput = int.TryParse(Console.ReadLine(), out int userRemoveInput);
                        if (!boolInput) Console.WriteLine("\tPlease Enter Numbers Only");
                        user.ListOrder.RemoveItemFromOrder(userRemoveInput);
                        continue;
                    }
                    else
                    {
                       
                        break;
                    }
                }
                while (true);
            }
            else
            {
                Console.WriteLine("\t================================");
                Console.WriteLine("\tYour shopping cart is emprty!");
                Console.WriteLine("\t================================");
                Thread.Sleep(3000);
                return false;
            }
            return true;
        }

        public bool GetReceipt(T user, List<T> historyUsers)
        {
            Console.Clear();
            string userReceipt = PrintReceipt(user);
            if (user.ListOrder.GetCount() != 0)
            {
                Console.WriteLine(PrintReceipt(user));
                string receiptDirectoryPath = @"..\..\..\Receipt\";
                string receiptPath = receiptDirectoryPath + "receipt.txt";


                if (!Directory.Exists(receiptDirectoryPath)) Directory.CreateDirectory(receiptDirectoryPath);
                if (!File.Exists(receiptPath)) File.Create(receiptPath).Close();


                File.WriteAllText(receiptPath, userReceipt);
                historyUsers.Add(user);
                Thread.Sleep(4000);

                return true;
            }
            else
            {
                Console.WriteLine("\t=====================");
                Console.WriteLine("\t   Empty receipt...");
                Console.WriteLine("\t====================");
                Thread.Sleep(3000);
            }
            return true;
        }

        public string PrintReceipt(T user)
        {

            DateTime timeNow = DateTime.Now;
            string receipt = $"" +
                $"\n\t==============================" +
                $"\n\t==============================" +
                $"\n\t   Customer: {user.Name}" +
                $"\n\t=============================" +
                $"{user.ListOrder.PrintForReceipt()}" +
                $"\n\t=============================" +
                $"\n\t=============================" +
                $"\n\t    {timeNow}" +
                $"\n\t=============================" +
                $"\n\tThank you for ycling with us!" +
                $"\n\t=============================" +
                $"\n\t    Viva La Bicicleta! " +
                $"\n\t=============================";
            return receipt;
        }

        public bool PayWithCreditCard(T user)
        {
            Console.WriteLine("\t=====================================");
            Console.WriteLine("\tPlease enter your credit card number:");
            Console.WriteLine("\t=====================================");

            bool boolNumber = long.TryParse(Console.ReadLine(), out long userCredCard);

            if (userCredCard.ToString().Length == 16 && boolNumber)
            {
                Payment paymentOne = new Payment("Credit card");
                user.EventHandlerOne += paymentOne.Pay;
                Console.WriteLine($"\tPaying with credit card!");
                Console.WriteLine("\t===========================");
                user.ProcessPayment(paymentOne.Name);
                return true;
            }
            else
            {
                Console.WriteLine("\t==============================================================");
                Console.WriteLine("\tYou have entered invalid Credit Card Number. Please Try again!");
                Console.WriteLine("\tMake sure you have entered 16 digit number!");
                Console.WriteLine("\t==============================================================");
                PayWithCreditCard(user);
            }
            Thread.Sleep(2000);
            return true;
        }

        public void PayWithPayPal(T user)
        {
            Console.WriteLine("\tEnter your PayPal username:");
            Console.WriteLine("\t================================");
            string userName = Console.ReadLine();
            if (ValidationHelper.ValidateString(userName) == null)
            {
                Console.ReadLine();
                PayWithPayPal(user);
                return;
            };
            Console.WriteLine("\tEnter your PayPal password:");
            Console.WriteLine("\t================================");

            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring(0, password.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }


            if (ValidationHelper.ValidateString(password) == null)
            {
                PayWithPayPal(user);
                return;
            };

            Payment paymentTwo = new Payment("PayPal");
            user.EventHandlerOne += paymentTwo.Pay;
            Console.WriteLine($"\tPaying with PayPal!");
            Console.WriteLine("\t======================");
            user.ProcessPayment(paymentTwo.Name);
            Thread.Sleep(2000);
        }

        public void HistoryLessThan30000(List<T> userHistory)
        {
            Console.WriteLine("\tOrders smaller than 30000 MKD");
            Console.WriteLine("\t================================");
            List<T> smallerThan = userHistory
                .Where(x => x.ListOrder.OrderTotal() < 30000)
                .ToList();
            if (smallerThan.Count == 0)
            {
                Console.WriteLine("\tThere are no shuch orders!...");
                Thread.Sleep(4000);
                return;
            }
            smallerThan.ForEach(x => Console.WriteLine($"\tCustomer {x.Name} - total order price {x.ListOrder.OrderTotal()} MKD"));
            smallerThan.ForEach(x => x.ListOrder.Print());
            Thread.Sleep(4000);
        }
        public void HistoryMoreThan30000(List<T> userHistory)
        {
            Console.WriteLine("\tOrders larger than 30000 MKD");
            Console.WriteLine("\t================================");
            var largerThan = userHistory
                .Where(x => x.ListOrder.OrderTotal() > 30000)
                .FirstOrDefault();
            if (largerThan == null)
            {
                Console.WriteLine("\tThere are no shuch orders!...");
                Thread.Sleep(4000);
                return;
            }

            Console.WriteLine($"\tCustomer {largerThan.Name} - total order price {largerThan.ListOrder.OrderTotal()} MKD ");
            largerThan.ListOrder.Print();
            Thread.Sleep(4000);
        }

        #region Get and Sort Methods

        public void ListBrands()
        {
            ConsoleTable table = new ConsoleTable("Id", "Brand");

            List<Brand> brands = Enum.GetValues(typeof(Brand)).Cast<Brand>().ToList();

            int id = 1;
            brands.ForEach(x => table.AddRow(id++, x));
            table.Write();
        }

        public string GetBrand(int num)
        {
            List<Brand> brands = Enum.GetValues(typeof(Brand)).Cast<Brand>().ToList();

            string brand = string.Empty;

            for (int i = 0; i < brands.Count; i++)
            {
                if (i + 1 == num)
                {
                    brand = brands[i].ToString();
                }
            }

            if (brand == "") Console.WriteLine("\tNo such Id!");

            return brand;
        }

        public List<Bicycle> GetProductsByBrand(string userSearchInput, List<Bicycle> products)
        {
            var searchList = products
                      .Where(x => x.Brand.ToString().ToLower().Contains(userSearchInput.ToLower()))
                      .ToList();
            searchList.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Brand}  | {x.Name} | {x.Price} MKD"));
            Console.WriteLine("\t=================================================================");
            return searchList;
        }

        public void SortByBrandNameAscending(List<Bicycle> searchList)
        {
            var sortByVendorName = searchList
                    .OrderBy(x => x.Brand.ToString())
                    .ToList();
            sortByVendorName.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Brand}  | {x.Name} | {x.Price} MKD"));
            Console.WriteLine("\t=================================================================");
        }

        public void SortByBrandNameDescending(List<Bicycle> searchList)
        {
            var sortByVendorName = searchList
                    .OrderByDescending(x => x.Brand.ToString())
                    .ToList();
            sortByVendorName.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Brand}  | {x.Name} | {x.Price} MKD"));
            Console.WriteLine("\t=================================================================");
        }

        public void SortByBrandNamePrice(List<Bicycle> searchList)
        {
            var sortPriceAscendig = searchList
                                         .OrderBy(x => x.Price)
                                         .ToList();
            sortPriceAscendig.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Brand}  | {x.Name} | {x.Price} MKD"));
            Console.WriteLine("\t=================================================================");
        }

        public void SortByBrandNamePriceDescending(List<Bicycle> searchList)
        {
            var sortPriceAscendig = searchList
                                         .OrderByDescending(x => x.Price)
                                         .ToList();
            sortPriceAscendig.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Brand}  | {x.Name} | {x.Price} MKD"));
            Console.WriteLine("\t=================================================================");
        }

        public List<Bicycle> GetProductsByName(string userSearchInput, List<Bicycle> products)
        {
            var searchList = products
                .Where(x => x.Name.ToLower().Contains(userSearchInput.ToLower()))
                .ToList();
            searchList.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Brand}  | {x.Name} | {x.Price} MKD"));
            Console.WriteLine("\t=================================================================");
            return searchList;
        }

        public void GetProductsByNameAscending(List<Bicycle> searchList)
        {
            var sortByNameAscending = searchList
                                              .OrderBy(x => x.Name)
                                              .ToList();
            sortByNameAscending.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Brand} | {x.Name} | {x.Price} MKD"));
            Console.WriteLine("\t=================================================================");
        }

        public void GetProductsByNameDescending(List<Bicycle> searchList)
        {
            var sortByNameAscending = searchList
                                              .OrderByDescending(x => x.Name)
                                              .ToList();
            sortByNameAscending.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Brand} | {x.Name} | {x.Price} MKD"));
            Console.WriteLine("\t=================================================================");
        }

        public void GetProductsByNamePriceAscending(List<Bicycle> searchList)
        {
            var sortByPriceAscendig = searchList
                                             .OrderBy(x => x.Price)
                                             .ToList();
            sortByPriceAscendig.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Brand}  | {x.Name} | {x.Price} MKD"));
            Console.WriteLine("\t=================================================================");
        }

        public void GetProductsByNamePriceDescending(List<Bicycle> searchList)
        {
            var sortByPriceAscendig = searchList
                                             .OrderByDescending(x => x.Price)
                                             .ToList();
            sortByPriceAscendig.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Brand}  | {x.Name} | {x.Price} MKD"));
            Console.WriteLine("\t=================================================================");
        }

        #endregion
    }
}
