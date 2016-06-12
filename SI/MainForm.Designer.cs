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
            this.labelNazwaPliku = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LosujBT = new System.Windows.Forms.Button();
            this.numberOfRandomLinesComboBox = new System.Windows.Forms.ComboBox();
            this.calculate = new System.Windows.Forms.Button();
            this.AlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.startLineComboBox = new System.Windows.Forms.ComboBox();
            this.chooseStartPointCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(356, 25);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(75, 23);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "Otwórz plik";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // labelNazwaPliku
            // 
            this.labelNazwaPliku.AutoSize = true;
            this.labelNazwaPliku.Location = new System.Drawing.Point(353, 9);
            this.labelNazwaPliku.Name = "labelNazwaPliku";
            this.labelNazwaPliku.Size = new System.Drawing.Size(65, 13);
            this.labelNazwaPliku.TabIndex = 1;
            this.labelNazwaPliku.Text = "Nazwa pliku";
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
            // LosujBT
            // 
            this.LosujBT.Location = new System.Drawing.Point(493, 25);
            this.LosujBT.Name = "LosujBT";
            this.LosujBT.Size = new System.Drawing.Size(75, 23);
            this.LosujBT.TabIndex = 5;
            this.LosujBT.Text = "Losuj";
            this.LosujBT.UseVisualStyleBackColor = true;
            this.LosujBT.Click += new System.EventHandler(this.LosujBT_Click);
            // 
            // numberOfRandomLinesComboBox
            // 
            this.numberOfRandomLinesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numberOfRandomLinesComboBox.FormattingEnabled = true;
            this.numberOfRandomLinesComboBox.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.numberOfRandomLinesComboBox.Location = new System.Drawing.Point(574, 25);
            this.numberOfRandomLinesComboBox.Name = "numberOfRandomLinesComboBox";
            this.numberOfRandomLinesComboBox.Size = new System.Drawing.Size(48, 21);
            this.numberOfRandomLinesComboBox.TabIndex = 6;
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(356, 104);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(75, 23);
            this.calculate.TabIndex = 8;
            this.calculate.Text = "Licz";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // AlgorithmComboBox
            // 
            this.AlgorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgorithmComboBox.FormattingEnabled = true;
            this.AlgorithmComboBox.Location = new System.Drawing.Point(356, 54);
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
            this.startLineComboBox.Location = new System.Drawing.Point(472, 77);
            this.startLineComboBox.Name = "startLineComboBox";
            this.startLineComboBox.Size = new System.Drawing.Size(48, 21);
            this.startLineComboBox.TabIndex = 4;
            // 
            // chooseStartPointCheckBox
            // 
            this.chooseStartPointCheckBox.AutoSize = true;
            this.chooseStartPointCheckBox.Enabled = false;
            this.chooseStartPointCheckBox.Location = new System.Drawing.Point(356, 81);
            this.chooseStartPointCheckBox.Name = "chooseStartPointCheckBox";
            this.chooseStartPointCheckBox.Size = new System.Drawing.Size(110, 17);
            this.chooseStartPointCheckBox.TabIndex = 7;
            this.chooseStartPointCheckBox.Text = "Zablokuj Start na:";
            this.chooseStartPointCheckBox.UseVisualStyleBackColor = true;
            this.chooseStartPointCheckBox.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 399);
            this.Controls.Add(this.AlgorithmComboBox);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.numberOfRandomLinesComboBox);
            this.Controls.Add(this.LosujBT);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelNazwaPliku);
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
        private System.Windows.Forms.Label labelNazwaPliku;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button LosujBT;
        private System.Windows.Forms.ComboBox numberOfRandomLinesComboBox;
        private System.Windows.Forms.Button calculate;
        public System.Windows.Forms.ComboBox AlgorithmComboBox;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.ComboBox startLineComboBox;
        public System.Windows.Forms.CheckBox chooseStartPointCheckBox;
    }
}

