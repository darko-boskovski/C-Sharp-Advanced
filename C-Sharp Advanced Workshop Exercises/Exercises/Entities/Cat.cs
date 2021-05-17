using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Entities
{
    public class Cat : Animal
    {

        public bool IsLazy { get; set; }

        public Cat()
        {

        }

        public Cat(bool islazy, string name, int age) : base(name, age)
        
        {
            IsLazy = islazy; 
        }

        public void Meow()
        {
            Console.WriteLine("Meow, Meow ...");
        }

        public override void Print()
        {
            Console.WriteLine($"This cat name is {Name}, and is {Age} old and it's {IsLazy} that is Lazy!");
         
        }
    }
}