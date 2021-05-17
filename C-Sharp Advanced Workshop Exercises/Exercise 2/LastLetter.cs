using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2
{
    public static class LastLetter
    {

        public static string GetLast(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.Substring(str.Length - 1);
        }
    }
}

