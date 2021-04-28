using Polymorphism_Exercise.Entites;
using System;

namespace Polymorphism_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Polymorphism!");

            DogShelter.PrintAll();

            DogShelter.DogList.ForEach(dog => dog.Bark());

            
            

            Console.ReadLine();
        }
    }
}
