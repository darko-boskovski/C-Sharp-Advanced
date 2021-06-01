using E_Shop.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static E_Shop.Domain.Core.Entities.User;

namespace E_Shop.Domain.Core.Entities
{
    public class Shipping : IShipping
    {
        public string Name { get; set; }

        public Shipping(string name)
        {
            Name = Name;
        }

        public void ShipOrder(string shippingCompany,Address address)
        {   
            if (shippingCompany == Name)
            {
                Console.WriteLine("\t=========================================");
                Console.WriteLine("\tYour order has been shipped successfully!");
                Console.WriteLine("\t=========================================");
                Thread.Sleep(2500);
            }
        }
    }
}
