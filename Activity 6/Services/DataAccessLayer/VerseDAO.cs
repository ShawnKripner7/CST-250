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

        /// <summary>
        /// Get the list of verses in the inventory
        /// </summary>
        /// <returns></returns>
        public List<VerseDataModel> GetAllVerses()
        {
            // Return the _verses list
            return _verses;
        }

        /// <summary>
        /// Write the verses list to the given file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string WriteVersesToFile(string fileName)
        {
            // Declare and initialize
            string serialized = "";

            // Create a switch based on the file extension
            switch (Path.GetExtension(fileName))
            {
                case ".txt":
                    // Loop through the _verse list
                    foreach (VerseDataModel verse in _verses)
                    {
                        // Add each verse to the serialized string
                        serialized += verse.ToString() + "\n";
                    }
                    break;

                case ".xml":
                    // Serialize to XML
                    serialized = ServiceStack.Text.XmlSerializer.SerializeToString(_verses);
                    break;

                case ".csv":
                    // Use ServiceStack to serialize to csv
                    serialized = ServiceStack.Text.CsvSerializer.SerializeToString(_verses);
                    break;

                case ".json":
                    // Use ServiceStack to serialize to json
                    serialized = ServiceStack.Text.JsonSerializer.SerializeToString(_verses);
                    break;

                case ".xlsx":
                    // Set the license for EPPlus
                    OfficeOpenXml.ExcelPackage.License.SetNonCommercialPersonal("Student");

                    // Create a new Excel package
                    using (var package = new OfficeOpenXml.ExcelPackage())
                    {
                        // Add a worksheet to store the verses
                        var worksheet = package.Workbook.Worksheets.Add("Verses");

                        // Add column headers
                        worksheet.Cells[1, 1].Value = "Book";
                        worksheet.Cells[1, 2].Value = "Chapter";
                        worksheet.Cells[1, 3].Value = "Verse";
                        worksheet.Cells[1, 4].Value = "Text";
                        worksheet.Cells[1, 5].Value = "Meaning";
                        worksheet.Cells[1, 6].Value = "Importance";

                        int row = 2;

                        // Loop through the verses list and add each verse to a new row
                        foreach (var verse in _verses)
                        {
                            worksheet.Cells[row, 1].Value = verse.Book;
                            worksheet.Cells[row, 2].Value = verse.Chapter;
                            worksheet.Cells[row, 3].Value = verse.Verse;
                            worksheet.Cells[row, 4].Value = verse.Text;
                            worksheet.Cells[row, 5].Value = verse.Meaning;
                            worksheet.Cells[row, 6].Value = verse.Importance;
                            row++;
                        }

                        // Save the Excel file to the selected location
                        File.WriteAllBytes(fileName, package.GetAsByteArray());
                    }

                    // Return a success message
                    return "The verses have been saved to your Excel file";

                default:
                    return "File not recognized";
            }

            try
            {
                // Use File.WriteAllText to send the serialized string to the file
                File.WriteAllText(fileName, serialized);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            // Return a success message to the user
            return "The verses have been saved to your file";
        }

        /// <summary>
        /// Read verses from the given file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ReadVersesFromFile(string fileName)
        {
            // Declare and initialize
            string data = "";
            List<VerseDataModel> dataVerses = new List<VerseDataModel>();

            // Set up a try-catch to read files text
            try
            {
                // Get the text from the file
                data = File.ReadAllText(fileName);
            }
            catch (Exception ex)
            {
                // Return the exception message
                return ex.Message;
            }

            // Create a switch based on the file extension
            switch (Path.GetExtension(fileName))
            {
                case ".txt":
                    // Split the text file on the newline character
                    string[] lines = data.Split("\n");
                    // Loop through the array of lines
                    foreach (string line in lines)
                    {
                        // Check if each line contains data
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            // If so, convert the data to a VerseDataModel and add it to the dataVerses list
                            dataVerses.Add(ConvertTxtToVerseDataModel(line));
                        }
                    }
                    break;
                case ".xml":
                    // Deserialize XML
                    dataVerses = ServiceStack.Text.XmlSerializer.DeserializeFromString<List<VerseDataModel>>(data);
                    break;

                case ".json":
                    // Deserialize the data using the JsonSerializer
                    dataVerses = ServiceStack.Text.JsonSerializer.DeserializeFromString<List<VerseDataModel>>(data);
                    break;

                case ".csv":
                    // Deserialize the data using the CsvSerializer
                    dataVerses = ServiceStack.Text.CsvSerializer.DeserializeFromString<List<VerseDataModel>>(data);
                    break;

                default:
                    // Return the issue to the user
                    return "File not recognized";
            }

            // Loop through the dataVerses list
            foreach (VerseDataModel newVerse in dataVerses)
            {
                // Set the id for each new verse
                newVerse.Id = _verses.Count + 1;
                // Add the new verse to the _verses list
                _verses.Add(newVerse);
            }

            // Return a success message to the user
            return "The verses have been read from your file and added to the list";
        } // End of ReadVersesFromFile

        /// <summary>
        /// Take a line from the text file and return a VerseDataModel
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public VerseDataModel ConvertTxtToVerseDataModel(string line)
        {
            // Declare and initialize
            string[] values;
            int chapter = 0, importance = 0;
            VerseDataModel verse;

            // Split the line on '* '
            values = line.Split("* ");
            // Use a try parse to parse the chapter
            int.TryParse(values[1], out chapter);
            // Parse the importance
            int.TryParse(values[5], out importance);
            // Create the new verse
            verse = new VerseDataModel(0, values[0], chapter, values[2], values[3], values[4], importance);
            // Return the verse
            return verse;
        }

        /// <summary>
        /// Get a list of the least important verses
        /// </summary>
        /// <param name="numToFind"></param>
        /// <returns></returns>
        public List<VerseDataModel> GetLeastImportantVerses(int numToFind)
        {
            // Use LINQ query syntax to order the verses and select how many are needed based on the numToFind parameter
            List<VerseDataModel> leastImportantVerses = (from verse in _verses
                                                         orderby verse.Importance
                                                         select verse).Take(numToFind).ToList();

            // Return the list of least important verses
            return leastImportantVerses;
        }

        /// <summary>
        /// Get a list of the most important verses
        /// </summary>
        /// <param name="numToFind"></param>
        /// <returns></returns>
        public List<VerseDataModel> GetMostImportantVerses(int numToFind)
        {
            // Use LINQ method syntax to order the verses and select how
            // many are needed based on the numToFind parameter
            List<VerseDataModel> mostImportantVerses = _verses.OrderByDescending(verse => verse.Importance).Take(numToFind).ToList();
            // Return the list of most important verses
            return mostImportantVerses;
        }
    }
}