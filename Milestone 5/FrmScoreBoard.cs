/*
 * Shawn Kripner
 * CST-250
 * 4/23/2026
 * Minesweeper Project
 * Milestone 5
 */

using MinesweeperClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class FrmScoreBoard : Form
    {
        // stores the game stats shown in the grid
        private List<GameStat> _stats = new List<GameStat>();

        // text file used for saving and loading scores
        private string _filePath = "scores.txt";

        public FrmScoreBoard(GameStat stat)
        {
            InitializeComponent();

            // add the newest score from the game that was just won
            _stats.Add(stat);

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            // refresh the grid with the current list
            dgvScores.DataSource = null;
            dgvScores.DataSource = _stats;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open a file to write the scores to
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                // loop through each game stat in the list
                foreach (GameStat stat in _stats)
                {
                    // write each stat as a single line separated by commas
                    writer.WriteLine(stat.Id + "," + stat.Name + "," + stat.Score + "," +
                        stat.GameTime.TotalSeconds + "," + stat.DatePlayed);
                }
            }

            // let the user know the file was saved
            MessageBox.Show("Scores saved.");
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // check if the file exists before trying to read it
            if (File.Exists(_filePath) == false)
            {
                MessageBox.Show("No score file found.");
                return;
            }

            // clear the current list so we don't duplicate data
            _stats.Clear();

            // read all lines from the file
            string[] lines = File.ReadAllLines(_filePath);

            // loop through each line in the file
            foreach (string line in lines)
            {
                // split the line into parts using commas
                string[] parts = line.Split(',');

                // make sure the data is valid before using it
                if (parts.Length == 5)
                {
                    int id = Convert.ToInt32(parts[0]);
                    string name = parts[1];
                    int score = Convert.ToInt32(parts[2]);
                    TimeSpan gameTime = TimeSpan.FromSeconds(Convert.ToDouble(parts[3]));

                    // create a new GameStat object using the data
                    GameStat stat = new GameStat(id, name, score, gameTime);

                    // set the date separately
                    stat.DatePlayed = Convert.ToDateTime(parts[4]);

                    // add the stat to the list
                    _stats.Add(stat);
                }
            }

            // update the grid to show loaded data
            UpdateGrid();

            // let the user know the load worked
            MessageBox.Show("Scores loaded.");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // sort scores alphabetically by player name
            _stats = _stats.OrderBy(stat => stat.Name).ToList();
            UpdateGrid();
        }

        private void byScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // sort highest score first
            _stats = _stats.OrderByDescending(stat => stat.Score).ToList();
            UpdateGrid();
        }

        private void byDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // sort newest games first
            _stats = _stats.OrderByDescending(stat => stat.DatePlayed).ToList();
            UpdateGrid();
        }
    }
}