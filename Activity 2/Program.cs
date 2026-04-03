/* 
 * Shawn Kripner
 * CST-250
 * 4/1/2026
 * Chess Board Project
 * Activity 2
 */

using ChessBoardClassLibrary.Models;
using ChessBoardClassLibrary.Services.BusinessLogicLayer;

//--------------------------------------------------------------
// Start of Main Method
//--------------------------------------------------------------

// Declare and initialize
string piece = "";
Tuple<int, int>? result;
BoardLogic boardLogic = new BoardLogic();

// Print a welcome message for the user
Console.WriteLine("Hello, Chess Players!");

// Create a new chess board
BoardModel board = new BoardModel(8);

// Show the empty board
Utility.PrintBoard(board);

// Prompt the user for the type of chess piece
while (true)
{
    Console.Write("Enter the type of piece you want to place (Knight, Rook, Bishop, Queen, King): ");
    piece = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(piece))
    {
        piece = piece.Trim().ToLower();

        if (piece == "knight" || piece == "rook" || piece == "bishop" || piece == "queen" || piece == "king")
        {
            break;
        }
    }

    Console.WriteLine("Invalid piece. Please enter Knight, Rook, Bishop, Queen, or King.");
}

// Prompt the user for the location of the chess piece
result = Utility.GetRowAndCol(board.Size);

// Mark the legal moves based on the input
board = boardLogic.MarkLegalMoves(board, board.Grid[result.Item1, result.Item2], piece);

// Print out the new chess board
Utility.PrintBoard(board);

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
        // Print column headers
        Console.Write("   ");
        for (int col = 0; col < board.Size; col++)
        {
            Console.Write($" {col}  ");
        }
        Console.WriteLine();

        // Loop over the rows of the board
        for (int row = 0; row < board.Size; row++)
        {
            // Print top border for each row
            Console.Write("   ");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("--- ");
            }
            Console.WriteLine();

            // Print row number
            Console.Write($"{row} |");

            // Loop over the columns of the board
            for (int col = 0; col < board.Size; col++)
            {
                // Get the current cell from the grid
                CellModel cell = board.Grid[row, col];

                // Check if the current cell is a legal move
                if (cell.IsLegalNextMove)
                {
                    // Print a + for a legal move
                    Console.Write("+");
                }
                // Check if there is a piece occupying the cell
                else if (cell.PieceOccupyingCell != "")
                {
                    // Print the chess piece letter
                    Console.Write(cell.PieceOccupyingCell);
                }
                else
                {
                    // Print a . for anything else
                    Console.Write(".");
                }

                Console.Write(" |");
            }

            Console.WriteLine();
        }

        // Print bottom border
        Console.Write("   ");
        for (int col = 0; col < board.Size; col++)
        {
            Console.Write("--- ");
        }
        Console.WriteLine();
    } // End of PrintBoard method


    /// <summary>
    /// Get the row and column for the piece
    /// </summary>
    /// <returns></returns>
    internal static Tuple<int, int> GetRowAndCol(int boardSize)
    {
        int row;
        int col;

        // Keep asking until the user gives a valid row
        while (true)
        {
            Console.Write($"Enter the row number (0-{boardSize - 1}): ");
            string rowInput = Console.ReadLine();

            // Check if it's a number and within range
            if (int.TryParse(rowInput, out row) && row >= 0 && row < boardSize)
            {
                break;
            }

            Console.WriteLine("Invalid row. Try again.");
        }

        // Keep asking until the user gives a valid column
        while (true)
        {
            Console.Write($"Enter the column number (0-{boardSize - 1}): ");
            string colInput = Console.ReadLine();

            // Check if it's a number and within range
            if (int.TryParse(colInput, out col) && col >= 0 && col < boardSize)
            {
                break;
            }

            Console.WriteLine("Invalid column. Try again.");
        }

        // Return the row and column
        return Tuple.Create(row, col);
    }
}