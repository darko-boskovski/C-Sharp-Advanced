using System;
using System.Collections.Generic;
using System.Text;

namespace EventsExercise.Entities
{
    public class Student
    {
        public string Name { get; set; }
        public Student()
        {

        }
        public Student(string name)
        {
            Name = name;
        }

        public void Hear(string name)
        {
                 Console.WriteLine("I've got the message through FaceBook");
  
        }
    }
}
