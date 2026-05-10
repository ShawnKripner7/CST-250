namespace MinesweeperGUI
{
    partial class FrmScoreBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvScores = new DataGridView();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            sortToolStripMenuItem = new ToolStripMenuItem();
            byNameToolStripMenuItem = new ToolStripMenuItem();
            byScoreToolStripMenuItem = new ToolStripMenuItem();
            byDateToolStripMenuItem = new ToolStripMenuItem();
            lblAverageTime = new Label();
            lblAverageScore = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvScores).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvScores
            // 
            dgvScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScores.Dock = DockStyle.Fill;
            dgvScores.Location = new Point(0, 24);
            dgvScores.Name = "dgvScores";
            dgvScores.Size = new Size(889, 517);
            dgvScores.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, sortToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(889, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(100, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(100, 22);
            loadToolStripMenuItem.Text = "Load";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(100, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // sortToolStripMenuItem
            // 
            sortToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { byNameToolStripMenuItem, byScoreToolStripMenuItem, byDateToolStripMenuItem });
            sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            sortToolStripMenuItem.Size = new Size(40, 20);
            sortToolStripMenuItem.Text = "Sort";
            // 
            // byNameToolStripMenuItem
            // 
            byNameToolStripMenuItem.Name = "byNameToolStripMenuItem";
            byNameToolStripMenuItem.Size = new Size(122, 22);
            byNameToolStripMenuItem.Text = "By Name";
            // 
            // byScoreToolStripMenuItem
            // 
            byScoreToolStripMenuItem.Name = "byScoreToolStripMenuItem";
            byScoreToolStripMenuItem.Size = new Size(122, 22);
            byScoreToolStripMenuItem.Text = "By Score";
            // 
            // byDateToolStripMenuItem
            // 
            byDateToolStripMenuItem.Name = "byDateToolStripMenuItem";
            byDateToolStripMenuItem.Size = new Size(122, 22);
            byDateToolStripMenuItem.Text = "By Date";
            // 
            // lblAverageTime
            // 
            lblAverageTime.AutoSize = true;
            lblAverageTime.Location = new Point(0, 475);
            lblAverageTime.Name = "lblAverageTime";
            lblAverageTime.Size = new Size(83, 15);
            lblAverageTime.TabIndex = 2;
            lblAverageTime.Text = "Average Time:";
            // 
            // lblAverageScore
            // 
            lblAverageScore.AutoSize = true;
            lblAverageScore.Location = new Point(-2, 509);
            lblAverageScore.Name = "lblAverageScore";
            lblAverageScore.Size = new Size(85, 15);
            lblAverageScore.TabIndex = 3;
            lblAverageScore.Text = "Average Score:";
            // 
            // FrmScoreBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(889, 541);
            Controls.Add(lblAverageScore);
            Controls.Add(lblAverageTime);
            Controls.Add(dgvScores);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmScoreBoard";
            Text = "Score Board";
            ((System.ComponentModel.ISupportInitialize)dgvScores).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvScores;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem sortToolStripMenuItem;
        private ToolStripMenuItem byNameToolStripMenuItem;
        private ToolStripMenuItem byScoreToolStripMenuItem;
        private ToolStripMenuItem byDateToolStripMenuItem;
        private Label lblAverageTime;
        private Label lblAverageScore;
    }
}