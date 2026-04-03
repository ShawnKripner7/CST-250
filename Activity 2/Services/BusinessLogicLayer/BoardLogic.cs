/* 
 * Shawn Kripner
 * CST-250
 * 4/1/2026
 * Chess Board Project
 * Activity 2
 */

using ChessBoardClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardClassLibrary.Services.BusinessLogicLayer
{
    public class BoardLogic
    {
        /// <summary>
        /// Reset the board by setting the
        /// cell properties back to default
        /// Encapsulate this method so it can only be
        /// called from this class.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private BoardModel ResetBoard(BoardModel board)
        {
            // Use a foreach loop to iterate over every cell
            foreach (CellModel cell in board.Grid)
            {
                // Set the properties to their defaults
                cell.IsLegalNextMove = false;
                cell.PieceOccupyingCell = "";
            }

            // Return the board back to the presentation layer
            return board;
        }

        /// <summary>
        /// Check if a row/column location is on the board
        /// Encapsulate this method so it can only be
        /// called from this class.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool IsOnBoard(BoardModel board, int row, int col)
        {
            // Get the size of the board
            int size = board.Size;

            // Check if the row is on the board
            bool IsRowSafe = row >= 0 && row < size;

            // Check if the column is on the board
            bool IsColumnSafe = col >= 0 && col < size;

            // Return true if both row and column are safe
            return IsRowSafe && IsColumnSafe;
        }

        /// <summary>
        /// Mark the valid moves for the knight
        /// Access modifier is private - meaning this method is encapsulated within the
        /// BoardLogic class and cannot be accessed directly outside the class.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentCell"></param>
        /// <returns></returns>
        private BoardModel MarkValidKnightMoves(BoardModel board, CellModel currentCell)
        {
            // Possible moves for knight row
            int[] knightRowMoves = { 2, 1, -1, -2, -2, -1, 1, 2 };

            // Possible moves for knight column
            int[] knightColMoves = { 1, 2, 2, 1, -1, -2, -2, -1 };

            // Loop through the knights moves
            for (int i = 0; i < knightRowMoves.Length; i++)
            {
                // Check if each move is on the board
                if (IsOnBoard(board, currentCell.Row + knightRowMoves[i], currentCell.Column + knightColMoves[i]))
                {
                    // If the cell is on the board, label it as a possible move for the knight
                    board.Grid[currentCell.Row + knightRowMoves[i], currentCell.Column + knightColMoves[i]].IsLegalNextMove = true;
                }
            }

            return board;
        }

        /// <summary>
        /// Mark the valid moves for the rook
        /// Access modifier is private - meaning this method is encapsulated within the
        /// BoardLogic class and cannot be accessed directly outside the class.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentCell"></param>
        /// <returns></returns>
        private BoardModel MarkValidRookMoves(BoardModel board, CellModel currentCell)
        {
            // Loop through the rows
            for (int row = 0; row < board.Size; row++)
            {
                // Skip the current cell
                if (row != currentCell.Row)
                {
                    board.Grid[row, currentCell.Column].IsLegalNextMove = true;
                }
            }

            // Loop through the columns
            for (int col = 0; col < board.Size; col++)
            {
                // Skip the current cell
                if (col != currentCell.Column)
                {
                    board.Grid[currentCell.Row, col].IsLegalNextMove = true;
                }
            }

            return board;
        }

        /// <summary>
        /// Mark the valid moves for the bishop
        /// Access modifier is private - meaning this method is encapsulated within the
        /// BoardLogic class and cannot be accessed directly outside the class.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentCell"></param>
        /// <returns></returns>
        private BoardModel MarkValidBishopMoves(BoardModel board, CellModel currentCell)
        {
            // Move up-right
            for (int i = 1; i < board.Size; i++)
            {
                int newRow = currentCell.Row - i;
                int newCol = currentCell.Column + i;

                if (IsOnBoard(board, newRow, newCol))
                {
                    board.Grid[newRow, newCol].IsLegalNextMove = true;
                }
            }

            // Move up-left
            for (int i = 1; i < board.Size; i++)
            {
                int newRow = currentCell.Row - i;
                int newCol = currentCell.Column - i;

                if (IsOnBoard(board, newRow, newCol))
                {
                    board.Grid[newRow, newCol].IsLegalNextMove = true;
                }
            }

            // Move down-right
            for (int i = 1; i < board.Size; i++)
            {
                int newRow = currentCell.Row + i;
                int newCol = currentCell.Column + i;

                if (IsOnBoard(board, newRow, newCol))
                {
                    board.Grid[newRow, newCol].IsLegalNextMove = true;
                }
            }

            // Move down-left
            for (int i = 1; i < board.Size; i++)
            {
                int newRow = currentCell.Row + i;
                int newCol = currentCell.Column - i;

                if (IsOnBoard(board, newRow, newCol))
                {
                    board.Grid[newRow, newCol].IsLegalNextMove = true;
                }
            }

            return board;
        }

        /// <summary>
        /// Mark the valid moves for the queen
        /// Access modifier is private - meaning this method is encapsulated within the
        /// BoardLogic class and cannot be accessed directly outside the class.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentCell"></param>
        /// <returns></returns>
        private BoardModel MarkValidQueenMoves(BoardModel board, CellModel currentCell)
        {
            // Mark the rook moves
            board = MarkValidRookMoves(board, currentCell);

            // Mark the bishop moves
            board = MarkValidBishopMoves(board, currentCell);

            return board;
        }

        /// <summary>
        /// Mark the valid moves for the king
        /// Access modifier is private - meaning this method is encapsulated within the
        /// BoardLogic class and cannot be accessed directly outside the class.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentCell"></param>
        /// <returns></returns>
        private BoardModel MarkValidKingMoves(BoardModel board, CellModel currentCell)
        {
            // Possible moves for king row
            int[] kingRowMoves = { -1, -1, -1, 0, 0, 1, 1, 1 };

            // Possible moves for king column
            int[] kingColMoves = { -1, 0, 1, -1, 1, -1, 0, 1 };

            // Loop through the king moves
            for (int i = 0; i < kingRowMoves.Length; i++)
            {
                // Check if each move is on the board
                if (IsOnBoard(board, currentCell.Row + kingRowMoves[i], currentCell.Column + kingColMoves[i]))
                {
                    // If the cell is on the board, label it as a possible move for the king
                    board.Grid[currentCell.Row + kingRowMoves[i], currentCell.Column + kingColMoves[i]].IsLegalNextMove = true;
                }
            }

            return board;
        }

        /// <summary>
        /// Mark the legal moves for the given piece and location
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentCell"></param>
        /// <param name="chessPiece"></param>
        /// <returns></returns>
        public BoardModel MarkLegalMoves(BoardModel board, CellModel currentCell, string chessPiece)
        {
            // Reset the board
            board = ResetBoard(board);

            // Use a switch statement to determine the behavior of the piece
            switch (chessPiece.ToLower())
            {
                case "knight":
                    // Set the occupying property for the current cell
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "N";
                    // Mark the valid moves for the knight
                    board = MarkValidKnightMoves(board, currentCell);
                    break;

                case "rook":
                    // Set the occupying property for the current cell
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "R";
                    // Mark the valid moves for the rook
                    board = MarkValidRookMoves(board, currentCell);
                    break;

                case "bishop":
                    // Set the occupying property for the current cell
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "B";
                    // Mark the valid moves for the bishop
                    board = MarkValidBishopMoves(board, currentCell);
                    break;

                case "queen":
                    // Set the occupying property for the current cell
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "Q";
                    // Mark the valid moves for the queen
                    board = MarkValidQueenMoves(board, currentCell);
                    break;

                case "king":
                    // Set the occupying property for the current cell
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "K";
                    // Mark the valid moves for the king
                    board = MarkValidKingMoves(board, currentCell);
                    break;

                default:
                    // If the piece is not valid, return the board as is
                    return board;
            }

            // Return the updated board
            return board;
        } // End of MarkLegalMoves method
    }
}
