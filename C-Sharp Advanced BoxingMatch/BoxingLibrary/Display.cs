using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingLibrary
{
    public class Display
    {
        public int PunchType { get; set; }
        public string PunchTypeString { get; set; }
        public HitType HitType { get; set; }
        public int PointsHitType { get; set; }
        protected int PunchVal { get; set; }

        public void SetType(int type)
        {
            PunchType = type;
        }
        public void PunchValue(int value)
        {
            PunchVal = value;
        }

        public void TypeOfPunch()
        {
            switch (PunchType)
            {
                case 0: PunchTypeString = "Cross"; break;
                case 1: PunchTypeString = "Jab"; break;
                case 2: PunchTypeString = "Uppercut"; break;
                case 3: PunchTypeString = "Hook"; break;
            }
        }

        public void HitOrMiss(HitType isHit)
        {
            HitType = isHit;
        }

        public void Print(Boxer punchingBoxer, Boxer receivingBoxer)
        {
                if(HitType == HitType.Hit)
            {
                TypeOfPunch();

                Console.WriteLine("It's a Hit.");
                Console.WriteLine("---------------");
                Console.WriteLine($"{receivingBoxer.Name} has been hit by {PunchTypeString} for {PunchVal} damage, " +
                   $"and now he has {receivingBoxer.TotalPoints} hitpoints");
                Console.WriteLine();
                Console.WriteLine($"{punchingBoxer.Name} : {receivingBoxer.Name}");
                Console.WriteLine($"{punchingBoxer.TotalPoints} : {receivingBoxer.TotalPoints}");
                Console.WriteLine("---------------------------------------------");
            }

            if (HitType == HitType.Miss)
            {
                Console.WriteLine("It's a Miss. :(");
                Console.WriteLine("---------------");
                Console.WriteLine($"{punchingBoxer.Name} : {receivingBoxer.Name}");
                Console.WriteLine($"{punchingBoxer.TotalPoints} points : {receivingBoxer.TotalPoints} points");
                Console.WriteLine("---------------------------------------------");
            }
        }

    }
}
