using EventsExercise.Entities;
using Exercise_5.Entities;
using System;

namespace Exercise_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Trainer kristina = new Trainer();

            Student nikola = new Student("Nikola");
            Student marija = new Student("Marija");
            Subscriber2 jana = new Subscriber2("Jana");
            Subscriber2 ivan = new Subscriber2("Ivan");
            Subscriber3 gligor = new Subscriber3("Gligor");
            Subscriber3 pero = new Subscriber3("Pero");

            kristina.EventHandler += nikola.Hear;
            kristina.EventHandler += marija.Hear;
            kristina.EventHandler += jana.Hear;
            kristina.EventHandler += ivan.Hear;
            kristina.EventHandler += gligor.Hear;
            kristina.EventHandler += pero.Hear;

            //kristina.SendMessage("Gligor");
            //kristina.SendMessage("Nekoj");
            //kristina.SendMessage("Jana");
            //kristina.SendMessage("Ivan");
            //kristina.SendMessage("Pero");
            //kristina.SendMessage("Nikola");


            kristina.ComposeMessage(" Pance Manaskov", 4, "Decki vo Sreda Workshop!");


            Console.ReadLine();
        }
    }
}

