using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7_36
{
    public class Peg
    {
        private Disk topDisk;

        public List<Disk> DisksOnStack = new List<Disk> { };
        public int CurrentHeight { get; private set; } = 0;
        public int PegPos { get; set; }
        public int Height { get; set; }
        public bool Start { get; private set; }
        public bool Finish { get; private set; }
        public bool Stage { get; private set; }
        public string Name { get; set; } = "not set";

        public Peg(bool isStart = false, bool isFinish = false, bool isStage = false, int maxHeight = 0, int pegPos = 0)
        {
            Name = Name;
            Height = maxHeight;
            Start = isStart;
            Finish = isFinish;
            Stage = isStage;
            PegPos = pegPos;
            CurrentHeight = CurrentHeight;
            TopDisk = null;
        }

        public Disk TopDisk
        {
            get
            {
                return topDisk;                         
            }

            set
            {
                if (DisksOnStack.Count() == 0 && value != null)
                {
                    topDisk = value;
                    ++CurrentHeight;
                    topDisk.YPos = CurrentHeight;
                    topDisk.XPos = PegPos;
                    DisksOnStack.Add(topDisk);
                }

                else if (value != null && value.Size < topDisk.Size)
                {
                    topDisk = value;
                    ++CurrentHeight;
                    topDisk.YPos = CurrentHeight;
                    topDisk.XPos = PegPos;
                    DisksOnStack.Add(topDisk);
                }
            }
        }

        public Disk RemoveDisk(Disk tmpDisk)
        {
            if (DisksOnStack.Contains(tmpDisk))
            {
                DisksOnStack.Remove(tmpDisk);
                --CurrentHeight;
                if (DisksOnStack.Count != 0)
                {
                    topDisk = DisksOnStack.OrderByDescending(x => x.Size).Last(); //Not sure if this will work
                }
                return tmpDisk;              
            }

            return null;

        }

        public bool IsFinished()
        {
            bool isFinished = CurrentHeight == Height && Finish;
            return isFinished;
        }
    }
}
