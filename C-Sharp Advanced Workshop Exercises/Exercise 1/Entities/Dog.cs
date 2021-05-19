using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Entities
{
    public class Dog : Animal
    {

        public string Race { get; set; }

        public Dog()
        {

        }

        public Dog(string race, string name, int age) : base(name, age)

        {
            Race = race;
        }


        public void Bark()
        {
            Console.WriteLine("Bark, Bark ...");
        }

        public override void Print()
        {
            Console.WriteLine($"This dog name is {Name}, its race is {Race} and its {Age} old!");
          
        }
    }
}