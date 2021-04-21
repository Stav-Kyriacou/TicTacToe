using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        public static string[] grid = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public static bool victory = false;
        static void Main(string[] args)
        {
            //add option to reset game

            bool validInput = false;
            bool player1Turn = true;

            while (!victory)
            {
                DrawGrid();
                validInput = false;

                if (player1Turn)
                {
                    Console.WriteLine("Player 1's Turn");
                }
                else
                {
                    Console.WriteLine("Player 2's Turn");
                }

                while (!validInput)
                {
                    Console.Write("Enter a grid number: ");

                    if (int.TryParse(Console.ReadLine(), out int input))                            //check if the input was a number
                    {
                        if (input > 0 && input < 10)                                                //check if number is within range
                        {
                            if (grid[input - 1] != "X" && grid[input - 1] != "O")                   //check if the space is already taken
                            {
                                if (player1Turn)                                                    //write X or O in valid place depending on turn
                                {
                                    grid[input - 1] = "X";
                                    player1Turn = false;
                                }
                                else
                                {
                                    grid[input - 1] = "O";
                                    player1Turn = true;
                                }
                                validInput = true;
                                CheckVictory();
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input: Space taken");
                                validInput = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input: Enter a number between 1 and 9");
                            validInput = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input: Enter a number");
                        validInput = false;
                    }
                }

            }

            DrawGrid();
            if (!player1Turn)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else
            {
                Console.WriteLine("Player 2 wins!");
            }
        }

        public static void DrawGrid()
        {
            Console.Clear();
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", grid[0], grid[1], grid[2]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", grid[3], grid[4], grid[5]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", grid[6], grid[7], grid[8]);
            Console.WriteLine("   |   |   ");
        }
        public static void CheckVictory()
        {
            if ((grid[0] == "X" && grid[1] == "X" && grid[2] == "X") ||                 //horizontal X win cons
                (grid[3] == "X" && grid[4] == "X" && grid[5] == "X") ||
                (grid[6] == "X" && grid[7] == "X" && grid[8] == "X") ||
                (grid[0] == "X" && grid[3] == "X" && grid[6] == "X") ||                 //vertical X win cons
                (grid[1] == "X" && grid[4] == "X" && grid[7] == "X") ||
                (grid[2] == "X" && grid[5] == "X" && grid[8] == "X") ||
                (grid[0] == "X" && grid[4] == "X" && grid[8] == "X") ||                 //diagonal X win cons
                (grid[2] == "X" && grid[4] == "X" && grid[6] == "X"))
            {
                victory = true;
            }
            else if ((grid[0] == "O" && grid[1] == "O" && grid[2] == "O") ||                 //horizontal O win cons
                     (grid[3] == "O" && grid[4] == "O" && grid[5] == "O") ||
                     (grid[6] == "O" && grid[7] == "O" && grid[8] == "O") ||
                     (grid[0] == "O" && grid[3] == "O" && grid[6] == "O") ||                 //vertical O win cons
                     (grid[1] == "O" && grid[4] == "O" && grid[7] == "O") ||
                     (grid[2] == "O" && grid[5] == "O" && grid[8] == "O") ||
                     (grid[0] == "O" && grid[4] == "O" && grid[8] == "O") ||                 //diagonal O win cons
                     (grid[2] == "O" && grid[4] == "O" && grid[6] == "O"))
            {
                victory = true;
            }
            else
            {
                victory = false;
            }
        }
    }
}
