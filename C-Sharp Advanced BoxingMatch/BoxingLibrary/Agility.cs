using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingLibrary
{
    public class Agility
    {
        public int Cross { get; set; }
        public int Jab { get; set; }
        public int Uppercut { get; set; }
        public int Hook { get; set; }

        public Agility(int cross, int jab, int uppercut, int hook)
        {
            Cross = cross;
            Jab = jab;
            Uppercut = uppercut;
            Hook = hook;
        }
    }
}
