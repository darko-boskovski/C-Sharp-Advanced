using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Entities
{
    public class Bird : Animal
    {
        public bool IsWild { get; set; }

        public Bird()
        {

        }

        public Bird(bool isWild, string name, int age) : base(name, age)

        {
            IsWild = isWild;
        }

        public void FlySouth()
        {
           Console.WriteLine(IsWild?"This Bird is flying south": "This is a domesticated bird");
        }

        public override void Print()
        {
            Console.WriteLine($"This bird name is {Name}, and is {Age} old and it's {IsWild}! that is a wild bird");
          
        }
    }
}
