using ConsoleTables;
using E_Shop.Domain.Core.Entities;
using E_Shop.Domain.Core.Enums;
using E_Shop.Services.Services.Interfaces;
using SEDC.TryBeingFit.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace E_Shop.Services.Services.Implementations
{
    public static class EShopServices
    {


        public static UIService<User> _userService = new UIService<User>();


        public static bool BrowseProducts(User user, int id, List<Brand> brands, List<Bicycle> products)
        {
            Console.Clear();
            _userService.ShowProductsMenu();
            while (true)
            {
                bool userProductInput = int.TryParse(Console.ReadLine(), out int productsInput);
                if (!userProductInput) Console.WriteLine("\tPlease Enter Numbers Only");

                switch (productsInput)
                {
                    case 1:
                        ListAllProducts(user, id, brands, products);
                        return true;
                    case 2:
                        ListProducts(user, id, products);
                        //_userService.ShowProductsMenu();
                        return true;
                    case 3:
                        SerchProductsByName(user, id, products);
                        //_userService.ShowProductsMenu();
                        return true;
                    case 9:
                        return false;
                    default:
                        Console.Clear();
                        _userService.ShowProductsMenu();
                        return false;
                }
            }
        }


        public static void ListAllProducts(User user, int id, List<Brand> brands, List<Bicycle> products)
        {
            _userService.ListBrands();
            Console.WriteLine("\t================================");
            Console.WriteLine("\n\tThese are all available Bicycle Brands.\n");
            Console.WriteLine("\t- Choose number to see models\n");
            Console.WriteLine("\t- Press 0.) to go back");
            Console.WriteLine("\t================================");


            bool brandExit = true;
            while (brandExit)
            {
                bool userVendorInput = int.TryParse(Console.ReadLine(), out int brandInput);
                string brandName = _userService.GetBrand(brandInput);

                Console.WriteLine(brandName);
                Console.WriteLine("\t================================");

                var table = new ConsoleTable("ID", "BRAND", "MODEL", "PRICE");

                if (brandInput > 0 && brandInput <= brands.Count && brandInput != 0)
                {
                    var filteredBrandList = products
                    .Where(x => x.Brand.ToString() == brandName)
                    .ToList();

                    filteredBrandList.ForEach(x => table.AddRow(x.Id, x.Brand, x.Name, x.Price + "MKD"));
                    table.Write();

                    id = MakeOrder(filteredBrandList, user, id);
                    break;
                }
                if (brandInput == 0)
                {
                    _userService.ShowProductsMenu();
                    brandExit = false;
                }
                else
                {
                    brandExit = true;
                }
            }
        }

        public static bool ListProducts(User user, int id, List<Bicycle> products)
        {
            Console.Clear();

            var table = new ConsoleTable("ID", "BRAND", "MODEL", "PRICE");

            products.ForEach(x => table.AddRow(x.Id, x.Brand, x.Name, x.Price));
            table.Write();

            id = MakeOrder(products, user, id);
            return false;
        }

        public static void SerchProductsByName(User user, int id, List<Bicycle> products)
        {

            Console.Clear();
            Console.WriteLine("\tSearch product by Model:");
            string userSearchInput = Console.ReadLine();
            Console.WriteLine();
            var searchList = products
                .Where(x => x.Name.ToLower().Contains(userSearchInput.ToLower()))
                .ToList();

            var table = new ConsoleTable("ID", "BRAND", "MODEL", "PRICE");

            if (searchList.Count == 0)
            {
                Console.WriteLine("\tWe didn't find any product with that model name!...");
                Thread.Sleep(3000);
                return;
            }

            if (searchList.Count != 0)
            {
                searchList.ForEach(x => table.AddRow(x.Id, x.Brand, x.Name, x.Price + "MKD"));
                table.Write();
                Console.WriteLine("\t================================");
                id = MakeOrder(searchList, user, id);
            }
            else
            {
                Console.WriteLine("\t==============================");
                Console.WriteLine("\tEnter correct search input!");
                Console.WriteLine("\t==============================");
                Thread.Sleep(3000);
            }
        }

        public static int SearchProducts(int index, User user, List<Bicycle> products)
        {
            Console.Clear();
            Console.WriteLine("\n\t=====================================");
            Console.WriteLine("\n\tPlease choose your search parameters:");
            Console.WriteLine();
            Console.WriteLine("\t1) - Search by Brand ");
            Console.WriteLine("\t2) - Search by Model");
            Console.WriteLine("\n\t=====================================");

            bool userSearchBrandProduct = int.TryParse(Console.ReadLine(), out int searchBrandProduct);

            Console.WriteLine("\n\tEnter your search input:");
            string userSearchInput = Console.ReadLine().Trim();

            if (userSearchInput.Length == 0)
            {
                Console.WriteLine("\t==========================");
                Console.WriteLine("\tEnter correct searh input!");
                Console.WriteLine("\t==========================");
                Thread.Sleep(1000);
                SearchProducts(index, user, products);
                return -1;
            }
            var searchList = _userService.GetProductsByBrand(userSearchInput, products);
            if (searchBrandProduct == 1)
            {

                if (searchList.Count == 0)
                {
                    Console.WriteLine("\n\tThere are are no Such Bicycles!");
                    Thread.Sleep(2000);
                    return 1;
                }

                Console.WriteLine("\tPlease choose sort parameters:");
                Console.WriteLine("\t========================");
                Console.WriteLine("\t1) - Sort by brand name");
                Console.WriteLine("\t2) - Sort by price");
                Console.WriteLine("\t========================");
                bool userSearchNamePrice = int.TryParse(Console.ReadLine(), out int searchNamePrice);
                if (searchNamePrice == 1)
                {

                    Console.WriteLine("\t1) - Sort - ascending");
                    Console.WriteLine("\t2) - Sort - descending");
                    Console.WriteLine("\t========================");
                    bool userSearchAscendingDescendig01 = int.TryParse(Console.ReadLine(), out int searchAscendingDescendig01);
                    if (searchAscendingDescendig01 == 1)
                    {
                        _userService.SortByBrandNameAscending(searchList);

                    }
                    else if (searchAscendingDescendig01 == 2)
                    {
                        _userService.SortByBrandNameDescending(searchList);
                    }
                }
                else if (searchNamePrice == 2)
                {
                    Console.WriteLine("\t1) - Sort - ascending");
                    Console.WriteLine("\t2) - Sort - descending");
                    Console.WriteLine("\t========================");
                    bool userSearch010101 = int.TryParse(Console.ReadLine(), out int sortAscendingDescendig);
                    if (sortAscendingDescendig == 1)
                    {
                        _userService.SortByBrandNamePrice(searchList);
                    }
                    else if (sortAscendingDescendig == 2)
                    {
                        _userService.SortByBrandNamePriceDescending(searchList);
                    }
                }
            }
            else if (searchBrandProduct == 2)
            {

                if (searchList.Count == 0)
                {
                    Console.WriteLine("\n\tThere are are no Such Bicycles!");
                    Thread.Sleep(2000);
                    return 1;
                }

                Console.WriteLine("\tPlease choose sort parameters:");
                Console.WriteLine("\t========================");
                Console.WriteLine("\t1) - Sort by name");
                Console.WriteLine("\t2) - Sort by price");
                Console.WriteLine("\t========================");
                bool userSortNamePrice = int.TryParse(Console.ReadLine(), out int sortNamePrice);
                if (sortNamePrice == 1)
                {
                    Console.WriteLine("\t1) - Sort - ascending");
                    Console.WriteLine("\t2) - Sort - descending");
                    Console.WriteLine("\t========================");
                    bool userortAscendingDescending = int.TryParse(Console.ReadLine(), out int sortNameAscendingDescending);
                    if (sortNameAscendingDescending == 1)
                    {
                        _userService.GetProductsByNameAscending(searchList);
                    }
                    else if (sortNameAscendingDescending == 2)
                    {
                        _userService.GetProductsByNameDescending(searchList);
                    }
                }
                else if (sortNamePrice == 2)
                {

                    Console.WriteLine("\t1) - Sort - ascending");
                    Console.WriteLine("\t2) - Sort - descending");
                    Console.WriteLine("\t========================");
                    bool userSortAscDesc = int.TryParse(Console.ReadLine(), out int sortPriceAscendigDescending);
                    if (sortPriceAscendigDescending == 1)
                    {
                        _userService.GetProductsByNamePriceAscending(searchList);
                    }
                    else if (sortPriceAscendigDescending == 2)
                    {
                        _userService.GetProductsByNamePriceDescending(searchList);
                    }
                }
            }
            return MakeOrder(searchList, user, index);

        }



        public static int MakeOrder(List<Bicycle> products, User user, int id)
        {
            _userService.OrderMenu();

            bool orderExit1 = true;
            while (orderExit1)
            {

                bool userMakeOrderInput = int.TryParse(Console.ReadLine(), out int makeOrderInput);
                switch (makeOrderInput)
                {
                    case 1:
                        int userQuantInput = 0;
                        while (true)
                        {
                            Console.WriteLine("\t===============================================================");
                            Console.WriteLine("\tChoose product from the list by entering the Bicycle ID...");
                            Console.WriteLine("\t===============================================================");

                            if (!int.TryParse(Console.ReadLine(), out int userIdInput)) Console.WriteLine("Please enter numbers only");

                            Bicycle product = products
                               .SingleOrDefault(x => x.Id == userIdInput);

                            Console.WriteLine("\t===============================================================");

                            if (product != null)
                            {
                                Console.WriteLine("\t==========================================");
                                Console.WriteLine("\t   how many products would you like ?");
                                Console.WriteLine("\t==========================================");

                                try
                                {
                                    userQuantInput = int.Parse(Console.ReadLine());
                                }

                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    Thread.Sleep(3000);
                                }
                                id = ++user.ListOrder.Id;
                                user.ListOrder.AddOrder(product, userQuantInput, id);
                                id++;

                                Console.WriteLine("\t================================");
                                Console.WriteLine("\tWould you like to add another product?");
                                Console.WriteLine("\tPress 1.) for Yes, 9.) for No");
                                Console.WriteLine("\t================================");
                                try
                                {
                                    int userSameVendorChoice = int.Parse(Console.ReadLine());

                                    if (userSameVendorChoice == 1)
                                    {
                                        continue;
                                    }
                                    else if (userSameVendorChoice == 9)
                                    {
                                        orderExit1 = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\t===============");
                                        Console.WriteLine("\tNo such option!");
                                        Console.WriteLine("\t===============");
                                        _userService.OrderMenu();
                                        break;
                                    }
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    Thread.Sleep(3000);
                                }
                            }
                            else
                            {
                                Console.WriteLine("\t===========");
                                Console.WriteLine("\tNo such id!");
                                Console.WriteLine("\t===========");
                                MakeOrder(products, user, id);
                                orderExit1 = false;
                                break;
                            }
                        }

                        break;
                    case 9:
                        break;
                    default:
                        Console.WriteLine("\t============");
                        Console.WriteLine("\tWrong input!");
                        Console.WriteLine("\t============");
                        MakeOrder(products, user, id);
                        break;
                }
                if (makeOrderInput == 9)
                {
                    orderExit1 = false;
                }
            }
            return id;
        }

        public static void PayMethod(User user)
        {
            Console.Clear();
            if (user.ListOrder.GetCount() != 0)
            {
                _userService.PaymentMenu();
                bool payExit = true;
                while (payExit)
                {
                    bool userPayInput = int.TryParse(Console.ReadLine(), out int payInput);
                    switch (payInput)
                    {
                        case 1:
                            _userService.PayWithCreditCard(user);
                            payExit = false;
                            break;
                        case 2:
                            _userService.PayWithPayPal(user);
                            payExit = false;
                            break;
                        case 9:
                            payExit = false;
                            break;
                        default:
                            Console.WriteLine("\tNo such choice. Please Try again!");
                            Console.WriteLine("\t=================================");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\t===============================");
                Console.WriteLine("\tThe Shoping cart is empty ...");
                Console.WriteLine("\t===============================");
                Thread.Sleep(2000);
            }
        }

        public static void ShipingMethod(User user)
        {
            Console.Clear();
            if (user.ListOrder.GetCount() != 0)
            {
                _userService.ShippingMenu();
                bool shipExit = true;
                while (shipExit)
                {
                    bool userShipInput = int.TryParse(Console.ReadLine(), out int shipInput);

                    switch (shipInput)
                    {
                        case 1:
                            ShipingProductMakedonskaPosta(user);
                            shipExit = false;
                            break;
                        case 2:
                            ShipingProductDelco(user);
                            shipExit = false;
                            break;
                        case 9:
                            shipExit = false;
                            break;
                        default:
                            Console.WriteLine("\t=================================");
                            Console.WriteLine("\tNo such choice. Please Try again!");
                            Console.WriteLine("\t=================================");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\t=================================");
                Console.WriteLine("\t The shopping cart is empty ...");
                Console.WriteLine("\t=================================");
                Thread.Sleep(2000);
            }
        }

        public static void OrderHistory(List<User> userHistory)
        {
            Console.Clear();
            _userService.SeeHisotryMenu();
            bool histExit = true;
            while (histExit)
            {
                bool userHistoryInput = int.TryParse(Console.ReadLine(), out int historyInput);
                switch (historyInput)
                {
                    case 1:
                        _userService.HistoryLessThan30000(userHistory);
                        histExit = false;
                        break;
                    case 2:
                        _userService.HistoryMoreThan30000(userHistory);
                        histExit = false;
                        break;
                    case 9:
                        histExit = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public static void ShipingProductMakedonskaPosta(User user)
        {

            User.Address userAdress = new User.Address();

            Console.WriteLine("\t================================");
            Console.WriteLine("\tYour order can be shipped only to the following cities only:\n\tSkopje, Bitola, Ohrid and Stip.");
            Console.WriteLine("\t================================");

            Console.WriteLine("\tPlease enter shiping address street name");
            string streetName = Console.ReadLine().Trim();
            if (ValidationHelper.ValidateString(streetName) == null)
            {
                Console.WriteLine("\t=========================");
                Console.WriteLine("\tPlease Enter Letters Only");
                ShipingProductMakedonskaPosta(user);
                return;
            }
            Console.WriteLine("\t=========================");
            Console.WriteLine("\tPlease enter street number");
            string streetNumber = Console.ReadLine().Trim();
            if (ValidationHelper.ValidateNumber(streetNumber, 100) < 0)
            {
                Console.WriteLine("\t=========================");
                Console.WriteLine("\tPlease enter numbers only");
                Console.WriteLine("\t=========================");
                ShipingProductMakedonskaPosta(user);
                return;
            }


            userAdress.Street = streetName;
            userAdress.Number = ValidationHelper.ValidateNumber(streetNumber, 100);


            while (true)
            {
                Console.WriteLine("\tPlease enter city:");
                string userCity = Console.ReadLine().Trim();
                if ((userCity.ToLower() == "skopje") || (userCity.ToLower() == "bitola") || (userCity.ToLower() == "ohrid") || (userCity.ToLower() == "stip"))
                {
                    userAdress.City = userCity;
                    break;
                }
                else
                {
                    continue;
                }
            }
            Shipping shippingOne = new Shipping("MakedonskaPosta");
            user.EventHandlerTwo += shippingOne.ShipOrder;
            Console.WriteLine("\t================================");
            Console.WriteLine("\t Shipping with Makedonska Posta");
            Console.WriteLine("\t================================");
            Thread.Sleep(1000);

            user.ShippingOrder(shippingOne.Name, userAdress);
            return;
        }

        public static void ShipingProductDelco(User user)
        {
            User.Address userAdress = new User.Address();

            Console.WriteLine("\t================================");
            Console.WriteLine($"\tYour order can be shipped only to the following cities only:\n\t Skopje, Bitola, Ohrid and Stip.");
            Console.WriteLine("\t================================");

            Console.WriteLine("\tPlease enter shiping address street name");
            string streetName = Console.ReadLine().Trim();
            if (ValidationHelper.ValidateString(streetName) == null)
            {
                Console.WriteLine("\t=========================");
                Console.WriteLine("\tPlease Enter Letters Only");
                Console.WriteLine("\t=========================");
                ShipingProductDelco(user);
                return;
            }


            Console.WriteLine("\tPlease enter street number");
            string streetNumber = Console.ReadLine().Trim();
            if (ValidationHelper.ValidateNumber(streetNumber, 100) < 0)
            {
                Console.WriteLine("\t=========================");
                Console.WriteLine("\tPlease enter numbers only");
                Console.WriteLine("\t=========================");
                ShipingProductDelco(user);
                return;
            }


            userAdress.Street = streetName;
            userAdress.Number = ValidationHelper.ValidateNumber(streetNumber, 100);


            while (true)
            {
                Console.WriteLine("\tPlease enter city:");
                string userCity = Console.ReadLine().Trim();
                if ((userCity.ToLower() == "skopje") || (userCity.ToLower() == "bitola") || (userCity.ToLower() == "ohrid") || (userCity.ToLower() == "stip"))
                {
                    userAdress.City = userCity;
                    break;
                }
                else
                {
                    continue;
                }
            }
            Shipping shippingTwo = new Shipping("DelCo");
            user.EventHandlerTwo += shippingTwo.ShipOrder;
            Console.WriteLine("\t================================");
            Console.WriteLine("\t  Shipping with DelCo");
            Console.WriteLine("\t================================");
            Thread.Sleep(1000);

            user.ShippingOrder(shippingTwo.Name, userAdress);
            return;
        }

    }
}
