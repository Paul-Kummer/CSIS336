namespace FileViewer
{
    partial class Form1
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
            this.defaultTab = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.openTextButton = new System.Windows.Forms.Button();
            this.closeTabButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openTestFiles = new System.Windows.Forms.Button();
            this.defaultTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultTab
            // 
            this.defaultTab.AutoScroll = true;
            this.defaultTab.BackColor = System.Drawing.Color.Gainsboro;
            this.defaultTab.Controls.Add(this.textBox1);
            this.defaultTab.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.defaultTab.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultTab.Location = new System.Drawing.Point(4, 22);
            this.defaultTab.Name = "defaultTab";
            this.defaultTab.Padding = new System.Windows.Forms.Padding(3);
            this.defaultTab.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.defaultTab.Size = new System.Drawing.Size(900, 506);
            this.defaultTab.TabIndex = 0;
            this.defaultTab.Text = "defaultTab";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(894, 500);
            this.textBox1.TabIndex = 0;
            this.textBox1.WordWrap = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.defaultTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(908, 532);
            this.tabControl1.TabIndex = 1;
            // 
            // openTextButton
            // 
            this.openTextButton.Location = new System.Drawing.Point(3, 7);
            this.openTextButton.Name = "openTextButton";
            this.openTextButton.Size = new System.Drawing.Size(118, 23);
            this.openTextButton.TabIndex = 2;
            this.openTextButton.Text = "Open Text File";
            this.openTextButton.UseVisualStyleBackColor = true;
            this.openTextButton.Click += new System.EventHandler(this.openTextButton_Click);
            // 
            // closeTabButton
            // 
            this.closeTabButton.Location = new System.Drawing.Point(127, 7);
            this.closeTabButton.Name = "closeTabButton";
            this.closeTabButton.Size = new System.Drawing.Size(108, 23);
            this.closeTabButton.TabIndex = 3;
            this.closeTabButton.Text = "Close Current Tab";
            this.closeTabButton.UseVisualStyleBackColor = true;
            this.closeTabButton.Click += new System.EventHandler(this.closeTabButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Text Files .txt | *.txt";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Text File Selection";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.openTestFiles);
            this.panel1.Controls.Add(this.openTextButton);
            this.panel1.Controls.Add(this.closeTabButton);
            this.panel1.Location = new System.Drawing.Point(12, 538);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 36);
            this.panel1.TabIndex = 4;
            // 
            // openTestFiles
            // 
            this.openTestFiles.Location = new System.Drawing.Point(241, 7);
            this.openTestFiles.Name = "openTestFiles";
            this.openTestFiles.Size = new System.Drawing.Size(113, 23);
            this.openTestFiles.TabIndex = 4;
            this.openTestFiles.Text = "Run Test";
            this.openTestFiles.UseVisualStyleBackColor = true;
            this.openTestFiles.Click += new System.EventHandler(this.openTestFiles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 573);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.defaultTab.ResumeLayout(false);
            this.defaultTab.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button openTextButton;
        private System.Windows.Forms.Button closeTabButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage defaultTab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button openTestFiles;
    }
}

