using System;
using System.IO;

namespace Exercise_Working_With_Files
{
    class Program
    {
        public static string Calculate(int numberOne, int numberTwo)
        {
            return $"{numberOne} + {numberTwo} = {numberOne + numberTwo}";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Doing Calculations and storing it in File");
            Console.WriteLine("-----------------------------------------");

            string currentDirectory = Directory.GetCurrentDirectory();


            string appPath = @"..\..\..\";

            string newFolderPath = appPath + @"Exercise\";

            string newFilePath = newFolderPath + @"calculations.txt";



            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Please enter the First Number:");
                bool boolOne = int.TryParse(Console.ReadLine(), out int numberOne);

                Console.WriteLine("Please enter the Second Number:");
                bool boolTwo = int.TryParse(Console.ReadLine(), out int numberTwo);

                if (!boolOne && !boolTwo) Console.WriteLine("Please Enter Numbers Only");

                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                    Console.WriteLine("The Directory was created!");
                }

                using (StreamWriter sw = new StreamWriter(newFilePath, true))
                {
                    sw.WriteLine("-----------------------------");
                    sw.WriteLine($"{DateTime.Now}");
                    sw.WriteLine($"The No: {i+1} Calculation is:");
                    sw.WriteLine(Calculate(numberOne, numberTwo));
                    sw.WriteLine("-----------------------------");

                }

                using (StreamReader sr = new StreamReader(newFilePath))
                {

                    string restContent = sr.ReadToEnd();
                    Console.WriteLine(restContent);
                }

            }

            if (File.Exists(newFilePath))
            {
                using (StreamWriter sw = new StreamWriter(newFilePath))
                {
                    sw.WriteLine("");
                    Console.WriteLine("The Content of the File was deleted!");
                    Console.WriteLine("Closing The Program!");
                }
            }


            Console.ReadLine();
        }
    }
}
