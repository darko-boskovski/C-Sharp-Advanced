using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism_Exercise.Entites
{
    public class Dog
    {





        public int Id { get; set; } = 0;

        public string Name { get; set; }

        public string Color { get; set; }
        public Dog()
        {

        }

        public Dog(int id, string name, string color)
        {
            Id = id;
            Name = name;
            Color = color;
        }
        public void Bark()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Bark Bark!");
            Console.WriteLine("--------------------------------------");
        }

        public static bool Validate(Dog dog)
        {
            if (dog.Id == 0 || dog.Name == "" || dog.Color == "")
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("The Object is missing a property value");
                Console.WriteLine("--------------------------------------");
                return false;
            }
            else if (dog.Id < 0 || dog.Name.Length < 2)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Please Enter Dog Id and Name longer than 2 Characters");
                Console.WriteLine("--------------------------------------");
                return false;
            }
            else { return true; }
            Console.WriteLine("--------------------------------------");

        }
    }
}
