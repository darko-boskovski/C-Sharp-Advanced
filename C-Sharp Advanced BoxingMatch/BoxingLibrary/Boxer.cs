using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingLibrary
{
    public class Boxer
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int TotalPoints { get; set; }
        public int PunchType { get; set; }

        public PunchStrength Strength { get; set; }
        public Agility Agility { get; set; }

        public Boxer() { }

        public Boxer(string name, int weight, int hitpoints, PunchStrength strength, Agility agility)
        {
            Name = name;
            Weight = weight;
            TotalPoints = hitpoints;
            Strength = strength;
            Agility = agility;
        }

        public void SetTypeOfPunch(int type)
        {
            PunchType = type;
        }

        public int StrengthPoints()
        {

            int result = PunchType switch
            {
                0 => Strength.Cross,
                1 => Strength.Jab,
                2 => Strength.Uppercut,
                3 => Strength.Hook,
                _ => 0
            };
            return result;

        }

        public int AgilityPoints(int points)
        {
            Random rnd = new Random();
            int result = PunchType switch
            {
                0 => points - rnd.Next(0, Agility.Cross),             
                1 => points - rnd.Next(0, Agility.Jab),
                2 => points - rnd.Next(0, Agility.Uppercut),
                3 => points - rnd.Next(0, Agility.Hook),
                _ => 0
            };
            return result;

        }



    }
}
