using System;
using MinesweeperClassLibrary.Models;

namespace MinesweeperClassLibrary.BusinessLogicLayer
{
    public class BoardService
    {
        private BoardModel _board;
        private Random _random = new Random();

        // constructor gets the board we are working with
        public BoardService(BoardModel board)
        {
            _board = board;
        }

        // randomly place bombs on the board
        public void SetupBombs()
        {
            int bombCount = _board.Size;
            int bombsPlaced = 0;

            while (bombsPlaced < bombCount)
            {
                int row = _random.Next(_board.Size);
                int col = _random.Next(_board.Size);

                if (_board.Cells[row, col].IsBomb == false)
                {
                    _board.Cells[row, col].IsBomb = true;
                    bombsPlaced++;
                }
            }
        }

        // count how many bombs are around each cell
        public void CountBombsNearby()
        {
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    int bombCount = 0;

                    // check all 8 directions around the cell
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int neighborRow = row + i;
                            int neighborCol = col + j;

                            // make sure we stay inside the board
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

                    // save the count to the cell
                    _board.Cells[row, col].NumberOfBombNeighbors = bombCount;
                }
            }
        }
    }
}