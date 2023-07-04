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
            List<string> disks = new List<string>() { "===", "=====", "=======", "=========", "===========", "=============", "===============" };
            List<string> history = new List<string>();

            Stack<string>[] allTowers = new Stack<string>[3];
            Stack<string> tower0 = new Stack<string>();
            Stack<string> tower1 = new Stack<string>();
            Stack<string> tower2 = new Stack<string>();

            Stack<string> fromT = new Stack<string>();
            Stack<string> toT = new Stack<string>();
            int level = 0;
            int diskNum = 0;
            double pScore = 0;
            double baseNum = 2;
            string from = "";
            string to = "";
            string input = "";
            string[] toSplit = new string[] { };
            int moves = 0;
            string mode = "";
            int a = 0;

            level = setupFile(level);
            if (level == 1)
            {
                a = 6;
                diskNum = 3;
                mode = "Easy";
            }
            else if (level == 2)
            {
                a = 8;
                diskNum = 5;
                mode = "Medium";
            }
            else if (level == 3)
            {
                a = 10;
                diskNum = 7;
                mode = "Hard";
            }

            history.Add("This is the move history for the last played game of " + mode + " difficulty.");

            //perfect score
            pScore = Math.Pow(baseNum, diskNum) - 1;

            allTowers[0] = tower0;
            allTowers[1] = tower1;
            allTowers[2] = tower2;
            
            //putting disks to tower
            for (int x = diskNum - 1; x >= 0; x--)
            {
                allTowers[0].Push(disks[x]);
            }

            Console.WriteLine("Welcome to Tower of Hanoi");
            Console.WriteLine("Current move count : {0}", moves);

            displayTower(allTowers, disks, diskNum);

            while (allTowers[2].Count != diskNum)
            {
                Console.Write("\nWhat would you like your move to be?\n");
                Console.WriteLine("\n\nMove format is X-Y." +
                          "\nX is the number of the tower the disk will come from" +
                          "\nY is the number of the tower the disk will go to" +
                          "\nRules to remember:" +
                          "\nA larger disk cannot be on top of a smaller disk" +
                          "\nThe goal of this game is to transfer disks from tower 0 to tower 2");
                Console.SetCursorPosition(37, a);
                
                while (true)
                {
                    input = Console.ReadLine();
                    toSplit = new string[] { };
                    toSplit = input.Split('-');
                    from = toSplit[0];
                    if(input.Contains("-"))
                        to = toSplit[1];

                    if (!input.Contains("-") || int.Parse(from) > 3 || int.Parse(from) < 0 || int.Parse(to) > 3 || int.Parse(to) < 0 || input.Length > 3)
                    {
                        
                        Console.WriteLine("{0} is not an input. . . Press any key to continue. . .", input);
                        Console.ReadKey();
                        Console.SetCursorPosition(37, a);
                        Console.Write(new string(' ', 100));
                        Console.SetCursorPosition(0, a + 1);
                        Console.Write(new string(' ', 200));
                        Console.SetCursorPosition(37, a);
                    }
                    else
                        break;
                }

                Console.Clear();

                if (from == "0")
                    fromT = allTowers[0];
                else if (from == "1")
                    fromT = allTowers[1];
                else if (from == "2")
                    fromT = allTowers[2];

                if (to == "0")
                    toT = allTowers[0];
                else if (to == "1")
                    toT = allTowers[1];
                else if (to == "2")
                    toT = allTowers[2];

                if(toT.Count == 0)
                {
                    diskMoving(fromT, toT);
                    history.Add("Move disk from tower " + from + " to tower " + to);
                    moves++;
                }
                else
                {
                    //checks if from disk is larger than to disk
                    if (fromT.ElementAt(0).Length < toT.ElementAt(0).Length)
                    {
                        diskMoving(fromT, toT);
                        history.Add("Move disk from tower " + from + " to tower " + to);
                        moves++;
                    }
                }
                Console.WriteLine("Welcome to Tower of Hanoi");
                Console.WriteLine("Current move count : {0}", moves);

                displayTower(allTowers, disks, diskNum);
            }

            if (tower2.Count == diskNum)
            {
                Console.WriteLine("\nCongratulations! You finished the game with {0} moves!" +
                                    "\nThe perfect score is {1}.", moves, pScore);
                history.Add("You finished the game with " + moves + " moves.");
                history.Add("The perfect score is " + pScore);

                if(moves == pScore)
                {
                    Console.WriteLine("Wow! You finished with a perfect score of 100!", moves);
                    history.Add("You scored 100%");
                }

                Console.WriteLine("\n\nMove format is X-Y." +
                          "\nX is the number of the tower the disk will come from" +
                          "\nY is the number of the tower the disk will go to" +
                          "\nRules to remember:" +
                          "\nA larger disk cannot be on top of a smaller disk" +
                          "\nThe goal of this game is to transfer disks from tower 0 to tower 2");
                moveHistory(history);
            }

            Console.ReadKey();
        }
        static int setupFile(int level)
        {
            string fileName = "setup.ini";
            string line = "";
            using (StreamReader sr = new StreamReader(fileName + ".ini"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    level = int.Parse(line);
                }
            }

            return level;
        }
        static void displayTower(Stack<string>[] allTowers, List<string>disks, int diskNum)
        {
            int space = 0;
            int diskMax = disks[diskNum - 1].Length;
          
            for (int i = 0; i < diskNum; i++)
            {
                foreach (Stack<string> tower in allTowers)
                {
                    if (tower.Count > i)
                    {
                        space = (diskMax - tower.ElementAt(i).Length) / 2;

                        if (tower.ElementAt(i).Length == 3)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else if (tower.ElementAt(i).Length == 5)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else if (tower.ElementAt(i).Length == 7)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else if (tower.ElementAt(i).Length == 9)
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        else if (tower.ElementAt(i).Length == 11)
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        else if (tower.ElementAt(i).Length == 13)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        else if (tower.ElementAt(i).Length == 15)
                            Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.Write(new string(' ', space));

                        Console.Write(tower.ElementAt(i));
                        Console.ResetColor();

                        Console.Write(new string(' ', space));
                        Console.Write("|");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(disks[diskNum - 1]);
                        Console.ResetColor();
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
            }
        }
        static void diskMoving(Stack<string> fromT, Stack<string> toT)
        {
            //moving of disks
            toT.Push(fromT.ElementAt(0)); //to
            fromT.Pop(); //from
        }
        static void moveHistory (List<string> history)
        {
            history.Add(" ");
            string filename = "History__";
            using (StreamWriter sw = new StreamWriter(filename + ".txt"))
            {
                foreach (string line in history)
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
}