/*
 * Shawn Kripner
 * CST-250
 * 4/23/2026
 * Minesweeper Project
 * Milestone 5
 */

using System;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class FrmPlayerName : Form
    {
        // holds the player's name
        public string PlayerName { get; private set; }

        public FrmPlayerName()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // make sure something was entered
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter your name.");
                return;
            }

            PlayerName = txtName.Text;

            // close form and return to GameForm
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}