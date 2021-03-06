using System;
using System.Collections.Generic;
using Exercises.Entities;

namespace Exercise_3
{
    class Program
    {

        public static void GoThrough<T>(List<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------");
        }

        public static void PrintAnimal<T>(List<T> items) where T : Animal
        {  
            items.ForEach(x => x.Print()); 
            Console.WriteLine("-----------");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("-----------");

            List<int> numList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            List<Bird> birdList = new List<Bird>()
            {
               new Bird(true,"Petra",1),
               new Bird(true,"Johnatan Livingstone",3),
               new Bird(false,"Galebco",5)

            };

            GoThrough<int>(numList);
            PrintAnimal<Bird>(birdList);

            Console.ReadLine();
        }
    }
}
