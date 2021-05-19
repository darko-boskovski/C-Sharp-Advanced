using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2
{
    public static class IsEven
    {
        public static bool IsEvenOrNot(this int integer)
        {
            if (integer % 2 == 0) return true;

            return false;

        }
    }
}
