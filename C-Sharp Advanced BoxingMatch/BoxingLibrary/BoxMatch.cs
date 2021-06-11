using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BoxingLibrary
{

    public delegate void PunchThrow(int punchValue);
    public delegate void HitOrMiss(HitType isHit);
    public delegate void PointsPunch(int points);
    public class BoxMatch
    {
        public event PunchThrow PunchEventHandler;
        public event HitOrMiss HitOrMissEventHandler;
        public event PointsPunch PointsPunchEventHandler;

        public int NumeberOfPunches { get; set; }
        public HitType IsHit { get; set; }


        public void Game(Boxer boxerOne, Boxer boxerTwo, int times, Display display)
        {
            PunchEventHandler += boxerOne.SetTypeOfPunch;
            PunchEventHandler += boxerTwo.SetTypeOfPunch;
            PunchEventHandler += display.SetType;
            HitOrMissEventHandler += display.HitOrMiss;
            PointsPunchEventHandler += display.PunchValue;

            int go = 1;
            int whenBreak = 0;
            bool playGame = true;

            while (playGame)
            {
                if (whenBreak == times)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Thw Winner is {Winner(boxerOne, boxerTwo)}");
                    break;
                }
                Random rnd = new Random();
                int myRandom = rnd.Next(0, 4);

                PunchEventHandler?.Invoke(myRandom);

                if (go == 1)
                {
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.Green;
                    int pointsAgility = boxerTwo.AgilityPoints(boxerOne.StrengthPoints());

                    if (pointsAgility > 0)
                    {
                        IsHit = HitType.Hit;
                        HitOrMissEventHandler?.Invoke(IsHit);
                        PointsPunchEventHandler?.Invoke(pointsAgility);
                        boxerTwo.TotalPoints = boxerTwo.TotalPoints - pointsAgility;
                        display.Print(boxerOne, boxerTwo);

                        if (boxerTwo.TotalPoints <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Thw Winner is {Winner(boxerTwo, boxerOne)}");
                            break;
                        }
                    }
                    else
                    {
                        IsHit = HitType.Miss;
                        HitOrMissEventHandler?.Invoke(IsHit);
                        display.Print(boxerOne, boxerTwo);
                    }
                    whenBreak++;
                    go = 2;

                }

                if (go == 2)
                {
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    int pointsAgility = boxerOne.AgilityPoints(boxerTwo.StrengthPoints());

                    if (pointsAgility > 0)
                    {
                        IsHit = HitType.Hit;
                        HitOrMissEventHandler?.Invoke(IsHit);
                        PointsPunchEventHandler?.Invoke(pointsAgility);
                        boxerOne.TotalPoints = boxerOne.TotalPoints - pointsAgility;
                        display.Print(boxerTwo, boxerOne);

                        if (boxerOne.TotalPoints <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Thw Winner is {Winner(boxerOne, boxerTwo)}");
                            break;
                        }
                    }
                    else
                    {
                        IsHit = HitType.Miss;
                        HitOrMissEventHandler?.Invoke(IsHit);
                        display.Print(boxerTwo, boxerOne);
                    }
                    whenBreak++;
                    go = 1;
                }

            }

        }

        public string Winner(Boxer boxerOne, Boxer boxerTwo)
        {
            if (boxerOne.TotalPoints > boxerTwo.TotalPoints) return boxerOne.Name;
            return boxerTwo.Name;

        }
    }
}
