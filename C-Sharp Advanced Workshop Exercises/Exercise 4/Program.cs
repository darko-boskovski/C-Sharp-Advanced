using System;

namespace Exercise_4
{
    class Program
    {

        public delegate bool TwoStringDelegate(string word1, string word2);
        static void Main(string[] args)
        {

          


            if (StringMagic("Pero", "Blazo",(word1, word2) => word1.Length > word2.Length)) { Console.WriteLine($"The First word is longer then the second"); }
            else { Console.WriteLine($"The Second word is longer then the first"); }
            Console.WriteLine("-------------------------------------------");



            if (StringMagic("Pero", "Blazo", (word1, word2) => word1[0] == word2[0])) { Console.WriteLine($"The Words Start on the Same Letter"); }
            else { Console.WriteLine($"The Words Start on diferent Letters"); }
            Console.WriteLine("-------------------------------------------");


            if (StringMagic("Pero", "Blazo", (word1, word2) => word1.Substring(word1.Length - 1) == word2.Substring(word2.Length - 1))) { Console.WriteLine($"The Words End on the Same Letter"); }
            else { Console.Write($"The Words End on  diferent Letters"); };
            Console.WriteLine("-------------------------------------------");

            Console.ReadLine();
        }

        public static bool StringMagic(string input1, string input2, TwoStringDelegate method)
        {
            Console.Write($"First word:'{input1}', Second word:'{input2}': ");
          
            return method(input1, input2);


        }

    }
}
