using System;
using MinesweeperClassLibrary.Models;
using MinesweeperClassLibrary.BusinessLogicLayer;

namespace MinesweeperConsoleApp
{
    // entry point of the program
    internal class Program
    {
        static void Main(string[] args)
        {
            // create a 15x15 board
            BoardModel board = new BoardModel(15);

            // create service to handle game logic
            BoardService service = new BoardService(board);

            // set up bombs on the board
            service.SetupBombs();

            // calculate number of bombs around each cell
            service.CountBombsNearby();

            // print the board to the console
            PrintAnswers(board);

            Console.ReadLine();
        }

        // prints the board to the console
        static void PrintAnswers(BoardModel board)
        {
            // loop through each row
            for (int row = 0; row < board.Size; row++)
            {
                // loop through each column
                for (int col = 0; col < board.Size; col++)
                {
                    // if the cell is a bomb
                    if (board.Cells[row, col].IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("B ");
                    }
                    // if the cell has bombs nearby
                    else if (board.Cells[row, col].NumberOfBombNeighbors > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(board.Cells[row, col].NumberOfBombNeighbors + " ");
                    }
                    // if the cell is empty
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(". ");
                    }
                }

                // move to next row
                Console.WriteLine();
            }

            // reset color back to normal
            Console.ResetColor();
        }
    }
}