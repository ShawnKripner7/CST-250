/* 
 * Shawn Kripner
 * CST-250
 * 4/1/2026
 * Chess Board Project
 * Activity 2
 */

//--------------------------------------------------------------
// Start of Main Method
//--------------------------------------------------------------

// Print a welcome message for the user
using ChessBoardClassLibrary.Models;

Console.WriteLine("Hello, Chess Players!");

// Create a new chess board
BoardModel board = new BoardModel(8);

// Show the empty board
Utility.PrintBoard(board);

// Prompt the user for the type of chess piece

// Prompt the user for the location of the chess piece

// Mark the legal moves based on the input

// Print out the new chess board

//--------------------------------------------------------------
// End of Main Method
//--------------------------------------------------------------

//--------------------------------------------------------------
// Define a utility class
//--------------------------------------------------------------

public static class Utility
{
    /// <summary>
    /// Print the given board to the console
    /// </summary>
    /// <param name="board"></param>
    internal static void PrintBoard(BoardModel board)
    {
        // Loop over the rows of the board
        for (int row = 0; row < board.Size; row++)
        {
            // Loop over the columns of the board
            for (int col = 0; col < board.Size; col++)
            {
                // Get the current cell from the grid
                CellModel cell = board.Grid[row, col];

                // Check if the current cell is a legal move
                if (cell.IsLegalNextMove)
                {
                    // Print a + for a legal move
                    Console.Write("+ ");
                }
                // Check if there is a piece occupying the cell
                else if (cell.PieceOccupyingCell != "")
                {
                    // Print the chess piece letter
                    Console.Write($"{cell.PieceOccupyingCell} ");
                }
                else
                {
                    // Print a . for anything else
                    Console.Write(". ");
                }
            }

            // Start a new line after every row
            Console.WriteLine();
        }
    } // End of PrintBoard method
}