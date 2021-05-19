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

            Subscriber1 nikola = new Subscriber1("Nikola");
            Subscriber1 marija = new Subscriber1("Marija");
            Subscriber2 jana = new Subscriber2("Jana");
            Subscriber2 ivan = new Subscriber2("Ivan");
            Subscriber3 gligor = new Subscriber3("Gligor");
            Subscriber3 pero = new Subscriber3("Pero");

            kristina.EventHandler += nikola.Facebook;
            kristina.EventHandler += marija.Facebook;
            kristina.EventHandler += jana.Mail;
            kristina.EventHandler += ivan.Mail;
            kristina.EventHandler += gligor.SMS;
            kristina.EventHandler += pero.SMS;

            kristina.SendMessage("'Test message!'");
            kristina.ComposeMessage(" Pance Manaskov", 4, "Decki vo Sreda Workshop!");


            Console.ReadLine();
        }
    }
}

