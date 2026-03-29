/*
 * Shawn Kripner
 * CST-250
 * 3/24/2026
 * Vehicle Class Library
 * Activity 1
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace VehicleClassLibrary.Models
{
    public class CarModel : VehicleModel 
    {
        // Class level properties
        public bool IsConvertible { get; set; }
        public decimal TrunkSize { get; set; } // In cubic feet

        /// <summary>
        /// Default constructor for the car model
        /// </summary>
        public CarModel() : base()
        {
            IsConvertible = false;
            TrunkSize = 0m;
        }

        /// <summary>
        /// Parameterized constructor for a car model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <param name="numWheels"></param>
        /// <param name="isConvertible"></param>
        /// <param name="trunkSize"></param>
        public CarModel(int id, string make, string model, int year, decimal price, int numWheels, string color, int miles, bool isConvertible, decimal trunkSize)
            : base(id, make, model, year, price, numWheels, color, miles)
        {
            IsConvertible = isConvertible;
            TrunkSize = trunkSize;
        }

        /// <summary>
        /// ToString method for printing a car
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Use a ternary operator (in-line if) to get the convertible string
            // condition      if true   if false
            string convertible = IsConvertible ? "with" : "without";

            // Print the car in the following format
            // 1: 2019 Jeep Wrangler with 4 wheels and a 14.7 cubic foot trunk without a convertible top - $27000.00
            return $"{Id}: {Year} {Make} {Model} with {NumWheels} wheels and a {TrunkSize} cubic foot trunk {convertible} a convertible top - {Price:C2}";
        }

    }
}
