using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        public static string[] grid = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static void Main(string[] args)
        {
            //draw the grid

            //start on player 1 turn

            //ask player 1 for a number on the grid
            //if the spot hasnt been taken, place an X there

            //check if a win condition has been met

            //change to player 2

            //repeat above except place an O in the grid

            bool validInput = false;
            bool player1Turn = true;
            bool victory = false;

            DrawGrid();

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
                            }
                            else
                            {
                                grid[input - 1] = "O";
                            }
                            validInput = true;
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

            DrawGrid();


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
    }
}
