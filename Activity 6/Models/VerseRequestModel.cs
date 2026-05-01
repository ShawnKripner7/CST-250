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
    public class VerseRequestModel
    {
        // Class level properties
        public string Book { get; set; }
        public int Chapter { get; set; }
        public string Verse { get; set; }
        public string Text { get; set; }
        public string Meaning { get; set; }
        public int Importance { get; set; }

        /// <summary>
        /// Default constructor for the Verse Request Model
        /// </summary>
        public VerseRequestModel()
        {
            // Set the properties to empty strings
            Book = string.Empty;
            Chapter = 0;
            Verse = string.Empty;
            Text = string.Empty;
            Meaning = string.Empty;
            Importance = 0;
        }

        /// <summary>
        /// Parameterized constructor for the Verse Request Model
        /// </summary>
        /// <param name="address"></param>
        /// <param name="text"></param>
        /// <param name="meaning"></param>
        public VerseRequestModel(string book, int chapter, string verse, string text, string meaning, int importance)
        {
            // Set the properties equal to the corresponding parameters
            Book = book;
            Chapter = chapter;
            Verse = verse;
            Text = text;
            Meaning = meaning;
            Importance = importance;
        }
    }
}
