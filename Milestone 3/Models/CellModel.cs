/*
 * Shawn Kripner
 * CST-250
 * 4/10/2026
 * Minesweeper Project
 * Milestone 3
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClassLibrary.Models
{
    public class CellModel
    {
        // row position of the cell
        public int Row { get; set; } = -1;

        // column position of the cell
        public int Column { get; set; } = -1;

        // keeps track if player has clicked this cell
        public bool IsVisited { get; set; } = false;

        // tells if this cell is a bomb
        public bool IsBomb { get; set; } = false;

        // tells if player flagged this cell
        public bool IsFlagged { get; set; } = false;

        // number of bombs around this cell
        public int NumberOfBombNeighbors { get; set; } = 0;

        // optional reward spot (not used yet)
        public bool HasSpecialReward { get; set; } = false;

        // constructor sets row and column
        public CellModel(int row, int column)
        {
            Row = row;
            Column = column;
        }

    }
}
