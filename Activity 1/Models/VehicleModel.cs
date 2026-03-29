/*
 * Shawn Kripner
 * CST-250
 * 3/24/2026
 * Vehicle Class Library
 * Activity 1
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static System.Net.WebRequestMethods;

namespace VehicleClassLibrary.Models
{
    public class VehicleModel
    {
        // Class level properties
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int NumWheels { get; set; }

        public string Color { get; set; }
        public int Miles { get; set; }

        /// <summary>
        /// Default constructor a vehicle model
        /// </summary>
        public VehicleModel()
        {
            Id = 0;
            Make = "Unknown";
            Model = "Unknown";
            Year = 0;
            Price = 0m;
            NumWheels = 0;
            Color = "Unknown";
            Miles = 0;
        }

        /// <summary>
        /// Parameterized constructor for the vehicle model class
        /// </summary>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        public VehicleModel(int id, string make, string model, int year, decimal price, int numWheels, string color, int miles)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            NumWheels = numWheels;
            Color = color;
            Miles = miles;
        }

        /// <summary>
        /// ToString method for printing a vehicle
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Print the vehicle in the following format
            // 1: 2013 Ford Fiesta with 4 wheels - $800.00
            return $"{Id}: {Year} {Make} {Model}, Color: {Color}, Miles: {Miles}, with {NumWheels} wheels - {Price:C2}";
        }
    }
}
