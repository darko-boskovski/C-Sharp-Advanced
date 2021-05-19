using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_5.Entities
{
    public class Subscriber3
    {
       

            public string Name { get; set; }
            public Subscriber3()
            {

            }
            public Subscriber3(string name)
            {
                Name = name;
            }

            public void SMS(string message)
             {
                
                    Console.WriteLine($"{message} - {Name}: I've got the message through SMS");
               
            }
        

    }
}
