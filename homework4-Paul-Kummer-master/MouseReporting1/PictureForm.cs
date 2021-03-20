using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

/*
 *   - one reports whether the mouse is inside or outside the picture box. 
          
            Reported Values: Mouse In / Mouse Out
          
  - the other reports whether a mouse button is pressed when over the picture box and which button is selected. 
        
            Reported Values: Button Up / Button Down Left / Button Down Middle / Button Down Right
 */

namespace MouseReporting
{
    public partial class PictureForm : Form
    {
        int clickCount = 0;
        int screenX = Screen.PrimaryScreen.Bounds.Width;
        int screenY = Screen.PrimaryScreen.Bounds.Height;
        Random randNum = new Random();

        public PictureForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ++clickCount;
            counter.Text = $"{clickCount}";

            if (clickCount % 5 == 0)
            {
                int tmpCt = 0;
                do
                {
                    Cursor.Position = new Point(randNum.Next(screenX), randNum.Next(screenY));
                    Thread.Sleep(100);
                    ++tmpCt;
                } while (tmpCt < 20);
                tmpCt = 0;
            }
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            mouseOverStatusLab.Text = "Mouse In";
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            mouseOverStatusLab.Text = "Mouse Out";
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch(e.Button)
            {
                case MouseButtons.Left:
                    mouseClickStatusLab.Text = "Button Down Left";
                    break;
                case MouseButtons.Right:
                    mouseClickStatusLab.Text = "Button Down Right";
                    break;
                case MouseButtons.Middle:
                    mouseClickStatusLab.Text = "Button Down Middle";
                    break;
                default:
                    mouseClickStatusLab.Text = "no status";
                    break;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClickStatusLab.Text = "Button Up";
        }
    }
}
