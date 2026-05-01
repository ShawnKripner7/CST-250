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
    class VerseDataModel
    {
        // Class level properties
        public int Id { get; set; }
        public string Book { get; set; }
        public int Chapter { get; set; }
        public string Verse { get; set; }
        public string Text { get; set; }
        public string Meaning { get; set; }
        public int Importance { get; set; }

        /// <summary>
        /// Default constructor for the Verse Data Model
        /// </summary>
        public VerseDataModel()
        {
            // Set the properties to default values
            Id = 0;
            Book = "";
            Chapter = 0;
            Verse = "";
            Text = "";
            Meaning = "";
            Importance = 0;
        }

        /// <summary>
        /// Parameterized constructor for the Verse Request Model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <param name="chapter"></param>
        /// <param name="verse"></param>
        /// <param name="text"></param>
        /// <param name="meaning"></param>
        /// <param name="importance"></param>
        public VerseDataModel(int id, string book, int chapter, string verse, string text, string meaning, int importance)
        {
            Id = id;
            Book = book;
            Chapter = chapter;
            Verse = verse;
            Text = text;
            Meaning = meaning;
            Importance = importance;
        }
    }
}
