using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism_Exercise.Entites
{
    public static class DogShelter
    {
        public static List<Dog> DogList { get; set; } = new List<Dog>();


        static DogShelter()
        {


            Dog dog01 = new Dog(1, "", "Yello");
            Dog dog02 = new Dog(2, "Sharky", "Black");
            Dog dog03 = new Dog(3, "Marrky", "White");

            if (Dog.Validate(dog01)) DogList.Add(dog01);
            if (Dog.Validate(dog02)) DogList.Add(dog02);
            if (Dog.Validate(dog03)) DogList.Add(dog03);
        
        }


        public static void PrintAll()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("This is the list of all Dogs");
            Console.WriteLine("--------------------------------------");
            DogList.ForEach(dog => Console.WriteLine(dog.Name));
            Console.WriteLine("--------------------------------------");
        }

       

    }
}
