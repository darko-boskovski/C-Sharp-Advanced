using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_5.Entities
{
    public class Subscriber2
    {
       

            public string Name { get; set; }
            public Subscriber2()
            {

            }
            public Subscriber2(string name)
            {
                Name = name;
            }

            public void Mail(string message)
            {

            Console.WriteLine($"{message} - {Name}: I've got the message through E-Mail");

        }
        

    }
}
