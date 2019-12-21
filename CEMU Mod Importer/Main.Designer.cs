namespace CEMU_Mod_Importer
{
    partial class Main
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
            this.NewModButton = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.DescriptionBox = new System.Windows.Forms.RichTextBox();
            this.TitleIdBox = new System.Windows.Forms.TextBox();
            this.CEMU_path = new System.Windows.Forms.OpenFileDialog();
            this.CEMU_path_button = new System.Windows.Forms.Button();
            this.FsPriority = new System.Windows.Forms.NumericUpDown();
            this.FsPriorityBox = new System.Windows.Forms.TextBox();
            this.GameNameTextbox = new System.Windows.Forms.TextBox();
            this.ImportGameInfoButton = new System.Windows.Forms.Button();
            this.TitlekeysJSON_path = new System.Windows.Forms.OpenFileDialog();
            this.GameDropdown = new System.Windows.Forms.ComboBox();
            this.DragDrop = new System.Windows.Forms.TextBox();
            this.ClearModFiles = new System.Windows.Forms.Button();
            this.Debug = new System.Windows.Forms.RichTextBox();
            this.LoadMod = new System.Windows.Forms.Button();
            this.Rules_file = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.FsPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // NewModButton
            // 
            this.NewModButton.Location = new System.Drawing.Point(12, 12);
            this.NewModButton.Name = "NewModButton";
            this.NewModButton.Size = new System.Drawing.Size(75, 23);
            this.NewModButton.TabIndex = 0;
            this.NewModButton.Text = "Export Mod";
            this.NewModButton.UseVisualStyleBackColor = true;
            this.NewModButton.Click += new System.EventHandler(this.NewModButton_Click);
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.Color.Gray;
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameBox.Location = new System.Drawing.Point(12, 41);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(75, 20);
            this.NameBox.TabIndex = 1;
            this.NameBox.Text = "Mod name";
            this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionBox.BackColor = System.Drawing.Color.Gray;
            this.DescriptionBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescriptionBox.Location = new System.Drawing.Point(12, 67);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(776, 74);
            this.DescriptionBox.TabIndex = 2;
            this.DescriptionBox.Text = "Description";
            this.DescriptionBox.TextChanged += new System.EventHandler(this.DescriptionBox_TextChanged);
            // 
            // TitleIdBox
            // 
            this.TitleIdBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleIdBox.BackColor = System.Drawing.Color.Gray;
            this.TitleIdBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleIdBox.Location = new System.Drawing.Point(93, 41);
            this.TitleIdBox.Name = "TitleIdBox";
            this.TitleIdBox.Size = new System.Drawing.Size(476, 20);
            this.TitleIdBox.TabIndex = 3;
            this.TitleIdBox.Text = "Titleids seperated by ,";
            this.TitleIdBox.TextChanged += new System.EventHandler(this.TitleIdBox_TextChanged);
            // 
            // CEMU_path
            // 
            this.CEMU_path.FileName = "cemu.exe";
            this.CEMU_path.Filter = "cemu|cemu.exe";
            // 
            // CEMU_path_button
            // 
            this.CEMU_path_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CEMU_path_button.Location = new System.Drawing.Point(677, 12);
            this.CEMU_path_button.Name = "CEMU_path_button";
            this.CEMU_path_button.Size = new System.Drawing.Size(111, 23);
            this.CEMU_path_button.TabIndex = 4;
            this.CEMU_path_button.Text = "Set CEMU Location";
            this.CEMU_path_button.UseVisualStyleBackColor = true;
            this.CEMU_path_button.Click += new System.EventHandler(this.CEMU_path_button_Click);
            // 
            // FsPriority
            // 
            this.FsPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FsPriority.BackColor = System.Drawing.Color.Lime;
            this.FsPriority.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FsPriority.Location = new System.Drawing.Point(93, 147);
            this.FsPriority.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.FsPriority.Name = "FsPriority";
            this.FsPriority.Size = new System.Drawing.Size(75, 20);
            this.FsPriority.TabIndex = 5;
            this.FsPriority.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.FsPriority.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // FsPriorityBox
            // 
            this.FsPriorityBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FsPriorityBox.BackColor = System.Drawing.Color.Lime;
            this.FsPriorityBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FsPriorityBox.Location = new System.Drawing.Point(12, 147);
            this.FsPriorityBox.Name = "FsPriorityBox";
            this.FsPriorityBox.ReadOnly = true;
            this.FsPriorityBox.Size = new System.Drawing.Size(75, 20);
            this.FsPriorityBox.TabIndex = 6;
            this.FsPriorityBox.Text = "Priority";
            // 
            // GameNameTextbox
            // 
            this.GameNameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GameNameTextbox.BackColor = System.Drawing.Color.Gray;
            this.GameNameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameNameTextbox.Location = new System.Drawing.Point(575, 41);
            this.GameNameTextbox.Name = "GameNameTextbox";
            this.GameNameTextbox.Size = new System.Drawing.Size(213, 20);
            this.GameNameTextbox.TabIndex = 7;
            this.GameNameTextbox.Text = "Game Name";
            this.GameNameTextbox.TextChanged += new System.EventHandler(this.GameNameTextbox_TextChanged);
            // 
            // ImportGameInfoButton
            // 
            this.ImportGameInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportGameInfoButton.Location = new System.Drawing.Point(575, 12);
            this.ImportGameInfoButton.Name = "ImportGameInfoButton";
            this.ImportGameInfoButton.Size = new System.Drawing.Size(96, 23);
            this.ImportGameInfoButton.TabIndex = 8;
            this.ImportGameInfoButton.Text = "Import Game Info";
            this.ImportGameInfoButton.UseVisualStyleBackColor = true;
            this.ImportGameInfoButton.Click += new System.EventHandler(this.ImportGameInfoButton_Click);
            // 
            // TitlekeysJSON_path
            // 
            this.TitlekeysJSON_path.FileName = "titlekeys.json";
            this.TitlekeysJSON_path.Filter = "titlekeys|*.json";
            // 
            // GameDropdown
            // 
            this.GameDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameDropdown.FormattingEnabled = true;
            this.GameDropdown.Location = new System.Drawing.Point(174, 14);
            this.GameDropdown.Name = "GameDropdown";
            this.GameDropdown.Size = new System.Drawing.Size(395, 21);
            this.GameDropdown.TabIndex = 9;
            this.GameDropdown.SelectedIndexChanged += new System.EventHandler(this.GameDropdown_SelectedIndexChanged);
            // 
            // DragDrop
            // 
            this.DragDrop.AllowDrop = true;
            this.DragDrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DragDrop.Location = new System.Drawing.Point(174, 147);
            this.DragDrop.Name = "DragDrop";
            this.DragDrop.ReadOnly = true;
            this.DragDrop.Size = new System.Drawing.Size(497, 20);
            this.DragDrop.TabIndex = 10;
            this.DragDrop.Text = "Drop mod folders on me (\"meta/content/aoc\")";
            this.DragDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop_DragDrop);
            this.DragDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragDrop_DragEnter);
            // 
            // ClearModFiles
            // 
            this.ClearModFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearModFiles.Location = new System.Drawing.Point(677, 147);
            this.ClearModFiles.Name = "ClearModFiles";
            this.ClearModFiles.Size = new System.Drawing.Size(111, 20);
            this.ClearModFiles.TabIndex = 11;
            this.ClearModFiles.Text = "Clear list";
            this.ClearModFiles.UseVisualStyleBackColor = true;
            this.ClearModFiles.Click += new System.EventHandler(this.ClearModFiles_Click);
            // 
            // Debug
            // 
            this.Debug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Debug.Location = new System.Drawing.Point(12, 173);
            this.Debug.Name = "Debug";
            this.Debug.ReadOnly = true;
            this.Debug.Size = new System.Drawing.Size(776, 265);
            this.Debug.TabIndex = 12;
            this.Debug.Text = "";
            // 
            // LoadMod
            // 
            this.LoadMod.Location = new System.Drawing.Point(93, 12);
            this.LoadMod.Name = "LoadMod";
            this.LoadMod.Size = new System.Drawing.Size(75, 23);
            this.LoadMod.TabIndex = 13;
            this.LoadMod.Text = "Load Mod";
            this.LoadMod.UseVisualStyleBackColor = true;
            this.LoadMod.Click += new System.EventHandler(this.LoadMod_Click);
            // 
            // Rules_file
            // 
            this.Rules_file.FileName = "rules";
            this.Rules_file.Filter = "rules.txt|rules.txt";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LoadMod);
            this.Controls.Add(this.Debug);
            this.Controls.Add(this.ClearModFiles);
            this.Controls.Add(this.DragDrop);
            this.Controls.Add(this.GameDropdown);
            this.Controls.Add(this.ImportGameInfoButton);
            this.Controls.Add(this.GameNameTextbox);
            this.Controls.Add(this.FsPriorityBox);
            this.Controls.Add(this.FsPriority);
            this.Controls.Add(this.CEMU_path_button);
            this.Controls.Add(this.TitleIdBox);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.NewModButton);
            this.Name = "Main";
            this.Text = "CEMU Mod Importer";
            ((System.ComponentModel.ISupportInitialize)(this.FsPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewModButton;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.RichTextBox DescriptionBox;
        private System.Windows.Forms.TextBox TitleIdBox;
        private System.Windows.Forms.OpenFileDialog CEMU_path;
        private System.Windows.Forms.Button CEMU_path_button;
        private System.Windows.Forms.NumericUpDown FsPriority;
        private System.Windows.Forms.TextBox FsPriorityBox;
        private System.Windows.Forms.TextBox GameNameTextbox;
        private System.Windows.Forms.Button ImportGameInfoButton;
        private System.Windows.Forms.OpenFileDialog TitlekeysJSON_path;
        private System.Windows.Forms.ComboBox GameDropdown;
        private System.Windows.Forms.TextBox DragDrop;
        private System.Windows.Forms.Button ClearModFiles;
        private System.Windows.Forms.RichTextBox Debug;
        private System.Windows.Forms.Button LoadMod;
        private System.Windows.Forms.OpenFileDialog Rules_file;
    }
}

