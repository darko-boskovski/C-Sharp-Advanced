using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Entities
{
    public abstract class Animal
    {
        public string Name { get; set; }

        private int _age;

        public Animal()
        {

        }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Mi Vrakja Stack Overflow ... 

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0 || value > 175)

                    throw new ArgumentOutOfRangeException();
                    _age = value;
            }
        }

        public abstract void Print();
    }
}
