/*
 * Shawn Kripner
 * CST-250
 * 4/30/2026
 * File I/O and LINQ
 * Activity 6
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace FileIOAndLINQ.Models
{
    public class VerseDisplayModel
    {
        // Class level properties
        public string Reference { get; set; }
        public string Text { get; set; }
        public string Meaning { get; set; }
        public int Importance { get; set; }

        /// <summary>
        /// Default constructor for the Verse Display Model
        /// </summary>
        public VerseDisplayModel()
        {
            // Set the properties to default values
            Reference = "";
            Text = "";
            Meaning = "";
            Importance = 0;
        }

        /// <summary>
        /// Parameterized constructor for the Verse Display Model
        /// </summary>
        /// <param name="address"></param>
        /// <param name="text"></param>
        /// <param name="meaning"></param>
        public VerseDisplayModel(string reference, string text, string meaning, int importance)
        {
            // Set the properties equal to the corresponding parameters
            Reference = reference;
            Text = text;
            Meaning = meaning;
            Importance = importance;
        }
    }
}
