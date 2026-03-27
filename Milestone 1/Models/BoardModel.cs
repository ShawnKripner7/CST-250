using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClassLibrary.Models
{
    // represents the game board
    public class BoardModel
    {
        // size of the board (square)
        public int Size { get; set; }

        // time tracking (not used yet)
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // 2D array of cells
        public CellModel[,] Cells { get; set; }

        // difficulty level (can use later)
        public int Difficulty { get; set; }

        // number of rewards left
        public int RewardsRemaining { get; set; } = 0;

        // current game state
        public string GameState { get; set; } = "InProgress";

        // constructor for board
        public BoardModel(int size)
        {
            Size = size;

            // create the grid based on size
            Cells = new CellModel[Size, Size];

            // fill the board with cells
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    // create a new cell at each position
                    Cells[row, col] = new CellModel(row, col);
                }
            }
        }
    }
}