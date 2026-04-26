/*
 * Shawn Kripner
 * CST-250
 * 4/23/2026
 * Minesweeper Project
 * Milestone 5
 */

using MinesweeperClassLibrary.Models;
using System;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // set up default size values
            trackBarSize.Minimum = 5;
            trackBarSize.Maximum = 15;
            trackBarSize.Value = 10;
            lblSizeValue.Text = trackBarSize.Value.ToString();

            // default difficulty starts on easy
            radioEasy.Checked = true;
        }

        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
            // show the current board size next to the trackbar
            lblSizeValue.Text = trackBarSize.Value.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int boardSize = trackBarSize.Value;
            int difficulty = GetDifficultyLevel();

            // open the game form with the size and difficulty the user picked
            GameForm gameForm = new GameForm(boardSize, difficulty);
            gameForm.Show();
            Hide();
        }

        private int GetDifficultyLevel()
        {
            // easy, medium, and hard are stored as numbers
            if (radioEasy.Checked)
            {
                return 1;
            }
            else if (radioMedium.Checked)
            {
                return 2;
            }

            return 3;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnViewScores_Click(object sender, EventArgs e)
        {
            GameStat demoStat = new GameStat(0, "Demo Player", 500, TimeSpan.FromSeconds(45));

            FrmScoreBoard scoreBoard = new FrmScoreBoard(demoStat);
            scoreBoard.Show();
        }
    }
}