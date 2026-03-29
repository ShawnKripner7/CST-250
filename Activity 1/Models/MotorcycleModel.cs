/*
 * Shawn Kripner
 * CST-250
 * 3/24/2026
 * Vehicle Class Library
 * Activity 1
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleClassLibrary.Models
{
    public class MotorcycleModel : VehicleModel
    {
        // Class level properties
        public bool HasSideCar { get; set; }
        public decimal SeatHeight { get; set; } // In inches

        /// <summary>
        /// Default constructor for the motorcycle model
        /// </summary>
        public MotorcycleModel() : base()
        {
            HasSideCar = false;
            SeatHeight = 0m;
        }

        /// <summary>
        /// Parameterized constructor for the motorcycle model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <param name="numWheels"></param>
        /// <param name="hasSideCar"></param>
        /// <param name="seatHeight"></param>
        public MotorcycleModel(int id, string make, string model, int year, decimal price, int numWheels, string color, int miles, bool hasSideCar, decimal seatHeight)
            : base(id, make, model, year, price, numWheels, color, miles)
        {
            HasSideCar = hasSideCar;
            SeatHeight = seatHeight;
        }

        /// <summary>
        /// ToString method for printing a motorcycle
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Use a ternary operator (in-line if) to get the side car string
            // condition      if true   if false
            string sideCar = HasSideCar ? "with" : "without";

            // Print the motorcycle in the following format
            // 1: 2015 Yamaha Bolt with 2 wheels and a 44.1 inch seat with(out) a side car - $8000.00 (added color and miles)
            return $"{Id}: {Year} {Color} {Make} {Model} with {Miles} miles, {NumWheels} wheels and a {SeatHeight} inch seat {sideCar} a side car - {Price:C2}";
        }
    }
}
