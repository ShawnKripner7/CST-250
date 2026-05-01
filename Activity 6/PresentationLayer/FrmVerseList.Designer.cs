namespace FileIOAndLINQ.PresentationLayer
{
    partial class FrmVerseList
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
            mnsFileActions = new MenuStrip();
            tsmFile = new ToolStripMenuItem();
            tsmSave = new ToolStripMenuItem();
            tsmLoad = new ToolStripMenuItem();
            tsmExit = new ToolStripMenuItem();
            grpAddVerse = new GroupBox();
            lblBook = new Label();
            lblChapter = new Label();
            lblVerse = new Label();
            lblText = new Label();
            lblMeaning = new Label();
            lblImportance = new Label();
            cmbVerseBook = new ComboBox();
            txtVerseChapter = new TextBox();
            txtVerseVerse = new TextBox();
            txtVerseText = new TextBox();
            txtVerseMeaning = new TextBox();
            nudVerseImportance = new NumericUpDown();
            btnAddVerse = new Button();
            lblBookError = new Label();
            lblChapterError = new Label();
            lblVerseError = new Label();
            lblTextError = new Label();
            lblMeaningError = new Label();
            lblImportanceError = new Label();
            grpFilterAndSort = new GroupBox();
            rdoShowAll = new RadioButton();
            rdoShowLeastValuable = new RadioButton();
            rdoShowMostValuable = new RadioButton();
            trbNumberToShow = new TrackBar();
            dataGridView1 = new DataGridView();
            mnsFileActions.SuspendLayout();
            grpAddVerse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudVerseImportance).BeginInit();
            grpFilterAndSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbNumberToShow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // mnsFileActions
            // 
            mnsFileActions.Items.AddRange(new ToolStripItem[] { tsmFile });
            mnsFileActions.Location = new Point(0, 0);
            mnsFileActions.Name = "mnsFileActions";
            mnsFileActions.Size = new Size(1131, 24);
            mnsFileActions.TabIndex = 0;
            mnsFileActions.Text = "mns";
            // 
            // tsmFile
            // 
            tsmFile.DropDownItems.AddRange(new ToolStripItem[] { tsmSave, tsmLoad, tsmExit });
            tsmFile.Name = "tsmFile";
            tsmFile.Size = new Size(37, 20);
            tsmFile.Text = "File";
            // 
            // tsmSave
            // 
            tsmSave.Name = "tsmSave";
            tsmSave.Size = new Size(180, 22);
            tsmSave.Text = "Save";
            // 
            // tsmLoad
            // 
            tsmLoad.Name = "tsmLoad";
            tsmLoad.Size = new Size(180, 22);
            tsmLoad.Text = "Load";
            // 
            // tsmExit
            // 
            tsmExit.Name = "tsmExit";
            tsmExit.Size = new Size(180, 22);
            tsmExit.Text = "Exit";
            // 
            // grpAddVerse
            // 
            grpAddVerse.Controls.Add(lblImportanceError);
            grpAddVerse.Controls.Add(btnAddVerse);
            grpAddVerse.Controls.Add(lblMeaningError);
            grpAddVerse.Controls.Add(nudVerseImportance);
            grpAddVerse.Controls.Add(lblTextError);
            grpAddVerse.Controls.Add(txtVerseMeaning);
            grpAddVerse.Controls.Add(lblVerseError);
            grpAddVerse.Controls.Add(txtVerseVerse);
            grpAddVerse.Controls.Add(lblChapterError);
            grpAddVerse.Controls.Add(txtVerseText);
            grpAddVerse.Controls.Add(lblBookError);
            grpAddVerse.Controls.Add(cmbVerseBook);
            grpAddVerse.Controls.Add(txtVerseChapter);
            grpAddVerse.Controls.Add(lblImportance);
            grpAddVerse.Controls.Add(lblBook);
            grpAddVerse.Controls.Add(lblMeaning);
            grpAddVerse.Controls.Add(lblChapter);
            grpAddVerse.Controls.Add(lblText);
            grpAddVerse.Controls.Add(lblVerse);
            grpAddVerse.Location = new Point(12, 38);
            grpAddVerse.Name = "grpAddVerse";
            grpAddVerse.Size = new Size(316, 622);
            grpAddVerse.TabIndex = 1;
            grpAddVerse.TabStop = false;
            grpAddVerse.Text = "Add A Bible Verse";
            // 
            // lblBook
            // 
            lblBook.AutoSize = true;
            lblBook.Location = new Point(17, 35);
            lblBook.Name = "lblBook";
            lblBook.Size = new Size(37, 15);
            lblBook.TabIndex = 0;
            lblBook.Text = "Book:";
            // 
            // lblChapter
            // 
            lblChapter.AutoSize = true;
            lblChapter.Location = new Point(16, 88);
            lblChapter.Name = "lblChapter";
            lblChapter.Size = new Size(52, 15);
            lblChapter.TabIndex = 2;
            lblChapter.Text = "Chapter:";
            // 
            // lblVerse
            // 
            lblVerse.AutoSize = true;
            lblVerse.Location = new Point(16, 155);
            lblVerse.Name = "lblVerse";
            lblVerse.Size = new Size(37, 15);
            lblVerse.TabIndex = 3;
            lblVerse.Text = "Verse:";
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Location = new Point(17, 207);
            lblText.Name = "lblText";
            lblText.Size = new Size(31, 15);
            lblText.TabIndex = 4;
            lblText.Text = "Text:";
            // 
            // lblMeaning
            // 
            lblMeaning.AutoSize = true;
            lblMeaning.Location = new Point(17, 297);
            lblMeaning.Name = "lblMeaning";
            lblMeaning.Size = new Size(57, 15);
            lblMeaning.TabIndex = 5;
            lblMeaning.Text = "Meaning:";
            // 
            // lblImportance
            // 
            lblImportance.AutoSize = true;
            lblImportance.Location = new Point(16, 450);
            lblImportance.Name = "lblImportance";
            lblImportance.Size = new Size(71, 15);
            lblImportance.TabIndex = 6;
            lblImportance.Text = "Importance:";
            // 
            // cmbVerseBook
            // 
            cmbVerseBook.FormattingEnabled = true;
            cmbVerseBook.Location = new Point(74, 27);
            cmbVerseBook.Name = "cmbVerseBook";
            cmbVerseBook.Size = new Size(121, 23);
            cmbVerseBook.TabIndex = 7;
            // 
            // txtVerseChapter
            // 
            txtVerseChapter.Location = new Point(74, 85);
            txtVerseChapter.Name = "txtVerseChapter";
            txtVerseChapter.Size = new Size(100, 23);
            txtVerseChapter.TabIndex = 2;
            // 
            // txtVerseVerse
            // 
            txtVerseVerse.Location = new Point(74, 147);
            txtVerseVerse.Name = "txtVerseVerse";
            txtVerseVerse.Size = new Size(100, 23);
            txtVerseVerse.TabIndex = 3;
            // 
            // txtVerseText
            // 
            txtVerseText.Location = new Point(54, 199);
            txtVerseText.Multiline = true;
            txtVerseText.Name = "txtVerseText";
            txtVerseText.Size = new Size(213, 69);
            txtVerseText.TabIndex = 2;
            // 
            // txtVerseMeaning
            // 
            txtVerseMeaning.Location = new Point(74, 297);
            txtVerseMeaning.Multiline = true;
            txtVerseMeaning.Name = "txtVerseMeaning";
            txtVerseMeaning.Size = new Size(193, 112);
            txtVerseMeaning.TabIndex = 3;
            // 
            // nudVerseImportance
            // 
            nudVerseImportance.Location = new Point(93, 448);
            nudVerseImportance.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudVerseImportance.Name = "nudVerseImportance";
            nudVerseImportance.Size = new Size(120, 23);
            nudVerseImportance.TabIndex = 8;
            // 
            // btnAddVerse
            // 
            btnAddVerse.Location = new Point(99, 511);
            btnAddVerse.Name = "btnAddVerse";
            btnAddVerse.Size = new Size(75, 23);
            btnAddVerse.TabIndex = 9;
            btnAddVerse.Text = "Add";
            btnAddVerse.UseVisualStyleBackColor = true;
            // 
            // lblBookError
            // 
            lblBookError.AutoSize = true;
            lblBookError.ForeColor = Color.Red;
            lblBookError.Location = new Point(93, 53);
            lblBookError.Name = "lblBookError";
            lblBookError.Size = new Size(62, 15);
            lblBookError.TabIndex = 2;
            lblBookError.Text = "Book Error";
            // 
            // lblChapterError
            // 
            lblChapterError.AutoSize = true;
            lblChapterError.ForeColor = Color.Red;
            lblChapterError.Location = new Point(93, 111);
            lblChapterError.Name = "lblChapterError";
            lblChapterError.Size = new Size(77, 15);
            lblChapterError.TabIndex = 3;
            lblChapterError.Text = "Chapter Error";
            // 
            // lblVerseError
            // 
            lblVerseError.AutoSize = true;
            lblVerseError.ForeColor = Color.Red;
            lblVerseError.Location = new Point(93, 173);
            lblVerseError.Name = "lblVerseError";
            lblVerseError.Size = new Size(62, 15);
            lblVerseError.TabIndex = 4;
            lblVerseError.Text = "Verse Error";
            // 
            // lblTextError
            // 
            lblTextError.AutoSize = true;
            lblTextError.ForeColor = Color.Red;
            lblTextError.Location = new Point(93, 271);
            lblTextError.Name = "lblTextError";
            lblTextError.Size = new Size(56, 15);
            lblTextError.TabIndex = 5;
            lblTextError.Text = "Text Error";
            // 
            // lblMeaningError
            // 
            lblMeaningError.AutoSize = true;
            lblMeaningError.ForeColor = Color.Red;
            lblMeaningError.Location = new Point(93, 412);
            lblMeaningError.Name = "lblMeaningError";
            lblMeaningError.Size = new Size(82, 15);
            lblMeaningError.TabIndex = 6;
            lblMeaningError.Text = "Meaning Error";
            // 
            // lblImportanceError
            // 
            lblImportanceError.AutoSize = true;
            lblImportanceError.ForeColor = Color.Red;
            lblImportanceError.Location = new Point(93, 484);
            lblImportanceError.Name = "lblImportanceError";
            lblImportanceError.Size = new Size(96, 15);
            lblImportanceError.TabIndex = 7;
            lblImportanceError.Text = "Importance Error";
            // 
            // grpFilterAndSort
            // 
            grpFilterAndSort.Controls.Add(rdoShowMostValuable);
            grpFilterAndSort.Controls.Add(rdoShowLeastValuable);
            grpFilterAndSort.Controls.Add(rdoShowAll);
            grpFilterAndSort.Location = new Point(12, 685);
            grpFilterAndSort.Name = "grpFilterAndSort";
            grpFilterAndSort.Size = new Size(316, 177);
            grpFilterAndSort.TabIndex = 2;
            grpFilterAndSort.TabStop = false;
            grpFilterAndSort.Text = "Filter And Sort";
            // 
            // rdoShowAll
            // 
            rdoShowAll.AutoSize = true;
            rdoShowAll.Location = new Point(0, 37);
            rdoShowAll.Name = "rdoShowAll";
            rdoShowAll.Size = new Size(71, 19);
            rdoShowAll.TabIndex = 0;
            rdoShowAll.TabStop = true;
            rdoShowAll.Text = "Show All";
            rdoShowAll.UseVisualStyleBackColor = true;
            // 
            // rdoShowLeastValuable
            // 
            rdoShowLeastValuable.AutoSize = true;
            rdoShowLeastValuable.Location = new Point(0, 88);
            rdoShowLeastValuable.Name = "rdoShowLeastValuable";
            rdoShowLeastValuable.Size = new Size(131, 19);
            rdoShowLeastValuable.TabIndex = 3;
            rdoShowLeastValuable.TabStop = true;
            rdoShowLeastValuable.Text = "Show Least Valuable";
            rdoShowLeastValuable.UseVisualStyleBackColor = true;
            // 
            // rdoShowMostValuable
            // 
            rdoShowMostValuable.AutoSize = true;
            rdoShowMostValuable.Location = new Point(3, 138);
            rdoShowMostValuable.Name = "rdoShowMostValuable";
            rdoShowMostValuable.Size = new Size(140, 19);
            rdoShowMostValuable.TabIndex = 4;
            rdoShowMostValuable.TabStop = true;
            rdoShowMostValuable.Text = "Show Most Important";
            rdoShowMostValuable.UseVisualStyleBackColor = true;
            // 
            // trbNumberToShow
            // 
            trbNumberToShow.Location = new Point(15, 880);
            trbNumberToShow.Name = "trbNumberToShow";
            trbNumberToShow.Size = new Size(313, 45);
            trbNumberToShow.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(345, 38);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(754, 723);
            dataGridView1.TabIndex = 4;
            // 
            // FrmVerseList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 1001);
            Controls.Add(dataGridView1);
            Controls.Add(trbNumberToShow);
            Controls.Add(grpFilterAndSort);
            Controls.Add(grpAddVerse);
            Controls.Add(mnsFileActions);
            MainMenuStrip = mnsFileActions;
            Name = "FrmVerseList";
            Text = "Bible Verses";
            mnsFileActions.ResumeLayout(false);
            mnsFileActions.PerformLayout();
            grpAddVerse.ResumeLayout(false);
            grpAddVerse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudVerseImportance).EndInit();
            grpFilterAndSort.ResumeLayout(false);
            grpFilterAndSort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbNumberToShow).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnsFileActions;
        private ToolStripMenuItem tsmFile;
        private ToolStripMenuItem tsmSave;
        private ToolStripMenuItem tsmLoad;
        private ToolStripMenuItem tsmExit;
        private GroupBox grpAddVerse;
        private TextBox txtVerseMeaning;
        private TextBox txtVerseVerse;
        private TextBox txtVerseText;
        private ComboBox cmbVerseBook;
        private TextBox txtVerseChapter;
        private Label lblImportance;
        private Label lblBook;
        private Label lblMeaning;
        private Label lblChapter;
        private Label lblText;
        private Label lblVerse;
        private Button btnAddVerse;
        private Label lblMeaningError;
        private NumericUpDown nudVerseImportance;
        private Label lblTextError;
        private Label lblVerseError;
        private Label lblChapterError;
        private Label lblBookError;
        private Label lblImportanceError;
        private GroupBox grpFilterAndSort;
        private RadioButton rdoShowMostValuable;
        private RadioButton rdoShowLeastValuable;
        private RadioButton rdoShowAll;
        private TrackBar trbNumberToShow;
        private DataGridView dataGridView1;
    }
}