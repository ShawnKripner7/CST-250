/*
 * Shawn Kripner
 * CST-250
 * 4/2/2026
 * Minesweeper Project
 * Milestone 2
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

        // when user clicks a cell
        public bool VisitCell(int row, int col)
        {
            // grab the cell they picked
            CellModel cell = _board.Cells[row, col];

            // mark it as visited
            cell.IsVisited = true;

            // check if the cell has a reward
            if (cell.HasSpecialReward)
            {
                Console.WriteLine("You found a reward!");

                // remove reward so it can't trigger again
                cell.HasSpecialReward = false;
            }

            // if it's a bomb, game over
            return cell.IsBomb;
        }

        // checks if the game is won, lost, or still going
        public string DetermineGameState()
        {
            bool allSafeCellsHandled = true; // assume player handled all safe cells

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

                    // check safe cells (non-bombs)
                    // they must be visited to count toward winning
                    if (!cell.IsBomb && !cell.IsVisited)
                    {
                        allSafeCellsHandled = false;
                    }

                    // OPTIONAL: check if bombs are flagged correctly
                    // if a bomb is not flagged, player hasn't fully completed the board
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