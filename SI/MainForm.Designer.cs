namespace SI
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda wsparcia projektanta - nie należy modyfikować
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFile = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GenerateBT = new System.Windows.Forms.Button();
            this.numberOfRandomLinesComboBox = new System.Windows.Forms.ComboBox();
            this.calculate = new System.Windows.Forms.Button();
            this.AlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.startLineComboBox = new System.Windows.Forms.ComboBox();
            this.chooseStartPointCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(356, 25);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(75, 23);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "Open File";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(353, 9);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(52, 13);
            this.labelFileName.TabIndex = 1;
            this.labelFileName.Text = "File name";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsTab = true;
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(324, 399);
            this.textBox1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(324, 149);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 250);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // GenerateBT
            // 
            this.GenerateBT.Location = new System.Drawing.Point(489, 25);
            this.GenerateBT.Name = "GenerateBT";
            this.GenerateBT.Size = new System.Drawing.Size(125, 23);
            this.GenerateBT.TabIndex = 5;
            this.GenerateBT.Text = "Generate random fields";
            this.GenerateBT.UseVisualStyleBackColor = true;
            this.GenerateBT.Click += new System.EventHandler(this.GenerateBT_Click);
            // 
            // numberOfRandomLinesComboBox
            // 
            this.numberOfRandomLinesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numberOfRandomLinesComboBox.FormattingEnabled = true;
            this.numberOfRandomLinesComboBox.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.numberOfRandomLinesComboBox.Location = new System.Drawing.Point(620, 25);
            this.numberOfRandomLinesComboBox.Name = "numberOfRandomLinesComboBox";
            this.numberOfRandomLinesComboBox.Size = new System.Drawing.Size(48, 21);
            this.numberOfRandomLinesComboBox.TabIndex = 6;
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(597, 109);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(75, 23);
            this.calculate.TabIndex = 8;
            this.calculate.Text = "Calculate";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // AlgorithmComboBox
            // 
            this.AlgorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgorithmComboBox.FormattingEnabled = true;
            this.AlgorithmComboBox.Location = new System.Drawing.Point(476, 71);
            this.AlgorithmComboBox.Name = "AlgorithmComboBox";
            this.AlgorithmComboBox.Size = new System.Drawing.Size(121, 21);
            this.AlgorithmComboBox.TabIndex = 9;
            this.AlgorithmComboBox.SelectedIndexChanged += new System.EventHandler(this.methodComboBox_SelectedIndexChanged);
            // 
            // startLineComboBox
            // 
            this.startLineComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startLineComboBox.Enabled = false;
            this.startLineComboBox.FormattingEnabled = true;
            this.startLineComboBox.Location = new System.Drawing.Point(447, 123);
            this.startLineComboBox.Name = "startLineComboBox";
            this.startLineComboBox.Size = new System.Drawing.Size(48, 21);
            this.startLineComboBox.TabIndex = 4;
            this.startLineComboBox.Visible = false;
            // 
            // chooseStartPointCheckBox
            // 
            this.chooseStartPointCheckBox.AutoSize = true;
            this.chooseStartPointCheckBox.Enabled = false;
            this.chooseStartPointCheckBox.Location = new System.Drawing.Point(330, 126);
            this.chooseStartPointCheckBox.Name = "chooseStartPointCheckBox";
            this.chooseStartPointCheckBox.Size = new System.Drawing.Size(117, 17);
            this.chooseStartPointCheckBox.TabIndex = 7;
            this.chooseStartPointCheckBox.Text = "Lock start point on:";
            this.chooseStartPointCheckBox.UseVisualStyleBackColor = true;
            this.chooseStartPointCheckBox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Calculate method:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(628, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Count:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 399);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AlgorithmComboBox);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.numberOfRandomLinesComboBox);
            this.Controls.Add(this.GenerateBT);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.chooseStartPointCheckBox);
            this.Controls.Add(this.startLineComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sztuczna Inteligencja";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button GenerateBT;
        private System.Windows.Forms.ComboBox numberOfRandomLinesComboBox;
        private System.Windows.Forms.Button calculate;
        public System.Windows.Forms.ComboBox AlgorithmComboBox;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.ComboBox startLineComboBox;
        public System.Windows.Forms.CheckBox chooseStartPointCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}

