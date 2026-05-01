/*
 * Shawn Kripner
 * CST-250
 * 4/30/2026
 * File I/O and LINQ
 * Activity 6
 */

using FileIOAndLINQ.Models;
using FileIOAndLINQ.Services.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileIOAndLINQ.Services.BusinessLogicLayer
{
    class VerseLogic
    {
        // Class level variables
        private VerseDAO _verseDAO;

        /// <summary>
        /// Default constructor for VerseLogic
        /// </summary>
        public VerseLogic()
        {
            // Initialize the data access object
            _verseDAO = new VerseDAO();
        }

        /// <summary>
        /// Add a new verse to the inventory
        /// </summary>
        /// <param name="verse"></param>
        /// <returns></returns>
        public int AddVerse(VerseRequestModel verse)
        {
            // Return the DAO method
            return _verseDAO.AddVerse(verse);
        }

        /// <summary>
        /// Get a list of verses from the inventory
        /// </summary>
        /// <returns></returns>
        public List<VerseDisplayModel> GetAllVerses()
        {
            // Get the verses from the DAO
            List<VerseDataModel> dataVerses = _verseDAO.GetAllVerses();

            // Convert to display models and return
            return ConvertVerseDataToDisplay(dataVerses);
        }

        /// <summary>
        /// Write the verses list to the given file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string WriteInventoryToFile(string fileName)
        {
            // Call and return the DAO method
            return _verseDAO.WriteVersesToFile(fileName);
        }

        /// <summary>
        /// Read the verses from the given file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ReadVersesFromFile(string fileName)
        {
            // Return the DAO method
            return _verseDAO.ReadVersesFromFile(fileName);
        }

        /// <summary>
        /// Get a list of the least important verses
        /// </summary>
        /// <param name="numToFind"></param>
        /// <returns></returns>
        public List<VerseDisplayModel> GetLeastImportantVerses(int numToFind)
        {
            // Get a list of the least important data verses
            List<VerseDataModel> dataVerses = _verseDAO.GetLeastImportantVerses(numToFind);
            // Convert the dataVerses list to a displayVerses list and return
            return ConvertVerseDataToDisplay(dataVerses);
        }

        /// <summary>
        /// Convert a list of VerseDataModels to VerseDisplayModels
        /// </summary>
        /// <param name="dataVerses"></param>
        /// <returns></returns>
        public List<VerseDisplayModel> ConvertVerseDataToDisplay(List<VerseDataModel> dataVerses)
        {
            // Create a DisplayModel list
            List<VerseDisplayModel> displayVerses = new List<VerseDisplayModel>();
            string reference = "";

            // Loop through the dataVerses list
            foreach (VerseDataModel verse in dataVerses)
            {
                // Use the book, chapter, and verse to create the reference
                reference = $"{verse.Book} {verse.Chapter}:{verse.Verse}";
                // Create a display verse model using the VerseDataModel verse
                VerseDisplayModel displayVerse = new VerseDisplayModel(reference, verse.Text, verse.Meaning, verse.Importance);
                // Add the display model to the displayVerses list
                displayVerses.Add(displayVerse);
            }

            // Return the display verses list
            return displayVerses;
        }

        /// <summary>
        /// Get a list of the most important verses
        /// </summary>
        /// <param name="numToFind"></param>
        /// <returns></returns>
        public List<VerseDisplayModel> GetMostImportantVerses(int numToFind)
        {
            // Get a list of the most important data verses
            List<VerseDataModel> dataVerses = _verseDAO.GetMostImportantVerses(numToFind);
            // Convert the dataVerses list to a displayVerses list and return
            return ConvertVerseDataToDisplay(dataVerses);
        }
    }
}
