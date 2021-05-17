using Exercises.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
 Console.WriteLine("Hello Exercises");


            List<Dog> dogList = new List<Dog>()
            {
                 new Dog("German Sheperd", "Rex", 10),
                 new Dog("Pudla", "Mila", 7),
                 new Dog("Pudla", "Pussy", 3)
            };

            List<Cat> catList = new List<Cat>()
            {
                 new Cat(true,"fluffy",3),
                 new Cat(false,"Garfield",2),
                 new Cat(true,"Zuti",5)

            };

            List<Bird> birdList = new List<Bird>()
            {
                new Bird(true,"Petra",1),
                new Bird(true,"Johnatan Livingstone",3),
                new Bird(false,"Galebco",5)

            };


            foreach (var item in dogList)
            {
                item.Print();
            }
            Console.WriteLine("---------------------------------------------------------------------");

            foreach (var item in catList)
            {
                item.Print();
            }
            Console.WriteLine("---------------------------------------------------------------------");
            foreach (var item in birdList)
            {
                item.Print();
            }
            Console.WriteLine("---------------------------------------------------------------------");




            birdList[0].FlySouth();


            //   *Get all dogs of a particular race

            List<Dog> dogRace = dogList
                 .Where(x => x.Race == "Pudla")
                 .ToList();

           //*Get the last lazy cat

            Cat lastLazyCat = catList
                                   .LastOrDefault(x => x.IsLazy);


            //*Get the all wild birds that are younger than 3 and are ordered by their name

            List<Bird> birdsYoungerThan3 = birdList
                                            .Where(x => x.Age < 3)
                                            .OrderBy(x => x.Name)
                                            .ToList();
          
            }
            catch(ArgumentOutOfRangeException )
            {
                Console.WriteLine("The Age Should Be Between 1 and 175");
            }
            catch(Exception ex)
            {
                Console.WriteLine("The Aplication Works Fine you did something Wrong :)");
            }


            Console.ReadLine();
        }
    }
}
