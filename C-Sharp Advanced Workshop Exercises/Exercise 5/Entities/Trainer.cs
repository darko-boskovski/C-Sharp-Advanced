using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EventsExercise.Entities
{
    public delegate void AnnounceMarkDelegate(string message);
    public class Trainer
    {
        public event AnnounceMarkDelegate EventHandler;


        public string Name { get; set; }

        public int GroupNumber { get; set; }






        public void SendMessage(string message)
        {
            EventHandler?.Invoke(message);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Subscriber{message}");

        }
        public void ComposeMessage(string trainerName, int groupNumber, string message)
        {


            Thread.Sleep(3000);

            SendMessage($"{trainerName} informs G{groupNumber}: {message}");

        }

    }
}
