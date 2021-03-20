namespace MouseReporting
{
    partial class PictureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureForm));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureLabel = new System.Windows.Forms.Label();
            this.notAPictureLabel = new System.Windows.Forms.Label();
            this.mouseOverHeader = new System.Windows.Forms.Label();
            this.mouseClickHeader = new System.Windows.Forms.Label();
            this.mouseClickStatusLab = new System.Windows.Forms.Label();
            this.mouseOverStatusLab = new System.Windows.Forms.Label();
            this.counter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.BackgroundImage")));
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Location = new System.Drawing.Point(534, 124);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(414, 395);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // pictureLabel
            // 
            this.pictureLabel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pictureLabel.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pictureLabel.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.pictureLabel.Location = new System.Drawing.Point(317, 124);
            this.pictureLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pictureLabel.Name = "pictureLabel";
            this.pictureLabel.Size = new System.Drawing.Size(179, 16);
            this.pictureLabel.TabIndex = 1;
            this.pictureLabel.Text = "This Is A Picture ------->";
            this.pictureLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // notAPictureLabel
            // 
            this.notAPictureLabel.AutoSize = true;
            this.notAPictureLabel.Cursor = System.Windows.Forms.Cursors.No;
            this.notAPictureLabel.Location = new System.Drawing.Point(317, 502);
            this.notAPictureLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.notAPictureLabel.Name = "notAPictureLabel";
            this.notAPictureLabel.Size = new System.Drawing.Size(183, 17);
            this.notAPictureLabel.TabIndex = 2;
            this.notAPictureLabel.Text = "<------- This Is Not A Picture";

            // 
            // mouseOverHeader
            // 
            this.mouseOverHeader.AutoSize = true;
            this.mouseOverHeader.Location = new System.Drawing.Point(552, 36);
            this.mouseOverHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mouseOverHeader.Name = "mouseOverHeader";
            this.mouseOverHeader.Size = new System.Drawing.Size(133, 17);
            this.mouseOverHeader.TabIndex = 3;
            this.mouseOverHeader.Text = "Mouse Over Picture";

            // 
            // mouseClickHeader
            // 
            this.mouseClickHeader.AutoSize = true;
            this.mouseClickHeader.Location = new System.Drawing.Point(779, 36);
            this.mouseClickHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mouseClickHeader.Name = "mouseClickHeader";
            this.mouseClickHeader.Size = new System.Drawing.Size(127, 17);
            this.mouseClickHeader.TabIndex = 4;
            this.mouseClickHeader.Text = "Mouse Click Status";

            // 
            // mouseClickStatusLab
            // 
            this.mouseClickStatusLab.AutoSize = true;
            this.mouseClickStatusLab.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mouseClickStatusLab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mouseClickStatusLab.Location = new System.Drawing.Point(779, 52);
            this.mouseClickStatusLab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mouseClickStatusLab.Name = "mouseClickStatusLab";
            this.mouseClickStatusLab.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.mouseClickStatusLab.Size = new System.Drawing.Size(99, 26);
            this.mouseClickStatusLab.TabIndex = 6;
            this.mouseClickStatusLab.Text = "click status";

            // 
            // mouseOverStatusLab
            // 
            this.mouseOverStatusLab.AutoSize = true;
            this.mouseOverStatusLab.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mouseOverStatusLab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mouseOverStatusLab.Location = new System.Drawing.Point(552, 52);
            this.mouseOverStatusLab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mouseOverStatusLab.Name = "mouseOverStatusLab";
            this.mouseOverStatusLab.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.mouseOverStatusLab.Size = new System.Drawing.Size(118, 26);
            this.mouseOverStatusLab.TabIndex = 5;
            this.mouseOverStatusLab.Text = "mouse status";

            // 
            // counter
            // 
            this.counter.AutoSize = true;
            this.counter.BackColor = System.Drawing.Color.Lime;
            this.counter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.counter.Cursor = System.Windows.Forms.Cursors.No;
            this.counter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.counter.Font = new System.Drawing.Font("Old English Text MT", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counter.Location = new System.Drawing.Point(12, 18);
            this.counter.Name = "counter";
            this.counter.Size = new System.Drawing.Size(104, 35);
            this.counter.TabIndex = 7;
            this.counter.Text = "counter";
            this.counter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // PictureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.counter);
            this.Controls.Add(this.mouseClickStatusLab);
            this.Controls.Add(this.mouseOverStatusLab);
            this.Controls.Add(this.mouseClickHeader);
            this.Controls.Add(this.mouseOverHeader);
            this.Controls.Add(this.notAPictureLabel);
            this.Controls.Add(this.pictureLabel);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PictureForm";
            this.Text = "Form1";

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label pictureLabel;
        private System.Windows.Forms.Label notAPictureLabel;
        private System.Windows.Forms.Label mouseOverHeader;
        private System.Windows.Forms.Label mouseClickHeader;
        private System.Windows.Forms.Label mouseClickStatusLab;
        private System.Windows.Forms.Label mouseOverStatusLab;
        private System.Windows.Forms.Label counter;
    }
}

