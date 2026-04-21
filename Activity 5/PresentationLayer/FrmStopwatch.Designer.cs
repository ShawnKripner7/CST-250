namespace WhackAMole
{
    partial class FrmStopwatch
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            btnStop = new Button();
            btnReset = new Button();
            lblTimeElapsed = new Label();
            tmrStopwatch = new System.Windows.Forms.Timer(components);
            btnTarget = new Button();
            lblScore = new Label();
            lblLevel = new Label();
            btnDecoy = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 430);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += BtnStartClickEH;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(105, 430);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += BtnStopClickEH;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(197, 430);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 2;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += BtnResetClickEH;
            // 
            // lblTimeElapsed
            // 
            lblTimeElapsed.AutoSize = true;
            lblTimeElapsed.Location = new Point(12, 22);
            lblTimeElapsed.Name = "lblTimeElapsed";
            lblTimeElapsed.Size = new Size(46, 15);
            lblTimeElapsed.TabIndex = 3;
            lblTimeElapsed.Text = "Time: 0";
            // 
            // tmrStopwatch
            // 
            tmrStopwatch.Enabled = true;
            tmrStopwatch.Interval = 1000;
            tmrStopwatch.Tick += TmrStopwatchTickEH;
            // 
            // btnTarget
            // 
            btnTarget.Location = new Point(86, 98);
            btnTarget.Name = "btnTarget";
            btnTarget.Size = new Size(94, 78);
            btnTarget.TabIndex = 4;
            btnTarget.Text = "Target";
            btnTarget.UseVisualStyleBackColor = true;
            btnTarget.Click += BtnTargetClickEH;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(688, 22);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(48, 15);
            lblScore.TabIndex = 5;
            lblScore.Text = "Score: 0";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(690, 46);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(46, 15);
            lblLevel.TabIndex = 6;
            lblLevel.Text = "Level: 1";
            // 
            // btnDecoy
            // 
            btnDecoy.BackColor = Color.Red;
            btnDecoy.Location = new Point(369, 101);
            btnDecoy.Name = "btnDecoy";
            btnDecoy.Size = new Size(94, 75);
            btnDecoy.TabIndex = 7;
            btnDecoy.Text = "Decoy";
            btnDecoy.UseVisualStyleBackColor = false;
            btnDecoy.Click += BtnDecoyClickEH;
            // 
            // FrmStopwatch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 465);
            Controls.Add(btnDecoy);
            Controls.Add(lblLevel);
            Controls.Add(lblScore);
            Controls.Add(btnTarget);
            Controls.Add(lblTimeElapsed);
            Controls.Add(btnReset);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Name = "FrmStopwatch";
            Text = "Stopwatch";
            Resize += FrmStopwatch_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Button btnReset;
        private Label lblTimeElapsed;
        private System.Windows.Forms.Timer tmrStopwatch;
        private Button btnTarget;
        private Label lblScore;
        private Label lblLevel;
        private Button btnDecoy;
    }
}
