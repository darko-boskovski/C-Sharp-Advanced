using System;
using System.Collections.Generic;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
          


            string text = "bla bla bla bla";

            int numberOne = 200;
            int numberTwo = 3;

            List<int> numList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; 

            Console.WriteLine(text.GetFirst());

            Console.WriteLine(text.GetLast());

            Console.WriteLine(numberOne.IsEvenOrNot());

            Console.WriteLine(numberTwo.IsEvenOrNot());

            var firstItemList =  numList.FindFirstItems(3);
            firstItemList.ForEach(x => Console.WriteLine(x));




            Console.ReadLine();
        }
    }
}
