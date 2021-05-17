using System;

namespace Exercise_4
{
    class Program
    {

        public delegate bool TwoStringDelegate(string word1, string word2);
        static void Main(string[] args)
        {
            
            Func<string, string, bool> compareString = (word1, word2) => word1.Length > word2.Length;
            Func<string, string, bool> sameCharacterStart = (word1, word2) => word1[0] == word2[0];
            Func<string, string, bool> sameCharacterEnd = (word1, word2) => word1[word1.Length -1] == word2[word2.Length-1];

            TwoStringDelegate compareStringDelegate = new TwoStringDelegate(compareString);
            TwoStringDelegate startsOnSameDelegate = new TwoStringDelegate(compareString);
            TwoStringDelegate endsOnSameDelegate = new TwoStringDelegate(compareString);

            if(StringMagic("Pero", "Blazo", compareStringDelegate)) { Console.WriteLine($"The First word is longer then the second"); };  
             Console.WriteLine($"The Second word is longer then the first");
            Console.WriteLine("-------------------------------------------");
          


            if(StringMagic("Pero", "Blazo", startsOnSameDelegate)) { Console.WriteLine($"The Words Start on the Same Letter"); };
            { Console.WriteLine($"The Words Start on  diferent Letters"); }
            Console.WriteLine("-------------------------------------------");


            if (StringMagic("Pero", "Blazo", endsOnSameDelegate)) { Console.WriteLine($"The Words End on the Same Letter"); };
            { Console.WriteLine($"The Words End on  diferent Letters"); }
            Console.WriteLine("-------------------------------------------");


            Console.ReadLine();
        }

        public static bool StringMagic(string input1, string input2, TwoStringDelegate method)
        {
            Console.WriteLine($"{ input1} { input2}");
            Console.WriteLine(method(input1,input2));
            Console.WriteLine("----------------------");
            return method(input1, input2);

            
        }
     
    }
}
