using System;
using System.Collections.Generic;

namespace Day_Of_The_Week
{
    class Program
    {   


        static void Main(string[] args)
        {
            Console.WriteLine("------Non Working Day Checker------");

            List <string> daysOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            List<string> nonWorkingDays = new List<string>() { "1,January", "7,January", "20,April", "1,May", "25,May", "3,August", "8,September", "12,October", "23,October", "8,December" };

            bool runApp = true;
            while (runApp)
            {
                Console.WriteLine("-----------------------");
                Console.Write("Enter year: ");
                int year = Int32.Parse(Console.ReadLine());
                Console.Write("Enter month: ");
                int month = Int32.Parse(Console.ReadLine());
                Console.Write("Enter day: ");
                int day = Int32.Parse(Console.ReadLine());

                DateTime dateValue = new DateTime(year, month, day);


                if (dateValue.ToString("dddd") == "Saturday" || dateValue.ToString("dddd") == "Sunday")
                {
                    Console.WriteLine($"{dateValue.ToString("dddd")} is a non Working Day!");

                }
                else if (nonWorkingDays.Contains(dateValue.ToString("d,MMMM")))
                {
                    Console.WriteLine($"{dateValue.ToString("d,MMMM")} is a non Working Day!");

                }
                else
                {
                    Console.WriteLine($"{dateValue}Is a Working Day");
                }
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Would you like to check another date?");
                Console.WriteLine($"*) YES \n*) NO ");

                string userChoice = Console.ReadLine();

                bool tryParse = int.TryParse(userChoice, out int someNumber);

                if (tryParse)
                {
                    Console.WriteLine("Please Enter Letters Only");
                    continue;
                }
 
                
                switch(userChoice.ToUpper())
                {
                    case "YES":
                        continue;
                    case "NO":
                        Console.WriteLine("You will now Exit the App!");
                        runApp =false;
                        continue;
                    default:
                        Console.WriteLine("Please Enter Yes or No only!");
                        break;
                }
                    

            }
            Console.ReadLine();


        }
    }
}
