using System;
using System.Collections.Generic;
using System.Text;

namespace EventsExercise.Entities
{
    public class Subscriber1
    {
        public string Name { get; set; }
        public Subscriber1()
        {

        }
        public Subscriber1(string name)
        {
            Name = name;
        }

        public void Facebook(string message)
        {
            Console.WriteLine($"{message} - {Name}: I've got the message through Facebook");

        }
    }
}
