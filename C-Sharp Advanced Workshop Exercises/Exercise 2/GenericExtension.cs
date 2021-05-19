using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise_2
{
    public static class GenericExtension
    {
        public static List<T> GetFirstNitems<T>(this List<T> list, int index)
        {
            if (list == null) Console.WriteLine("Cannot take any elements out of empty list");
          return list.Take(index).ToList();
          
        }

    }
}
