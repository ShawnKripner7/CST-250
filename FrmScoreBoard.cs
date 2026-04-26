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
            // save each game stat as one line in the file
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (GameStat stat in _stats)
                {
                    writer.WriteLine(stat.Id + "," + stat.Name + "," + stat.Score + "," +
                        stat.GameTime.TotalSeconds + "," + stat.DatePlayed);
                }
            }

            MessageBox.Show("Scores saved.");
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(_filePath) == false)
            {
                MessageBox.Show("No score file found.");
                return;
            }

            _stats.Clear();

            string[] lines = File.ReadAllLines(_filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 5)
                {
                    int id = Convert.ToInt32(parts[0]);
                    string name = parts[1];
                    int score = Convert.ToInt32(parts[2]);
                    TimeSpan gameTime = TimeSpan.FromSeconds(Convert.ToDouble(parts[3]));

                    GameStat stat = new GameStat(id, name, score, gameTime);
                    stat.DatePlayed = Convert.ToDateTime(parts[4]);

                    _stats.Add(stat);
                }
            }

            UpdateGrid();
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