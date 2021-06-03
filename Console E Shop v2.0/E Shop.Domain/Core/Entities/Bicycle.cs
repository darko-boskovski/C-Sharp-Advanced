using E_Shop.Domain.Core.Enums;
using E_Shop.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Domain.Core.Entities
{
    public class Bicycle : Product, IBicycle
    {
        public Size Size { get; set; }
        public TypeOfBike Type { get; set; }

        public Bicycle()
        {

        }
        public Bicycle(int id, Brand brand, string name, TypeOfBike type, int price, Size size)
        {
            Id = id;
            Name = name;
            Price = price;
            Brand = brand;
            Size = size;
            Type = type;
        }

        public override void Print()
        {
            Console.WriteLine("\t=================================");
            Console.WriteLine($"\tName:{Name} Brand{Brand} Price:{Price}");
            Console.WriteLine("\t=================================");
        }

    }
}
