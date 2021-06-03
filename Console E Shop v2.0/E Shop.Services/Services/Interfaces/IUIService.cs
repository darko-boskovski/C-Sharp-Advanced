using E_Shop.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Services.Services.Interfaces
{
    public interface IUIService<T> 
    {
        void ShowMainMenu();
        void ShowProductsMenu();
        void ShowSearchMenu();
        bool ShoppingCart(T user);
        bool GetReceipt(T user, List<T> historyUsers);
        string PrintReceipt(T user);
        void OrderMenu();
        void SortMenu();
        void PaymentMenu();
        void ShippingMenu();
        void SeeHisotryMenu();


    }
}
