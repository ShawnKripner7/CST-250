/*
 * Shawn Kripner
 * CST-250
 * 4/20/2026
 * Whack-A-Mole
 * Activity 5
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using WhackAMole.Models;
using WhackAMole.BusinessLogicLayer;
using WhackAMole.DataAccessLayer;

namespace WhackAMole
{
    public partial class FrmStopwatch : Form
    {
        // Keeps track of how much time has passed
        TimeSpan timeElapsed = new TimeSpan();

        // Used to move the target to random spots
        Random random = new Random();

        // Keeps track of the player's score
        int score = 0;

        // Keeps track of the current level
        int level = 1;

        // Stores game data separately from the UI
        GameStatsModel gameStats = new GameStatsModel();

        // Handles game rules like score and level
        GameLogic gameLogic = new GameLogic();

        // Handles saving game data
        GameStatsDAO gameStatsDAO = new GameStatsDAO();

        public FrmStopwatch()
        {
            InitializeComponent();

            // Set up some simple graphics when the form loads
            this.BackColor = Color.LightYellow;

            // Make labels easier to read
            lblScore.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTimeElapsed.Font = new Font("Arial", 12, FontStyle.Bold);

            // Set starting label text
            lblTimeElapsed.Text = "Time: 0";
            lblScore.Text = "Score: 0";
            lblLevel.Text = "Level: 1";

            // Style the target button
            btnTarget.BackColor = Color.Green;
            btnTarget.ForeColor = Color.White;
            btnTarget.Font = new Font("Arial", 10, FontStyle.Bold);

            // Style the decoy button
            btnDecoy.BackColor = Color.Red;
            btnDecoy.ForeColor = Color.White;
            btnDecoy.Font = new Font("Arial", 10, FontStyle.Bold);
            btnDecoy.Visible = false;
        }

        /// <summary>
        /// Starts the timer when the Start button is clicked.
        /// </summary>
        private void BtnStartClickEH(object sender, EventArgs e)
        {
            // Start the game timer
            tmrStopwatch.Start();
        }

        /// <summary>
        /// Stops the timer when the Stop button is clicked.
        /// </summary>
        private void BtnStopClickEH(object sender, EventArgs e)
        {
            // Stop the game timer
            tmrStopwatch.Stop();
        }

        /// <summary>
        /// Updates the timer, moves the target and decoy,
        /// increases difficulty, and checks if the game should end.
        /// </summary>
        private void TmrStopwatchTickEH(object sender, EventArgs e)
        {
            // Get the timer interval
            int interval = tmrStopwatch.Interval;

            // Add the timer interval to the total time
            timeElapsed = timeElapsed.Add(TimeSpan.FromMilliseconds(interval));

            // Show the updated time on the label
            lblTimeElapsed.Text = "Time: " + ((int)timeElapsed.TotalSeconds);

            // Update model time
            gameStats.TimeElapsed = timeElapsed;

            // Move the target and decoy every 3 seconds
            if (timeElapsed.Seconds % 3 == 0)
            {
                // Move the target
                btnTarget.Top = random.Next(0, this.Height - btnTarget.Height);
                btnTarget.Left = random.Next(0, this.Height - btnTarget.Width);

                // Give the target a random color
                btnTarget.BackColor = Color.FromArgb(
                    random.Next(0, 256),
                    random.Next(0, 256),
                    random.Next(0, 256));

                // Show the target
                btnTarget.Visible = true;

                // Move the decoy
                btnDecoy.Top = random.Next(0, this.Height - btnDecoy.Height);
                btnDecoy.Left = random.Next(0, this.Height - btnDecoy.Width);

                // Show the decoy
                btnDecoy.Visible = true;
            }

            // Increase difficulty based on level
            if (level == 2)
            {
                // Make the game a little faster and smaller
                tmrStopwatch.Interval = 800;
                btnTarget.Width = 70;
                btnTarget.Height = 70;
            }
            else if (level == 3)
            {
                // Make the game even harder
                tmrStopwatch.Interval = 600;
                btnTarget.Width = 50;
                btnTarget.Height = 50;
            }

            // End the game if the player reaches 10 points or 30 seconds
            if (gameLogic.IsGameOver(score, timeElapsed.TotalSeconds))
            {
                // Stop the timer
                tmrStopwatch.Stop();

                // Save the game results
                gameStatsDAO.SaveGameStats(gameStats);

                // Show game over message
                MessageBox.Show("Game Over!");
            }
        }

        /// <summary>
        /// Stops the timer and resets the game time.
        /// </summary>
        private void BtnResetClickEH(object sender, EventArgs e)
        {
            // Stop the timer
            tmrStopwatch.Stop();

            // Reset the time back to zero
            timeElapsed = new TimeSpan();

            // Show the reset time on the label
            lblTimeElapsed.Text = "Time: 0";

            // Reset the score back to zero
            score = 0;
            lblScore.Text = "Score: 0";

            // Reset the level back to one
            level = 1;
            lblLevel.Text = "Level: 1";
        }

        /// <summary>
        /// Handles clicking the target button.
        /// Adds to the score and hides the target.
        /// </summary>
        private void BtnTargetClickEH(object sender, EventArgs e)
        {
            // Add a point using business logic
            score = gameLogic.AddPoint(score);

            // Update score label
            lblScore.Text = "Score: " + score;

            // Get level from business logic
            level = gameLogic.GetLevel(score);

            // Update level label
            lblLevel.Text = "Level: " + level;

            // Update the model with current values
            gameStats.Score = score;
            gameStats.Level = level;

            // Reward messages for milestones
            if (score == 5)
            {
                MessageBox.Show("Nice! You reached 5 points!");
            }
            else if (score == 10)
            {
                MessageBox.Show("Great job! You reached 10 points!");
            }

            // Hide the target after it is clicked
            btnTarget.Visible = false;
        }

        /// <summary>
        /// Handles clicks on the form.
        /// Subtracts a point if the player misses the target.
        /// </summary>
        private void FrmStopwatchClickEH(object sender, EventArgs e)
        {
            // Remove a point using business logic
            score = gameLogic.RemovePoint(score);

            // Update the score label
            lblScore.Text = "Score: " + score;
        }

        /// <summary>
        /// Handles clicking the decoy button.
        /// Takes away a point and hides the decoy.
        /// </summary>
        private void BtnDecoyClickEH(object sender, EventArgs e)
        {
            // Remove a point using business logic
            score = gameLogic.RemovePoint(score);

            // Update the score label
            lblScore.Text = "Score: " + score;

            // Hide the decoy after it is clicked
            btnDecoy.Visible = false;
        }

        /// <summary>
        /// Keeps buttons at the bottom when the form is resized.
        /// </summary>
        private void FrmStopwatch_Resize(object sender, EventArgs e)
        {
            // Keep Start, Stop, Reset near the bottom
            btnStart.Top = this.Height - 80;
            btnStop.Top = this.Height - 80;
            btnReset.Top = this.Height - 80;

            // Keep spacing between buttons
            btnStart.Left = 20;
            btnStop.Left = btnStart.Right + 20;
            btnReset.Left = btnStop.Right + 20;

            // Keep score and level near top right
            lblScore.Left = this.Width - 120;
            lblLevel.Left = this.Width - 120;
        }
    }
}