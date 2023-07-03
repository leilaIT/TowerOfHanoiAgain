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
            Stack<string> tower0 = new Stack<string>();
            Stack<string> tower1 = new Stack<string>();
            Stack<string> tower2 = new Stack<string>();
            Stack<string>[] allTowers = new Stack<string>[3];

            Stack<string> fromT = new Stack<string>();
            Stack<string> toT = new Stack<string>();
            int level = 0;
            int diskNum = 0;
            int startDisk = 3;
            double pScore = 0;
            double baseNum = 2;
            string from = "";
            string to = "";
            bool yn = true;
            string input = "";
            string[] toSplit = new string[] { };
            int moves = 0;
            string mode = "";

            level = setupFile(level);
            if (level == 1)
            {
                diskNum = 3;
                mode = "Easy";
            }
            else if (level == 2)
            {
                diskNum = 5;
                mode = "Medium";
            }
            else if (level == 3)
            {
                diskNum = 7;
                mode = "Hard";
            }

            //perfect score
            pScore = Math.Pow(baseNum, diskNum) - 1;

            //putting disks to tower
            for (int x = diskNum - 1; x >= 0; x--)
            {
                tower0.Push(disks[x]);
            }

            history.Add("This is the move history for the last played game of " + mode + " difficulty.");

            Console.WriteLine("Welcome to Tower of Hanoi");
            Console.WriteLine("Current move count : {0}", moves);

            displayTower(tower0, "0");
            Console.WriteLine("\nTower 1");
            Console.WriteLine("\nTower 2");

            while (tower2.Count != diskNum)
            {
                Console.Write("\nWhat would you like your move to be?\n");
                Console.WriteLine("\n\nMove format is X-Y." +
                          "\nX is the number of the tower the disk will come from" +
                          "\nY is the number of the tower the disk will go to" +
                          "\nRules to remember:" +
                          "\nA larger disk cannot be on top of a smaller disk" +
                          "\nThe goal of this game is to transfer disks from tower 0 to tower 2");
                Console.SetCursorPosition(37, 12);
                
                while (true)
                {
                    input = Console.ReadLine();
                    toSplit = new string[] { };
                    toSplit = input.Split('-');
                    from = toSplit[0];
                    to = toSplit[1];

                    if (!input.Contains("-") || int.Parse(from) > 3 || int.Parse(from) < 0 || int.Parse(to) > 3 || int.Parse(to) < 0 || input.Length > 3)
                    {
                        Console.WriteLine("{0} is not an input. . . Press any key to continue. . .", input);
                        Console.ReadKey();
                        Console.SetCursorPosition(37, 12);
                        Console.Write("                          ");
                        Console.SetCursorPosition(0, 13);
                        Console.Write("                                                         ");
                        Console.SetCursorPosition(37, 12);
                    }
                    else
                        break;
                }

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

                displayTower(tower0, "0");
                displayTower(tower1, "1");
                displayTower(tower2, "2");

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
        static void displayTower(Stack<string> tower, string num)
        {
            Console.WriteLine();
            Console.WriteLine("Tower {0}", num);

            for (int x = 0; x < tower.Count; x++)
            {
                for (int y = 0; y <= tower.Count - x; y++)
                    Console.Write(" ");

                if (tower.ElementAt(x).Length == 3)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (tower.ElementAt(x).Length == 5)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (tower.ElementAt(x).Length == 7)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (tower.ElementAt(x).Length == 9)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else if (tower.ElementAt(x).Length == 11)
                    Console.ForegroundColor = ConsoleColor.Magenta;
                else if (tower.ElementAt(x).Length == 13)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (tower.ElementAt(x).Length == 15)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine(tower.ElementAt(x));
                Console.ResetColor();
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