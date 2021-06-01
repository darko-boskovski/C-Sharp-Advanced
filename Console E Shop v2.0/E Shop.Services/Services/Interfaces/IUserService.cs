using E_Shop.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Services.Services.Interfaces
{
    public interface IUserService<T> where T : User
    {
        void ShowMainMenu();
        void ShowProductsMenu();
        void ShowSearchMenu();
        bool ShoppingCart(T user);
        bool GetReceipt(T user, List<T> historyUsers);
        string PrintReceipt(T user);
        void OrderMenu();
        void SortMenu();     
        bool PayWithCreditCard(T user);
        void PayWithPayPal(T user);
        void PaymentMenu();
        void ShippingMenu();
        void SeeHisotryMenu();
        void HistoryLessThan30000(List<T> userHistory);
        void HistoryMoreThan30000(List<T> userHistory);
        void ListBrands();
        string GetBrand(int num);
        List<Bicycle> GetProductsByBrand(string userSearchInput, List<Bicycle> products);
        void SortByBrandNameAscending(List<Bicycle> searchList);
        void SortByBrandNameDescending(List<Bicycle> searchList);
        void SortByBrandNamePrice(List<Bicycle> searchList);
        void SortByBrandNamePriceDescending(List<Bicycle> searchList);
        List<Bicycle> GetProductsByName(string userSearchInput, List<Bicycle> products);
        void GetProductsByNameAscending(List<Bicycle> searchList);
        void GetProductsByNameDescending(List<Bicycle> searchList);
        void GetProductsByNamePriceAscending(List<Bicycle> searchList);
        void GetProductsByNamePriceDescending(List<Bicycle> searchList);


    }
}
