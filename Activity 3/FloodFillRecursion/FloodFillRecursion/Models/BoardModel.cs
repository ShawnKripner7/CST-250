/*
 * Shawn Kripner
 * CST - 250
 * 4/10/2026
 * Flood Fill Recursion
 * Activity 3
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FloodFillRecursion.Models
{
    internal class BoardModel
    {
        // BoardModel Properties
        public int Size { get; set; }
        public CellModel[,] Grid { get; set; }
        public int NumShapes { get; set; }

        /// <summary>
        /// Parameterized constructor for BoardModel
        /// </summary>
        /// <param name="size"></param>
        public BoardModel(int size, int numShapes)
        {
            Size = size;
            NumShapes = numShapes;
            Grid = new CellModel[Size, Size];

            // Set up the Grid
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Grid[row, col] = new CellModel(row, col, "E");
                }
            }

            // Place random shapes on the board
            PlaceShapes();
        }

        /// <summary>
        /// Create shapes to place on the board
        /// </summary>
        public void PlaceShapes()
        {
            // Declare and initialize
            // Random object to generate numbers
            Random random = new Random();
            int shapeSize = Size / 2, row = 0, col = 0;

            // Create three shapes
            for (int shapes = 0; shapes < NumShapes; shapes++)
            {
                // Generate the row and col for the
                // top left corner of the square
                row = random.Next(0, Size - shapeSize + 1);
                col = random.Next(0, Size - shapeSize + 1);

                for (int offset = 0; offset < shapeSize; offset++)
                {
                    // Top Wall
                    Grid[row, col + offset].Contents = "W";

                    // Bottom wall
                    Grid[row + shapeSize - 1, col + offset].Contents = "W";

                    // Left Wall
                    Grid[row + offset, col].Contents = "W";

                    // Right wall
                    Grid[row + offset, col + shapeSize - 1].Contents = "W";
                }
            }
        } // End of PlaceShapes method
    }
}
