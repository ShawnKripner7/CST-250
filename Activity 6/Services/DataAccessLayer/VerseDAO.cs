/*
 * Shawn Kripner
 * CST-250
 * 4/30/2026
 * File I/O and LINQ
 * Activity 6
 */

using FileIOAndLINQ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileIOAndLINQ.Services.DataAccessLayer
{
    class VerseDAO
    {
        // Declare class level variables
        List<VerseDataModel> _verses;

        /// <summary>
        /// Default constructor for VerseDAO
        /// </summary>
        public VerseDAO()
        {
            // Create a new List of VerseDataModels
            _verses = new List<VerseDataModel>();
        }

        /// <summary>
        /// Add a new verse to the inventory
        /// </summary>
        /// <param name="verse"></param>
        /// <returns></returns>
        public int AddVerse(VerseRequestModel verse)
        {
            int id = _verses.Count + 1;
            VerseDataModel newVerse = new VerseDataModel();

            newVerse = new VerseDataModel(id, verse.Book, verse.Chapter,
                verse.Verse, verse.Text, verse.Meaning, verse.Importance);

            _verses.Add(newVerse);

            return id;
        }
    }
}