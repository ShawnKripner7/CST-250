/*
 * Shawn Kripner
 * CST-250
 * 4/2/2026
 * Minesweeper Project
 * Milestone 2
 */

using System;
using MinesweeperClassLibrary.Models;
using MinesweeperClassLibrary.BusinessLogicLayer;

namespace MinesweeperConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create a 10x10 board
            BoardModel board = new BoardModel(10);

            // create the service
            BoardService service = new BoardService(board);

            // set up bombs and numbers
            service.SetupBombs();
            service.CountBombsNearby();

            // show full board first for testing
            PrintAnswers(board);

            // keeps track of game state
            string gameState = "StillPlaying";

            // keeps track of reward use
            bool rewardAvailable = false;

            // game loop
            while (gameState == "StillPlaying")
            {
                // print the board during play
                PrintBoard(board);

                // ask user for row
                Console.Write("Enter row: ");
                int row = Convert.ToInt32(Console.ReadLine());

                // ask user for column
                Console.Write("Enter column: ");
                int col = Convert.ToInt32(Console.ReadLine());

                // make sure the spot is inside the board
                if (row < 0 || row >= board.Size || col < 0 || col >= board.Size)
                {
                    Console.WriteLine("That spot is outside the board.");
                    continue;
                }

                // ask what move they want to make
                Console.Write("Enter 1 to Visit, 2 to Flag, 3 to Use Reward: ");
                int moveChoice = Convert.ToInt32(Console.ReadLine());

                // visit cell
                if (moveChoice == 1)
                {
                    // do not let player visit flagged cell
                    if (board.Cells[row, col].IsFlagged == true)
                    {
                        Console.WriteLine("That cell is flagged.");
                        continue;
                    }

                    service.VisitCell(row, col);

                    // if reward found
                    if (service.CheckForReward(row, col) == true)
                    {
                        rewardAvailable = true;
                        Console.WriteLine("You found a reward.");
                    }
                }
                // flag cell
                else if (moveChoice == 2)
                {
                    service.FlagCell(row, col);
                }
                // use reward
                else if (moveChoice == 3)
                {
                    if (rewardAvailable == true)
                    {
                        Console.WriteLine(service.UseReward(row, col));
                        rewardAvailable = false;
                    }
                    else
                    {
                        Console.WriteLine("No reward available.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                // update game state after move
                gameState = service.DetermineGameState();
            }

            // print final result
            if (gameState == "Won")
            {
                Console.WriteLine("You win!");
            }
            else if (gameState == "Lost")
            {
                Console.WriteLine("You hit a bomb. Game over.");
            }

            // show final board
            PrintAnswers(board);

            Console.ReadLine();
        }

        // shows only visited cells during the game
        static void PrintBoard(BoardModel board)
        {
            // go through each row
            for (int row = 0; row < board.Size; row++)
            {
                // go through each column
                for (int col = 0; col < board.Size; col++)
                {
                    // if player put a flag here
                    if (board.Cells[row, col].IsFlagged == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("F ");
                    }
                    // if cell has not been visited yet
                    else if (board.Cells[row, col].IsVisited == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("? ");
                    }
                    // if bomb
                    else if (board.Cells[row, col].IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("B ");
                    }
                    // if this cell had a reward
                    else if (board.Cells[row, col].HasSpecialReward == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("R ");
                    }
                    // if number
                    else if (board.Cells[row, col].NumberOfBombNeighbors > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(board.Cells[row, col].NumberOfBombNeighbors + " ");
                    }
                    // if empty
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(". ");
                    }
                }

                // next line
                Console.WriteLine();
            }

            // reset color
            Console.ResetColor();
        }

        // shows full board at the end
        static void PrintAnswers(BoardModel board)
        {
            // go through each row
            for (int row = 0; row < board.Size; row++)
            {
                // go through each column
                for (int col = 0; col < board.Size; col++)
                {
                    // show bomb
                    if (board.Cells[row, col].IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("B ");
                    }
                    // show number
                    else if (board.Cells[row, col].NumberOfBombNeighbors > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(board.Cells[row, col].NumberOfBombNeighbors + " ");
                    }
                    // show empty spot
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(". ");
                    }
                }

                // move to next line
                Console.WriteLine();
            }

            // reset color back to normal
            Console.ResetColor();
        }
    }
}