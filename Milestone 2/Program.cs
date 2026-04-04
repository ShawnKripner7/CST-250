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

            // game keeps going until a bomb is hit
            bool gameOver = false;

            // main game loop
            while (gameOver == false)
            {
                // print the board
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

                // do not let the user pick the same cell again
                if (board.Cells[row, col].IsVisited == true)
                {
                    Console.WriteLine("That cell was already picked.");
                    continue;
                }

                // visit the cell
                gameOver = service.VisitCell(row, col);

                // if bomb was hit
                if (gameOver)
                {
                    Console.WriteLine("You hit a bomb. Game over.");
                }
            }

            // show the full board at the end
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
                    // if cell has not been visited yet
                    if (board.Cells[row, col].IsVisited == false)
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

                // move to next line
                Console.WriteLine();
            }

            // reset color back to normal
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