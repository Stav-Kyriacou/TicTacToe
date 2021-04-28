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
            bool validInput = false;
            bool player1Turn = true;
            bool keepPlaying = true;

            while (keepPlaying)
            {
                while (!victory)
                {
                    DrawGrid();
                    validInput = false;                                     //set false to enter the input validation loop

                    if (player1Turn)                                        //write whose turn it is
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

                        if (int.TryParse(Console.ReadLine(), out int input))        //check if the input is a number
                        {
                            if ((input > 0 && input < 10) && (grid[input - 1] != "X" && grid[input - 1] != "O"))    //if the number is within range and is not already taken
                            {
                                if (player1Turn)                                    //write X or O into the grid depending on whose turn it is
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
                                WriteInputError();
                                validInput = false;
                            }
                        }
                        else
                        {
                            WriteInputError();
                            validInput = false;
                        }
                    }
                }

                DrawGrid();

                if (!player1Turn)                                   //display who won
                {
                    Console.WriteLine("Player 1 wins!");
                }
                else
                {
                    Console.WriteLine("Player 2 wins!");
                }

                Console.WriteLine();
                Console.Write("Continue playing? Type 'y' to continue or anything else to exit: ");
                string keepPlayingInput = Console.ReadLine().ToUpper();

                if (keepPlayingInput == "Y")                        //check if they want to keep playing or exit
                {
                    keepPlaying = true;
                    victory = false;
                    ResetGrid();
                }
                else
                {
                    keepPlaying = false;
                }
            }
            Console.WriteLine("Thanks for playing!");
        }

        public static void DrawGrid()
        {
            //clears the console then draws the grid
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
        public static void ResetGrid()
        {
            //restores the grid to its default values
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = (i + 1).ToString();
            }
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
        public static void WriteInputError()
        {
            //writes an input error message in red
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Input: Enter a number between 1 and 9 that isn't already taken");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
