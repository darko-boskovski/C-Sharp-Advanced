using System;
using System.Collections.Generic;

namespace Rock_paper_scisors
{

    class Program
    {
        public static void ShowStats(int playerWins, int computerWins, int userPercentage, int pcPercentage, int totalGamesPlayed, int tieGame)
        {
            userPercentage = (int)Math.Round((double)(100 * playerWins) / (totalGamesPlayed - tieGame));

            pcPercentage = (int)Math.Round((double)(100 * computerWins) / (totalGamesPlayed - tieGame));

            if (userPercentage < 0) userPercentage = 0;
            if (pcPercentage < 0) pcPercentage = 0;


            Console.WriteLine("------------------------");
            Console.WriteLine($"The Score is User:{playerWins} wins, : Computer {computerWins} wins,");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"User winign percentage {userPercentage}%, Computer wining percentage: {pcPercentage}%");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Total Games Played {totalGamesPlayed}");
            Console.WriteLine("-----------------------");
        }

        static void Main(string[] args)
        {



            bool playGame = true;
            Console.WriteLine("Welcome to ROCK PAPER SCISSORS Game");
            Console.WriteLine("-----------------------------------");

            int userChoice = 0;
            int playerWins = 0;
            int computerWins = 0;

            int totalGamesPlayed = 0;
            string user = "";
            int userPercentage = 0;
            int pcPercentage = 0;
            int tieGame = 0;

            List<String> choices = new List<String> () { "PAPER", "ROCK", "SCISSOR" };

            while (playGame)
            {
                totalGamesPlayed++;

                Console.WriteLine("Please Enter Your Choice to PLAY! \n----------------------------------- \n1->ROCK\n2->PAPER\n3->SCISSOR \n\n\n------------------\nChoose 4->EXIT");
                Console.WriteLine("------------------");


                Random random = new Random();
                int n = random.Next(0, 3);
                Console.WriteLine("------------------");
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("------------------");
                try
                {
                  userChoice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Please Enter Numbers Only!");
                    Console.WriteLine("--------------------------");
                    continue;
                }
               


                switch (userChoice)
                {


                    case 1:
                        Console.Clear();
                        user = "ROCK";
                        break;
                    case 2:
                        Console.Clear();
                        user = "PAPER";
                        break;
                    case 3:
                        Console.Clear();
                        user = "SCISSOR";
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("You Will Now Exit!");
                        playGame = false;
                        continue;
                    default:
                        Console.Clear();
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Please Choose Between 1 and 4 only!");
                        Console.WriteLine("-----------------------------------");
                        continue;
                }
                

                if (user == "ROCK" && choices[n] == "SCISSOR")
                {
                    
                    playerWins += 1;
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine($"The User Chose '{user}', the Computer Chose '{choices[n]}'");
                    Console.WriteLine("---------");
                    Console.WriteLine("User wins");
                    Console.WriteLine("---------");

                    ShowStats(playerWins,computerWins,userPercentage,pcPercentage,totalGamesPlayed,tieGame);

                }
                else if (user == "ROCK" && choices[n] == "PAPER")
                {
                  
                    computerWins += 1;
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine($"The User Chose '{user}', the Computer Chose '{choices[n]}'");
                    Console.WriteLine("---------");
                    Console.WriteLine("User wins");
                    Console.WriteLine("---------");
                    ShowStats(playerWins, computerWins, userPercentage, pcPercentage, totalGamesPlayed, tieGame);

                }
                else if (user == "PAPER" && choices[n] == "ROCK")
                {
                    
                    playerWins += 1;
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine($"The User Chose '{user}', the Computer Chose '{choices[n]}'");
                    Console.WriteLine("---------");
                    Console.WriteLine("User wins");
                    Console.WriteLine("---------");
                    ShowStats(playerWins, computerWins, userPercentage, pcPercentage, totalGamesPlayed, tieGame);

                }
                else if (user == "PAPER" && choices[n] == "SCISSOR")
                {
                   
                    computerWins += 1;
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine($"The User Chose '{user}', the Computer Chose '{choices[n]}'");
                    Console.WriteLine("-------------");
                    Console.WriteLine("Computer Wins");
                    Console.WriteLine("---------");
                    ShowStats(playerWins, computerWins, userPercentage, pcPercentage, totalGamesPlayed, tieGame);

                }
                else if (user == "SCISSOR" && choices[n] == "ROCK")
                {
                   
                    computerWins += 1;
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine($"The User Chose '{user}', the Computer Chose '{choices[n]}'");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("Computer Wins");
                    Console.WriteLine("---------");
                    ShowStats(playerWins, computerWins, userPercentage, pcPercentage, totalGamesPlayed, tieGame);


                }
                else if (user == "SCISSOR" && choices[n] == "PAPER")
                {
                  
                    playerWins += 1;
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine($"The User Chose '{user}', the Computer Chose '{choices[n]}'");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("User wins");
                    Console.WriteLine("---------");
                    ShowStats(playerWins, computerWins, userPercentage, pcPercentage, totalGamesPlayed, tieGame);

                }
                else
                {
                   tieGame++;


                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Same choices it's a Tie!");
                    ShowStats(playerWins, computerWins, userPercentage, pcPercentage, totalGamesPlayed, tieGame);

                }             
            }

            Console.ReadLine();
        }
    }
}



