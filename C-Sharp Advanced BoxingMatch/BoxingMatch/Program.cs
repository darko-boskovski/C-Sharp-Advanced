using BoxingLibrary;
using System;

namespace BoxingMatch
{
    class Program
    {

        private static BoxMatch _boxMatch = new BoxMatch();
       
        static void Main(string[] args)
        {
            Display display = new Display();
            Boxer tysonFury = new Boxer("Tyson Fury", 124, 1000, new PunchStrength(20, 10, 25, 20), new Agility(26, 26, 16, 21));
            Boxer andyRuizJr = new Boxer("Andy Ruiz.Jr", 128, 1000, new PunchStrength(26, 16, 21, 16), new Agility(15, 15, 30, 15));  

            Console.WriteLine("The Boxing Mathch is about to start!");

            _boxMatch.Game(tysonFury, andyRuizJr,200,display);

            Console.ReadLine();
        }
    }
}
