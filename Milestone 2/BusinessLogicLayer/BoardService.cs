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

            // if it's a bomb, game over
            return cell.IsBomb;
        }
    }
}