﻿using System;
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

            Console.WriteLine($"The First Letter is {text.GetFirst()}");

            Console.WriteLine($"The First Letter is {text.GetLast()}");

            Console.WriteLine($"The number {numberOne} is even: {numberOne.IsEvenOrNot()}");

            Console.WriteLine($"The number {numberTwo} is even: {numberTwo.IsEvenOrNot()}");

            var firstItemList =  numList.FindFirstItems(3);
            Console.WriteLine($"The first N ( inputs ) items are");
            firstItemList.ForEach(x => Console.WriteLine(x));




            Console.ReadLine();
        }
    }
}
