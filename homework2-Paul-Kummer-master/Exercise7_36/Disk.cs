using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7_36
{
    public class Disk
    {
        public int Size { get; private set; }
        public int XPos { get; set; }
        public int YPos { get; set; }

        public Disk(int tmpSize, int tmpXPos = 0, int tmpYPos = 0)
        {
            Size = tmpSize;
            XPos = tmpXPos;
            YPos = tmpYPos;
        }  
    }
}
