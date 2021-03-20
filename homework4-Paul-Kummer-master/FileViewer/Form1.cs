using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * **File Viewer Application** (20 pts.) - Create a Winforms app that provides selection of a text file and displays the contents.

  - [ ] Create a new WinForms project in Homework4 named `FileViewer`. (Right-click on the Homework4 solution and choose *Add->New Project*.)
  - [ ] Add a text box to the form and make it a) multi line b) read only and c) containing scrollbars
  - [ ] Add a button to the form that uses the open file dialog to select a text file and display the contents in the text box added above. 
        (Note: The open file dialog should be filtered to only select text (*.txt) files)
  - [ ] Exercise the new form by selecting different sized text files.  Ensure the scrollbar allows all text to be visible.
  - [ ] (Bonus Points) Allow multiple files to be selected and provide buttons on the form to navigate between selected text.
 */

namespace FileViewer
{
    public partial class Form1 : Form
    {
        protected int tabCount = 0;

        public Form1()
        {
            InitializeComponent();
            tabControl1.SelectedTab = defaultTab;
        
            textBox1.Lines = new string[]
            {
                "Created By: Paul Kummer",
                "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n",
                "Select a File to Open Below",
                "             |",
                "             |",
                "             |",
                "            \\|/",
            };         
        }

        // open a file viewer and allow multiple selections
        // open each text file in its own tab from, use a file list and iterate through it
        private void openTextButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        // remove the current tab, decrease tabcounter, and restore defaulttab if no tabs exist
        private void closeTabButton_Click(object sender, EventArgs e)
        {
            --tabCount;

            tabControl1.TabPages.Remove(tabControl1.SelectedTab);

            if(tabControl1.TabCount <= 0)
            {
                tabControl1.TabPages.Add(defaultTab);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            CreateNewTabs(openFileDialog1.FileNames);         
        }

        private void CreateNewTabs (String[] filePaths)
        {
            if (filePaths.Length > 0)
            {
                tabControl1.TabPages.Remove(defaultTab);

                foreach (string filePath in filePaths)
                {
                    ++tabCount;

                    TextBox newTextBox = new TextBox();
                    string fileName = filePath.Split('\\').Last();
                    string tabName = $"({tabCount}) {fileName}";

                    // add new tab
                    tabControl1.TabPages.Add(tabName, tabName);

                    // ensure new tab is selected
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOfKey(tabName);

                    // add new textbox and populate it
                    var readFileText = System.IO.File.ReadAllLines(filePath);

                    newTextBox.Lines = readFileText;
                    newTextBox.Name = $"{fileName}TB";
                    newTextBox.Multiline = true;
                    newTextBox.AcceptsReturn = true;
                    newTextBox.AcceptsTab = true;
                    newTextBox.ReadOnly = true;
                    newTextBox.Font = new Font("Times New Roman", 12);
                    newTextBox.Size = tabControl1.SelectedTab.Size;
                    newTextBox.WordWrap = false;
                    newTextBox.Dock = DockStyle.Fill;
                    newTextBox.ScrollBars = ScrollBars.Both;

                    tabControl1.SelectedTab.Controls.Add(newTextBox);
                }
            }
        }

        #region delete me
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        #endregion

        private void openTestFiles_Click(object sender, EventArgs e)
        {
            var testFilesList = System.IO.Directory.GetFiles(System.Windows.Forms.Application.StartupPath + @"\testFiles");

            CreateNewTabs(testFilesList);
        }
    }
}
