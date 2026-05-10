/*
 * Shawn Kripner
 * CST-250
 * 4/15/2026
 * Minesweeper Project
 * Milestone 4
 */

namespace MinesweeperGUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblBoardSize;
        private Label lblSizeValue;
        private TrackBar trackBarSize;
        private GroupBox groupDifficulty;
        private RadioButton radioEasy;
        private RadioButton radioMedium;
        private RadioButton radioHard;
        private Button btnStart;
        private Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblBoardSize = new Label();
            lblSizeValue = new Label();
            trackBarSize = new TrackBar();
            groupDifficulty = new GroupBox();
            radioHard = new RadioButton();
            radioMedium = new RadioButton();
            radioEasy = new RadioButton();
            btnStart = new Button();
            btnExit = new Button();
            btnViewScores = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBarSize).BeginInit();
            groupDifficulty.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(75, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(238, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Minesweeper Setup";
            // 
            // lblBoardSize
            // 
            lblBoardSize.AutoSize = true;
            lblBoardSize.Location = new Point(40, 90);
            lblBoardSize.Name = "lblBoardSize";
            lblBoardSize.Size = new Size(64, 15);
            lblBoardSize.TabIndex = 1;
            lblBoardSize.Text = "Board Size:";
            // 
            // lblSizeValue
            // 
            lblSizeValue.AutoSize = true;
            lblSizeValue.Location = new Point(320, 90);
            lblSizeValue.Name = "lblSizeValue";
            lblSizeValue.Size = new Size(13, 15);
            lblSizeValue.TabIndex = 2;
            lblSizeValue.Text = "0";
            // 
            // trackBarSize
            // 
            trackBarSize.Location = new Point(40, 115);
            trackBarSize.Name = "trackBarSize";
            trackBarSize.Size = new Size(290, 45);
            trackBarSize.TabIndex = 3;
            trackBarSize.Scroll += trackBarSize_Scroll;
            // 
            // groupDifficulty
            // 
            groupDifficulty.Controls.Add(radioHard);
            groupDifficulty.Controls.Add(radioMedium);
            groupDifficulty.Controls.Add(radioEasy);
            groupDifficulty.Location = new Point(40, 170);
            groupDifficulty.Name = "groupDifficulty";
            groupDifficulty.Size = new Size(290, 115);
            groupDifficulty.TabIndex = 4;
            groupDifficulty.TabStop = false;
            groupDifficulty.Text = "Difficulty";
            // 
            // radioHard
            // 
            radioHard.AutoSize = true;
            radioHard.Location = new Point(20, 80);
            radioHard.Name = "radioHard";
            radioHard.Size = new Size(51, 19);
            radioHard.TabIndex = 2;
            radioHard.TabStop = true;
            radioHard.Text = "Hard";
            radioHard.UseVisualStyleBackColor = true;
            // 
            // radioMedium
            // 
            radioMedium.AutoSize = true;
            radioMedium.Location = new Point(20, 55);
            radioMedium.Name = "radioMedium";
            radioMedium.Size = new Size(70, 19);
            radioMedium.TabIndex = 1;
            radioMedium.TabStop = true;
            radioMedium.Text = "Medium";
            radioMedium.UseVisualStyleBackColor = true;
            // 
            // radioEasy
            // 
            radioEasy.AutoSize = true;
            radioEasy.Location = new Point(20, 30);
            radioEasy.Name = "radioEasy";
            radioEasy.Size = new Size(48, 19);
            radioEasy.TabIndex = 0;
            radioEasy.TabStop = true;
            radioEasy.Text = "Easy";
            radioEasy.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(40, 315);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(130, 40);
            btnStart.TabIndex = 5;
            btnStart.Text = "Start Game";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(200, 315);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(130, 40);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnViewScores
            // 
            btnViewScores.Location = new Point(124, 376);
            btnViewScores.Name = "btnViewScores";
            btnViewScores.Size = new Size(100, 23);
            btnViewScores.TabIndex = 7;
            btnViewScores.Text = "View Scores";
            btnViewScores.UseVisualStyleBackColor = true;
            btnViewScores.Click += btnViewScores_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 427);
            Controls.Add(btnViewScores);
            Controls.Add(btnExit);
            Controls.Add(btnStart);
            Controls.Add(groupDifficulty);
            Controls.Add(trackBarSize);
            Controls.Add(lblSizeValue);
            Controls.Add(lblBoardSize);
            Controls.Add(lblTitle);
            Name = "Form1";
            Text = "Minesweeper Setup";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBarSize).EndInit();
            groupDifficulty.ResumeLayout(false);
            groupDifficulty.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnViewScores;
    }
}