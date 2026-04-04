/* 
 * Shawn Kripner
 * CST-250
 * 4/3/2026
 * Chess Board Project
 * Activity 2
 */

using ChessBoardClassLibrary.Models;
using ChessBoardClassLibrary.Services.BusinessLogicLayer;

namespace ChessBoardGUIApp
{
    public partial class FrmChessBoard : Form
    {
        // Class level variables
        private BoardModel _board;
        private BoardLogic _boardLogic;

        // 2D array of buttons for the chess board
        private Button[,] _buttons;

        // colors for the board themes
        private Color _lightSquareColor;
        private Color _darkSquareColor;
        private Color _legalMoveColor;
        private Color _pieceColor;
        private Color _textColor;

        /// <summary>
        /// Default constructor for FrmChessBoard
        /// </summary>
        public FrmChessBoard()
        {
            InitializeComponent();

            // Initialize class level variables
            _board = new BoardModel(8);
            _boardLogic = new BoardLogic();
            _buttons = new Button[8, 8];

            // load the theme choices into the combo box
            LoadThemes();

            // set the first theme as the default
            cmbThemes.SelectedIndex = 0;

            // Set up the panel with buttons
            SetUpButtons();

            // apply the selected theme colors to the board
            ApplyTheme();
        }

        // puts all of the theme names into the combo box
        private void LoadThemes()
        {
            cmbThemes.Items.Clear();
            cmbThemes.Items.Add("Classic");
            cmbThemes.Items.Add("Cool Colors");
            cmbThemes.Items.Add("Warm Colors");
            cmbThemes.Items.Add("Neon");
            cmbThemes.Items.Add("Pastel");
            cmbThemes.Items.Add("Nature");
            cmbThemes.Items.Add("Checkerboard");
            cmbThemes.Items.Add("Crazy Colors");
        }

        /// <summary>
        /// Populate the panel control with buttons
        /// </summary>
        private void SetUpButtons()
        {
            // make sure the board was created
            if (_board == null)
            {
                MessageBox.Show("Board could not be created.");
                return;
            }

            // make sure the board size is valid
            if (_board.Size <= 0)
            {
                MessageBox.Show("Board size is invalid.");
                return;
            }

            // make sure the panel has a valid width
            if (pnlChessBoard.Width <= 0)
            {
                MessageBox.Show("Panel size is invalid.");
                return;
            }

            // clear out anything old before making the board again
            pnlChessBoard.Controls.Clear();

            // Declare and initialize
            // Calculate the size of each button based on
            // the panel width and the number of buttons needed
            int buttonSize = pnlChessBoard.Width / _board.Size;

            // make sure the button size is not too small
            if (buttonSize <= 0)
            {
                MessageBox.Show("Button size is invalid.");
                return;
            }

            // Set the panel to be square
            pnlChessBoard.Height = pnlChessBoard.Width;

            // Use nested for loops to loop through the boards Grid
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    // Set up each individual button
                    _buttons[row, col] = new Button();

                    // Get the current button
                    Button button = _buttons[row, col];

                    // Set the size for the button
                    button.Width = buttonSize;
                    button.Height = buttonSize;

                    // Set the location of the button
                    button.Left = col * buttonSize;
                    button.Top = row * buttonSize;

                    // Attach a click event handler to the button
                    button.Click += BtnSquareClickEH;

                    // Store the location using Tag
                    button.Tag = new Point(row, col);

                    // keep the squares blank until a piece is selected
                    button.Text = "";

                    // makes the buttons look a little cleaner
                    button.FlatStyle = FlatStyle.Flat;
                    button.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                    // Add button to panel
                    pnlChessBoard.Controls.Add(button);
                }
            }

        } // End of SetUpButtons method

        /// <summary>
        /// Click Event Handler for the chess board buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSquareClickEH(object sender, EventArgs e)
        {
            // Make sure a piece is selected
            if (string.IsNullOrWhiteSpace(cmbChessPieces.Text))
            {
                MessageBox.Show("Please select a chess piece first.");
                return;
            }

            // Make sure the sender is really a button
            if (!(sender is Button button))
            {
                MessageBox.Show("Invalid button selection.");
                return;
            }

            // Make sure the Tag has a point stored in it
            if (!(button.Tag is Point point))
            {
                MessageBox.Show("Button location could not be found.");
                return;
            }

            // Get row and column
            int row = point.X;
            int col = point.Y;

            // Check bounds
            if (row < 0 || row >= _board.Size || col < 0 || col >= _board.Size)
            {
                MessageBox.Show("That location is outside the board.");
                return;
            }

            // make sure the board grid and selected cell both exist
            if (_board == null || _board.Grid == null || _board.Grid[row, col] == null)
            {
                MessageBox.Show("That cell is invalid.");
                return;
            }

            // Get selected piece
            string piece = cmbChessPieces.Text.Trim();

            // make sure the selected piece is one of the valid options
            List<string> validPieces = new List<string> { "Knight", "Rook", "Bishop", "Queen", "King" };
            if (!validPieces.Contains(piece))
            {
                MessageBox.Show("Please select a valid chess piece.");
                return;
            }

            try
            {
                // Send the board, current cell, and piece to the business logic layer
                _board = _boardLogic.MarkLegalMoves(_board, _board.Grid[row, col], piece);

                // Update the buttons
                UpdateButtons();

                // put the selected colors back on the board
                ApplyTheme();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error happened while marking legal moves: " + ex.Message);
            }
        }

        /// <summary>
        /// Update the text for each button based on the board
        /// </summary>
        private void UpdateButtons()
        {
            // Declare and initialize
            string piece;

            // Set up a dictionary to get the names of the chess pieces
            Dictionary<string, string> pieceMap = new Dictionary<string, string>
            {
                { "N", "Knight" },
                { "R", "Rook" },
                { "B", "Bishop" },
                { "Q", "Queen" },
                { "K", "King" }
            };

            // make sure the board data is there before updating
            if (_board == null || _board.Grid == null)
            {
                MessageBox.Show("Board data is not available.");
                return;
            }

            // Loop through each cell in the grid to update the corresponding button
            for (int row = 0; row < _board.Size; ++row)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    // skip anything that was not created correctly
                    if (_buttons[row, col] == null || _board.Grid[row, col] == null)
                    {
                        continue;
                    }

                    if (_board.Grid[row, col].PieceOccupyingCell != "")
                    {
                        // Use the dictionary to get the name of the chess piece
                        if (pieceMap.ContainsKey(_board.Grid[row, col].PieceOccupyingCell))
                        {
                            piece = pieceMap[_board.Grid[row, col].PieceOccupyingCell];

                            // Update the text for the button
                            _buttons[row, col].Text = piece;
                        }
                        else
                        {
                            _buttons[row, col].Text = _board.Grid[row, col].PieceOccupyingCell;
                        }
                    }
                    else if (_board.Grid[row, col].IsLegalNextMove)
                    {
                        // Set the text to show a legal move
                        _buttons[row, col].Text = "Legal Move";
                    }
                    else
                    {
                        // Clear the text for any other buttons
                        _buttons[row, col].Text = "";
                    }
                }
            }

        } // End of UpdateButtons method

        // changes the board colors based on the selected theme
        private void ApplyTheme()
        {
            SetThemeColors();

            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    if (_buttons[row, col] == null || _board.Grid[row, col] == null)
                    {
                        continue;
                    }

                    Button button = _buttons[row, col];

                    if (_board.Grid[row, col].IsLegalNextMove)
                    {
                        button.BackColor = _legalMoveColor;
                    }
                    else if (!string.IsNullOrEmpty(_board.Grid[row, col].PieceOccupyingCell))
                    {
                        button.BackColor = _pieceColor;
                    }
                    else
                    {
                        if ((row + col) % 2 == 0)
                        {
                            button.BackColor = _lightSquareColor;
                        }
                        else
                        {
                            button.BackColor = _darkSquareColor;
                        }
                    }

                    button.ForeColor = _textColor;
                }
            }
        }

        // sets the colors for each theme
        private void SetThemeColors()
        {
            string selectedTheme = cmbThemes.Text;

            switch (selectedTheme)
            {
                case "Cool Colors":
                    _lightSquareColor = Color.LightBlue;
                    _darkSquareColor = Color.SteelBlue;
                    _legalMoveColor = Color.Aqua;
                    _pieceColor = Color.MediumSlateBlue;
                    _textColor = Color.Black;
                    break;

                case "Warm Colors":
                    _lightSquareColor = Color.Moccasin;
                    _darkSquareColor = Color.IndianRed;
                    _legalMoveColor = Color.Gold;
                    _pieceColor = Color.OrangeRed;
                    _textColor = Color.Black;
                    break;

                case "Neon":
                    _lightSquareColor = Color.HotPink;
                    _darkSquareColor = Color.Lime;
                    _legalMoveColor = Color.Yellow;
                    _pieceColor = Color.Cyan;
                    _textColor = Color.Black;
                    break;

                case "Pastel":
                    _lightSquareColor = Color.LavenderBlush;
                    _darkSquareColor = Color.LightPink;
                    _legalMoveColor = Color.PaleTurquoise;
                    _pieceColor = Color.Plum;
                    _textColor = Color.Black;
                    break;

                case "Nature":
                    _lightSquareColor = Color.Beige;
                    _darkSquareColor = Color.ForestGreen;
                    _legalMoveColor = Color.YellowGreen;
                    _pieceColor = Color.SaddleBrown;
                    _textColor = Color.White;
                    break;

                case "Checkerboard":
                    _lightSquareColor = Color.White;
                    _darkSquareColor = Color.Black;
                    _legalMoveColor = Color.Red;
                    _pieceColor = Color.Gray;
                    _textColor = Color.White;
                    break;

                case "Crazy Colors":
                    _lightSquareColor = Color.Magenta;
                    _darkSquareColor = Color.Chartreuse;
                    _legalMoveColor = Color.Orange;
                    _pieceColor = Color.DeepSkyBlue;
                    _textColor = Color.Black;
                    break;

                default:
                    _lightSquareColor = Color.Beige;
                    _darkSquareColor = Color.Brown;
                    _legalMoveColor = Color.LightGreen;
                    _pieceColor = Color.Goldenrod;
                    _textColor = Color.Black;
                    break;
            }
        }

        // updates the colors when a new theme is picked
        private void cmbThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyTheme();
        }
    }
}