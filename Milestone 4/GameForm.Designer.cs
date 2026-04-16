/*
 * Shawn Kripner
 * CST-250
 * 4/15/2026
 * Minesweeper Project
 * Milestone 4
 */

namespace MinesweeperGUI
{
    partial class GameForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelBoard;
        private Label lblSize;
        private Label lblDifficulty;
        private Label lblReward;
        private Label lblStatus;
        private Label lblScore;
        private Button btnUseReward;
        private Button btnBack;

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
            panelBoard = new Panel();
            lblSize = new Label();
            lblDifficulty = new Label();
            lblReward = new Label();
            lblStatus = new Label();
            lblScore = new Label();
            btnUseReward = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // panelBoard
            // 
            panelBoard.BorderStyle = BorderStyle.FixedSingle;
            panelBoard.Location = new Point(20, 20);
            panelBoard.Name = "panelBoard";
            panelBoard.Size = new Size(520, 520);
            panelBoard.TabIndex = 0;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(565, 40);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(27, 15);
            lblSize.TabIndex = 1;
            lblSize.Text = "Size";
            // 
            // lblDifficulty
            // 
            lblDifficulty.AutoSize = true;
            lblDifficulty.Location = new Point(565, 75);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(54, 15);
            lblDifficulty.TabIndex = 2;
            lblDifficulty.Text = "Difficulty";
            // 
            // lblReward
            // 
            lblReward.AutoSize = true;
            lblReward.Location = new Point(565, 110);
            lblReward.Name = "lblReward";
            lblReward.Size = new Size(46, 15);
            lblReward.TabIndex = 3;
            lblReward.Text = "Reward";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(565, 145);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(565, 180);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(36, 15);
            lblScore.TabIndex = 5;
            lblScore.Text = "Score";
            // 
            // btnUseReward
            // 
            btnUseReward.Location = new Point(565, 230);
            btnUseReward.Name = "btnUseReward";
            btnUseReward.Size = new Size(150, 40);
            btnUseReward.TabIndex = 6;
            btnUseReward.Text = "Use Reward";
            btnUseReward.UseVisualStyleBackColor = true;
            btnUseReward.Click += btnUseReward_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(565, 285);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(150, 40);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back to Setup";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(745, 565);
            Controls.Add(btnBack);
            Controls.Add(btnUseReward);
            Controls.Add(lblScore);
            Controls.Add(lblStatus);
            Controls.Add(lblReward);
            Controls.Add(lblDifficulty);
            Controls.Add(lblSize);
            Controls.Add(panelBoard);
            Name = "GameForm";
            Text = "Minesweeper";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}