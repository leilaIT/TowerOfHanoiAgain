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
            //disk colors
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
            int moves = 0;
            int pScore = 0;

            //no setup.ini muna
            diskNum = 3;
            if(diskNum == 3)
            {
                pScore = 7;
            }

            for (int x = diskNum - 1; x >= 0; x--)
            {
                tower0.Push(list[x]);
            }

            initializeTower(moves, diskNum, tower0);

            while (tower2.Count != 3)
            {
                Console.Write("\nWhat would you like your move to be?");
                Console.WriteLine("\n\n\nMove format is X-Y." +
                              "\nX is the number of the tower the disk will come from" +
                              "\nY is the number of the tower the disk will go to" +
                              "\nRules to remember:" +
                              "\nA larger disk cannot be on top of a smaller disk" +
                              "\nThe goal of this game is to transfer disks from tower 0 to tower 2");

                from = Console.ReadLine();
                to = Console.ReadLine();
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

                //moving of disks
                toT.Push(fromT.ElementAt(0)); //to
                fromT.Pop(); //from
                moves++;

                displayTower(moves, diskNum, tower0, tower1, tower2);
            }

            if (tower2.Count == 3)
            {
                Console.WriteLine("Congratulations! You finished the game with 7 moves!" +
                                    "\nThe perfect score is {0}" +
                                    "\nWow! You finished with a score of {1}", pScore, moves);
            }

            Console.ReadKey();
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

                Console.WriteLine(tower0.ElementAt(x));
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

                Console.WriteLine(tower0.ElementAt(x));
            }

            Console.WriteLine("\nTower 1");
            for (int x = 0; x < tower1.Count; x++)
            {
                for (int y = 1; y <= tower1.Count - x; y++)
                    Console.Write(" ");

                Console.WriteLine(tower1.ElementAt(x));
            }

            Console.WriteLine("\nTower 2");
            for (int x = 0; x < tower2.Count; x++)
            {
                for (int y = 1; y <= tower2.Count - x; y++)
                    Console.Write(" ");

                Console.WriteLine(tower2.ElementAt(x));
            }

            return tower1;
        }
    }
}