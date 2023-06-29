using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoiAgain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //3 stack ver
            ////MUST FIX:
            //disk generation
            //tower alignment
            //move history

            List<string> list = new List<string>() { "===", "=====", "=======", "=========", "===========", "=============", "===============" };
            Stack<string> tower0 = new Stack<string>();
            Stack<string> tower1 = new Stack<string>();
            Stack<string> tower2 = new Stack<string>();

            Stack<string> fromT = new Stack<string>();
            Stack<string> toT = new Stack<string>();
            int diskNum = 0;
            int startDisk = 3;
            string from = "";
            string to = "";
            bool yn = true;
            string input = "";
            string[] toSplit = new string[] { };
            int moves = 0;
            int pScore = 0;

            //no setup.ini muna
            diskNum = 3;
            if(diskNum == 3)
            {
                pScore = 7;
            }
            else if (diskNum == 5)
            {
                pScore = 31;
            }
            else if (diskNum == 7)
            {
                pScore = 127;
            }

            //putting disks to tower
            for (int x = diskNum - 1; x >= 0; x--)
            {
                tower0.Push(list[x]);
            }

            initializeTower(moves, diskNum, tower0);

            while (tower2.Count != diskNum)
            {
                rules();
                
                input = Console.ReadLine();
                toSplit = new string[] { };
                toSplit = input.Split('-');
                from = toSplit[0];
                to = toSplit[1];

                Console.Clear();

                if (from == "0")
                    fromT = tower0;
                else if (from == "1")
                    fromT = tower1;
                else if (from == "2")
                    fromT = tower2;

                if (to == "0")
                    toT = tower0;
                else if (to == "1")
                    toT = tower1;
                else if (to == "2")
                    toT = tower2;

                if(toT.Count == 0)
                {
                    diskMoving(fromT, toT);
                    moves++;
                }
                else
                {
                    //checks if from disk is larger than to disk
                    if (fromT.ElementAt(0).Length < toT.ElementAt(0).Length)
                    {
                        diskMoving(fromT, toT);
                        moves++;
                    }
                }

                displayTower(moves, diskNum, tower0, tower1, tower2);
            }

            if (tower2.Count == diskNum)
            {
                Console.WriteLine("Congratulations! You finished the game with {0} moves!" +
                                    "\nThe perfect score is {1}.", moves, pScore);
                if(moves == pScore)
                    Console.WriteLine("Wow! You finished with a perfect score of 100!", moves);
                
                rules();
            }

            Console.ReadKey();
        }

        static void rules ()
        {
            Console.Write("\nWhat would you like your move to be?");
            Console.WriteLine("\n\n\nMove format is X-Y." +
                          "\nX is the number of the tower the disk will come from" +
                          "\nY is the number of the tower the disk will go to" +
                          "\nRules to remember:" +
                          "\nA larger disk cannot be on top of a smaller disk" +
                          "\nThe goal of this game is to transfer disks from tower 0 to tower 2");
        }
        static void diskMoving (Stack<string> fromT, Stack<string> toT)
        {
            //moving of disks
            toT.Push(fromT.ElementAt(0)); //to
            fromT.Pop(); //from
        }
        static Stack<string> initializeTower(int moves, int diskNum, Stack<string> tower0)
        {
            Console.WriteLine("Welcome to Tower of Hanoi");
            Console.WriteLine("Current move count : {0}", moves);
            Console.WriteLine();

            Console.WriteLine("Tower 0");
            for (int x = 0; x < diskNum; x++)
            {
                for (int y = 1; y <= diskNum - x; y++)
                    Console.Write(" ");

                if (tower0.ElementAt(x).Length == 3)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (tower0.ElementAt(x).Length == 5)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (tower0.ElementAt(x).Length == 7)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (tower0.ElementAt(x).Length == 9)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else if (tower0.ElementAt(x).Length == 11)
                    Console.ForegroundColor = ConsoleColor.Magenta;
                else if (tower0.ElementAt(x).Length == 13)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (tower0.ElementAt(x).Length == 15)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine(tower0.ElementAt(x));
                Console.ResetColor();
            }
            Console.WriteLine("\nTower 1");
            Console.WriteLine("\nTower 2");

            return tower0;
        }
        static Stack<string> displayTower(int moves, int diskNum, Stack<string> tower0, Stack<string> tower1, Stack<string> tower2)
        {
            Console.WriteLine("Welcome to Tower of Hanoi");
            Console.WriteLine("Current move count : {0}", moves);
            Console.WriteLine();

            Console.WriteLine("Tower 0");
            for (int x = 0; x < tower0.Count; x++)
            {
                for (int y = 1; y <= tower0.Count - x; y++)
                    Console.Write(" ");

                if (tower0.ElementAt(x).Length == 3)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (tower0.ElementAt(x).Length == 5)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (tower0.ElementAt(x).Length == 7)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (tower0.ElementAt(x).Length == 9)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else if (tower0.ElementAt(x).Length == 11)
                    Console.ForegroundColor = ConsoleColor.Magenta;
                else if (tower0.ElementAt(x).Length == 13)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (tower0.ElementAt(x).Length == 15)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine(tower0.ElementAt(x));
                Console.ResetColor();
            }

            Console.WriteLine("\nTower 1");
            for (int x = 0; x < tower1.Count; x++)
            {
                for (int y = 1; y <= tower1.Count - x; y++)
                    Console.Write(" ");

                if (tower1.ElementAt(x).Length == 3)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (tower1.ElementAt(x).Length == 5)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (tower1.ElementAt(x).Length == 7)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (tower1.ElementAt(x).Length == 9)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else if (tower1.ElementAt(x).Length == 11)
                    Console.ForegroundColor = ConsoleColor.Magenta;
                else if (tower1.ElementAt(x).Length == 13)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (tower1.ElementAt(x).Length == 15)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine(tower1.ElementAt(x));
                Console.ResetColor();
            }

            Console.WriteLine("\nTower 2");
            for (int x = 0; x < tower2.Count; x++)
            {
                for (int y = 1; y <= tower2.Count - x; y++)
                    Console.Write(" ");

                if (tower2.ElementAt(x).Length == 3)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (tower2.ElementAt(x).Length == 5)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (tower2.ElementAt(x).Length == 7)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (tower2.ElementAt(x).Length == 9)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else if (tower2.ElementAt(x).Length == 11)
                    Console.ForegroundColor = ConsoleColor.Magenta;
                else if (tower2.ElementAt(x).Length == 13)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (tower2.ElementAt(x).Length == 15)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine(tower2.ElementAt(x));
                Console.ResetColor();
            }

            return tower1;
        }
    }
}