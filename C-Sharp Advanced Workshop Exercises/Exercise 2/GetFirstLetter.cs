using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2
{
    public static class GetFirstLetter
    {
        public static string GetFirst(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.Substring(0,1);
        }
    }


}
