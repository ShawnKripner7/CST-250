/*
 * Shawn Kripner
 * CST-250
 * 4/15/2026
 * Minesweeper Project
 * Milestone 4
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;
using Microsoft.VisualBasic;

namespace MinesweeperGUI
{
    public partial class GameForm : Form
    {
        private BoardModel _board;
        private BoardService _service;
        private Button[,] _buttons;
        private bool _rewardAvailable = false;
        private int _score = 0;

        public GameForm(int boardSize, int difficulty)
        {
            InitializeComponent();
            StartGame(boardSize, difficulty);
        }

        private void StartGame(int boardSize, int difficulty)
        {
            // create the board and service using the values from the setup form
            _board = new BoardModel(boardSize);
            _board.Difficulty = difficulty;
            _board.StartTime = DateTime.Now;
            _board.GameState = "StillPlaying";

            _service = new BoardService(_board);
            _service.SetupBombs();
            _service.CountBombsNearby();

            // build the clickable board and show the first screen
            BuildButtons();
            UpdateBoard();
            UpdateLabels();
        }

        private void BuildButtons()
        {
            panelBoard.Controls.Clear();
            _buttons = new Button[_board.Size, _board.Size];

            int buttonSize = Math.Max(28, 520 / _board.Size);

            panelBoard.Width = buttonSize * _board.Size;
            panelBoard.Height = buttonSize * _board.Size;

            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    Button button = new Button();
                    button.Width = buttonSize;
                    button.Height = buttonSize;
                    button.Left = col * buttonSize;
                    button.Top = row * buttonSize;
                    button.Tag = new Point(row, col);
                    button.Margin = new Padding(0);
                    button.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.MouseUp += BoardButton_MouseUp;

                    panelBoard.Controls.Add(button);
                    _buttons[row, col] = button;
                }
            }
        }

        private void BoardButton_MouseUp(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point cellPoint = (Point)clickedButton.Tag;

            int row = cellPoint.X;
            int col = cellPoint.Y;

            // stop if the game already ended
            if (_board.GameState == "Won" || _board.GameState == "Lost")
            {
                return;
            }

            // right click places or removes a flag
            if (e.Button == MouseButtons.Right)
            {
                // only let the user flag cells that are still hidden
                if (_board.Cells[row, col].IsVisited == false)
                {
                    _service.FlagCell(row, col);
                }
            }
            // left click visits a cell
            else if (e.Button == MouseButtons.Left)
            {
                // do not let the user open flagged cells
                if (_board.Cells[row, col].IsFlagged == true)
                {
                    MessageBox.Show("That cell is flagged.");
                    return;
                }

                // check reward before visit clears it off the cell
                bool foundReward = _board.Cells[row, col].HasSpecialReward;

                bool hitBomb = _service.VisitCell(row, col);

                if (foundReward)
                {
                    _rewardAvailable = true;
                    _board.RewardsRemaining++;
                    MessageBox.Show("You found a reward.");
                }

                if (hitBomb)
                {
                    _board.GameState = "Lost";
                }
            }

            // update the board state after every move
            if (_board.GameState != "Lost")
            {
                _board.GameState = _service.DetermineGameState();
            }

            if (_board.GameState == "Won" || _board.GameState == "Lost")
            {
                _board.EndTime = DateTime.Now;
                RevealBombs();
                CalculateScore();
                ShowGameResult();
            }

            UpdateBoard();
            UpdateLabels();
        }

        private void UpdateBoard()
        {
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    CellModel cell = _board.Cells[row, col];
                    Button button = _buttons[row, col];

                    // clear old text and image first
                    button.Text = "";
                    button.BackgroundImage = null;
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black;

                    // flagged cell
                    if (cell.IsFlagged == true && cell.IsVisited == false)
                    {
                        button.BackgroundImage = Properties.Resources.Tile2;
                    }
                    // hidden cell
                    else if (cell.IsVisited == false)
                    {
                        button.BackgroundImage = Properties.Resources.Tile1;
                    }
                    // bomb cell
                    else if (cell.IsBomb == true)
                    {
                        button.BackgroundImage = Properties.Resources.Skull;
                    }
                    // reward cell
                    else if (cell.HasSpecialReward == true)
                    {
                        button.BackgroundImage = Properties.Resources.Gold;
                    }
                    // numbered cell
                    else if (cell.NumberOfBombNeighbors > 0)
                    {
                        switch (cell.NumberOfBombNeighbors)
                        {
                            case 1:
                                button.BackgroundImage = Properties.Resources.Number1;
                                break;
                            case 2:
                                button.BackgroundImage = Properties.Resources.Number2;
                                break;
                            case 3:
                                button.BackgroundImage = Properties.Resources.Number3;
                                break;
                            case 4:
                                button.BackgroundImage = Properties.Resources.Number4;
                                break;
                            case 5:
                                button.BackgroundImage = Properties.Resources.Number5;
                                break;
                            case 6:
                                button.BackgroundImage = Properties.Resources.Number6;
                                break;
                            case 7:
                                button.BackgroundImage = Properties.Resources.Number7;
                                break;
                            case 8:
                                button.BackgroundImage = Properties.Resources.Number8;
                                break;
                        }
                    }
                    // empty revealed cell
                    else
                    {
                        button.BackgroundImage = Properties.Resources.TileFlat;
                    }
                }
            }
        }

        private void UpdateLabels()
        {
            lblSize.Text = "Size: " + _board.Size + " x " + _board.Size;
            lblDifficulty.Text = "Difficulty: " + _board.Difficulty;
            lblReward.Text = "Reward Ready: " + (_rewardAvailable ? "Yes" : "No");
            lblStatus.Text = "Status: " + _board.GameState;
            lblScore.Text = "Score: " + _score;
        }

        private void RevealBombs()
        {
            // show every bomb when the game ends
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    if (_board.Cells[row, col].IsBomb == true)
                    {
                        _board.Cells[row, col].IsVisited = true;
                    }
                }
            }
        }

        private void CalculateScore()
        {
            // basic score formula using size, difficulty, and elapsed time
            TimeSpan elapsedTime = _board.EndTime - _board.StartTime;
            int timeSeconds = (int)elapsedTime.TotalSeconds;

            _score = (_board.Size * 50) + (_board.Difficulty * 100) - timeSeconds;

            if (_score < 0)
            {
                _score = 0;
            }
        }

        private void ShowGameResult()
        {
            if (_board.GameState == "Won")
            {
                MessageBox.Show("You win! Score: " + _score);
            }
            else if (_board.GameState == "Lost")
            {
                MessageBox.Show("You hit a bomb. Game over.");
            }
        }

        private void btnUseReward_Click(object sender, EventArgs e)
        {
            // do not let the player use reward if none is ready
            if (_rewardAvailable == false)
            {
                MessageBox.Show("No reward available.");
                return;
            }

            // ask the player for the row and column to peek at
            string rowInput = Interaction.InputBox("Enter row to peek at:", "Use Reward", "0");
            string colInput = Interaction.InputBox("Enter column to peek at:", "Use Reward", "0");

            if (int.TryParse(rowInput, out int row) == false || int.TryParse(colInput, out int col) == false)
            {
                MessageBox.Show("Invalid row or column.");
                return;
            }

            if (row < 0 || row >= _board.Size || col < 0 || col >= _board.Size)
            {
                MessageBox.Show("That spot is outside the board.");
                return;
            }

            MessageBox.Show(_service.UseReward(row, col));
            _rewardAvailable = false;
            UpdateLabels();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // go back to the setup form
            Form1 setupForm = new Form1();
            setupForm.Show();
            Close();
        }
    }
}