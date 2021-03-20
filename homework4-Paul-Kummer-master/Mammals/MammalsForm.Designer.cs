namespace Mammals
{
    partial class MammalsForm
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
            this.mammalianTree = new System.Windows.Forms.TreeView();
            this.selectedName = new System.Windows.Forms.Label();
            this.CommonName = new System.Windows.Forms.Label();
            this.Author = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.entryPanel = new System.Windows.Forms.Panel();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.dateTB = new System.Windows.Forms.TextBox();
            this.commonNameTB = new System.Windows.Forms.TextBox();
            this.authorTB = new System.Windows.Forms.TextBox();
            this.searchGB = new System.Windows.Forms.GroupBox();
            this.searchTB = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.entryPanel.SuspendLayout();
            this.searchGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // mammalianTree
            // 
            this.mammalianTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.mammalianTree.Location = new System.Drawing.Point(0, 0);
            this.mammalianTree.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mammalianTree.Name = "mammalianTree";
            this.mammalianTree.Size = new System.Drawing.Size(377, 656);
            this.mammalianTree.TabIndex = 0;
            this.mammalianTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.mammalianTree_AfterSelect);
            // 
            // selectedName
            // 
            this.selectedName.AutoSize = true;
            this.selectedName.Location = new System.Drawing.Point(423, 106);
            this.selectedName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectedName.Name = "selectedName";
            this.selectedName.Size = new System.Drawing.Size(35, 13);
            this.selectedName.TabIndex = 2;
            this.selectedName.Text = "Name";
            // 
            // CommonName
            // 
            this.CommonName.AutoSize = true;
            this.CommonName.Location = new System.Drawing.Point(383, 144);
            this.CommonName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CommonName.Name = "CommonName";
            this.CommonName.Size = new System.Drawing.Size(79, 13);
            this.CommonName.TabIndex = 4;
            this.CommonName.Text = "Common Name";
            // 
            // Author
            // 
            this.Author.AutoSize = true;
            this.Author.Location = new System.Drawing.Point(417, 179);
            this.Author.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(38, 13);
            this.Author.TabIndex = 6;
            this.Author.Text = "Author";
            this.Author.Click += new System.EventHandler(this.label2_Click);
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Location = new System.Drawing.Point(425, 218);
            this.Date.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(30, 13);
            this.Date.TabIndex = 8;
            this.Date.Text = "Date";
            // 
            // entryPanel
            // 
            this.entryPanel.Controls.Add(this.NameTextBox);
            this.entryPanel.Controls.Add(this.dateTB);
            this.entryPanel.Controls.Add(this.commonNameTB);
            this.entryPanel.Controls.Add(this.authorTB);
            this.entryPanel.Location = new System.Drawing.Point(460, 101);
            this.entryPanel.Name = "entryPanel";
            this.entryPanel.Size = new System.Drawing.Size(169, 138);
            this.entryPanel.TabIndex = 10;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(2, 2);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(162, 20);
            this.NameTextBox.TabIndex = 8;
            // 
            // dateTB
            // 
            this.dateTB.Location = new System.Drawing.Point(2, 114);
            this.dateTB.Margin = new System.Windows.Forms.Padding(2);
            this.dateTB.Name = "dateTB";
            this.dateTB.Size = new System.Drawing.Size(162, 20);
            this.dateTB.TabIndex = 11;
            // 
            // commonNameTB
            // 
            this.commonNameTB.Location = new System.Drawing.Point(2, 40);
            this.commonNameTB.Margin = new System.Windows.Forms.Padding(2);
            this.commonNameTB.Name = "commonNameTB";
            this.commonNameTB.Size = new System.Drawing.Size(162, 20);
            this.commonNameTB.TabIndex = 9;
            // 
            // authorTB
            // 
            this.authorTB.Location = new System.Drawing.Point(2, 75);
            this.authorTB.Margin = new System.Windows.Forms.Padding(2);
            this.authorTB.Name = "authorTB";
            this.authorTB.Size = new System.Drawing.Size(162, 20);
            this.authorTB.TabIndex = 10;
            // 
            // searchGB
            // 
            this.searchGB.Controls.Add(this.searchButton);
            this.searchGB.Controls.Add(this.searchTB);
            this.searchGB.Location = new System.Drawing.Point(442, 29);
            this.searchGB.Name = "searchGB";
            this.searchGB.Size = new System.Drawing.Size(312, 52);
            this.searchGB.TabIndex = 11;
            this.searchGB.TabStop = false;
            this.searchGB.Text = "Search Species";
            // 
            // searchTB
            // 
            this.searchTB.Location = new System.Drawing.Point(17, 18);
            this.searchTB.Name = "searchTB";
            this.searchTB.Size = new System.Drawing.Size(164, 20);
            this.searchTB.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(219, 16);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // MammalsForm
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 656);
            this.Controls.Add(this.searchGB);
            this.Controls.Add(this.entryPanel);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.mammalianTree);
            this.Controls.Add(this.selectedName);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.CommonName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MammalsForm";
            this.Text = "Mammals";
            this.Load += new System.EventHandler(this.MammalsForm_Load);
            this.entryPanel.ResumeLayout(false);
            this.entryPanel.PerformLayout();
            this.searchGB.ResumeLayout(false);
            this.searchGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView mammalianTree;
        private System.Windows.Forms.Label selectedName;
        private System.Windows.Forms.Label CommonName;
        private System.Windows.Forms.Label Author;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Panel entryPanel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox dateTB;
        private System.Windows.Forms.TextBox commonNameTB;
        private System.Windows.Forms.TextBox authorTB;
        private System.Windows.Forms.GroupBox searchGB;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTB;
    }
}

