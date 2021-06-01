using E_Shop.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static E_Shop.Domain.Core.Entities.User;

namespace E_Shop.Domain.Core.Entities
{
    public delegate void EventDelegate(string payment);
    public delegate void EventDelegateTwo(string shipping, Address adress);

    public class User : BaseEntity, IUser
    {
        public string Name { get; set; }
        public string City { get; set; }
        public Order ListOrder { get; set; } = new Order();

        public User()
        {

        }

        public User(string name)
        {
            Name = name;          
        }



        public void AddAdress(string street, int number, string city)
        {
            Address address = new Address();
            address.Street = street;
            address.Number = number;
            address.City = city;
        }

        public  class Address
        {
            public  string Street { get; set; }
            public  int Number { get; set; }
            public   string City { get; set; }

        }
     
        public event EventDelegate EventHandlerOne;
        public event EventDelegateTwo EventHandlerTwo;

        public void ProcessPayment(string payment)
        {
            Console.WriteLine("\tProcessing payment...");
            Console.WriteLine("\t=====================");
            Thread.Sleep(2000);
            EventHandlerOne?.Invoke(payment);
        }

       

        public void ShippingOrder(string shipping, Address address)
        {   
            Console.WriteLine("\tShipping your order...");
            Thread.Sleep(2000);
            Console.WriteLine("\t============================");
            Console.WriteLine($"\tShipping address: {address.Street} No: {address.Number}");
            Console.WriteLine($"\tShipping city: {address.City}");
            EventHandlerTwo?.Invoke(shipping, address);
        }

        public override void Print()
        {
            Console.WriteLine("\t==========================================");
            Console.WriteLine($"\tName:{Name}");
            Console.WriteLine("\t==========================================");
        }
    }
}
