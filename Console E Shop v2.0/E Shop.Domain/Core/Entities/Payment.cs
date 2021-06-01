using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace E_Shop.Domain.Core.Entities
{
    public class Payment
    {
        public string Name { get; set; }

        public Payment(string name)
        {
            Name = name;
        }

        public void Pay(string wayOfPayment)
        {
            if (wayOfPayment == Name)
            {
                Console.WriteLine("\t============================");
                Console.WriteLine("\tThe Payment was successfull!");
                Console.WriteLine("\t============================");
                Thread.Sleep(3000);
            }
        }
    }
}
