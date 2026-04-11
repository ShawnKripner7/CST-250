/*
 * Shawn Kripner
 * CST-250
 * 4/10/2026
 * Minesweeper Project
 * Milestone 3
 */

using System;
using MinesweeperClassLibrary.Models;

namespace MinesweeperClassLibrary.BusinessLogicLayer
{
    public class BoardService
    {
        private BoardModel _board;
        private Random _random = new Random();

        // constructor takes in the board
        public BoardService(BoardModel board)
        {
            _board = board;
        }

        // place bombs randomly on the board
        public void SetupBombs()
        {
            int bombCount = _board.Size;
            int bombsPlaced = 0;

            // keep placing bombs until we hit the count
            while (bombsPlaced < bombCount)
            {
                int row = _random.Next(_board.Size);
                int col = _random.Next(_board.Size);

                // make sure we don't put a bomb twice in the same spot
                if (_board.Cells[row, col].IsBomb == false)
                {
                    _board.Cells[row, col].IsBomb = true;
                    bombsPlaced++;
                }
            }

            // place one reward on a random safe cell
            bool rewardPlaced = false;

            while (rewardPlaced == false)
            {
                int rewardRow = _random.Next(_board.Size);
                int rewardCol = _random.Next(_board.Size);

                if (_board.Cells[rewardRow, rewardCol].IsBomb == false)
                {
                    _board.Cells[rewardRow, rewardCol].HasSpecialReward = true;
                    rewardPlaced = true;
                }
            }
        }

        // count bombs around each cell
        public void CountBombsNearby()
        {
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    int bombCount = 0;

                    // check all 8 spots around the cell
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int neighborRow = row + i;
                            int neighborCol = col + j;

                            // stay inside the board
                            if (neighborRow >= 0 && neighborRow < _board.Size &&
                                neighborCol >= 0 && neighborCol < _board.Size)
                            {
                                if (_board.Cells[neighborRow, neighborCol].IsBomb)
                                {
                                    bombCount++;
                                }
                            }
                        }
                    }

                    // save the number to the cell
                    _board.Cells[row, col].NumberOfBombNeighbors = bombCount;
                }
            }
        }

        // reveals connected empty cells using recursion
        public void FloodFill(int row, int col)
        {
            // stop if the cell is outside the board
            if (row < 0 || col < 0 || row >= _board.Size || col >= _board.Size)
            {
                return;
            }

            CellModel cell = _board.Cells[row, col];

            // stop if the cell was already visited or is a bomb
            if (cell.IsVisited || cell.IsBomb)
            {
                return;
            }

            // reveal the current cell
            cell.IsVisited = true;

            // if there are no neighboring bombs, keep spreading
            if (cell.NumberOfBombNeighbors == 0)
            {
                FloodFill(row - 1, col);     // up
                FloodFill(row + 1, col);     // down
                FloodFill(row, col - 1);     // left
                FloodFill(row, col + 1);     // right
                FloodFill(row - 1, col - 1); // top-left
                FloodFill(row - 1, col + 1); // top-right
                FloodFill(row + 1, col - 1); // bottom-left
                FloodFill(row + 1, col + 1); // bottom-right
            }
        }

        // when user clicks a cell
        public bool VisitCell(int row, int col)
        {
            CellModel cell = _board.Cells[row, col];

            // ignore the move if the cell was already visited or flagged
            if (cell.IsVisited || cell.IsFlagged)
            {
                return false;
            }

            // if it's a bomb, reveal it and end the game
            if (cell.IsBomb)
            {
                cell.IsVisited = true;
                return true;
            }

            // check if the cell has a reward
            if (cell.HasSpecialReward)
            {
                Console.WriteLine("You found a reward!");
                cell.HasSpecialReward = false;
            }

            // use flood fill for empty cells
            if (cell.NumberOfBombNeighbors == 0)
            {
                FloodFill(row, col);
            }
            else
            {
                cell.IsVisited = true;
            }

            return false;
        }

        // checks if the game is won, lost, or still going
        public string DetermineGameState()
        {
            bool allSafeCellsHandled = true;

            // loop through every cell on the board
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    CellModel cell = _board.Cells[row, col];

                    // if a bomb was visited, player loses immediately
                    if (cell.IsBomb && cell.IsVisited)
                    {
                        return "Lost";
                    }

                    // safe cells must be visited
                    if (!cell.IsBomb && !cell.IsVisited)
                    {
                        allSafeCellsHandled = false;
                    }

                    // bombs must be flagged
                    if (cell.IsBomb && !cell.IsFlagged)
                    {
                        allSafeCellsHandled = false;
                    }
                }
            }

            // if everything is handled correctly, player wins
            if (allSafeCellsHandled)
            {
                return "Won";
            }

            // otherwise keep playing
            return "StillPlaying";
        }

        // lets the user place or remove a flag
        public void FlagCell(int row, int col)
        {
            // switch the flag on or off
            _board.Cells[row, col].IsFlagged = !_board.Cells[row, col].IsFlagged;
        }

        // checks if the player landed on a reward cell
        public bool CheckForReward(int row, int col)
        {
            // return true if this cell has a reward
            return _board.Cells[row, col].HasSpecialReward;
        }

        // lets the player use a reward to peek at a cell
        public string UseReward(int row, int col)
        {
            // check if chosen cell is a bomb
            if (_board.Cells[row, col].IsBomb == true)
            {
                return "That cell has a bomb.";
            }

            return "That cell is safe.";
        }
    }
}