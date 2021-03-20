using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise8_21
{
    class Graph
    {
        const int graphSize = 20; // book states 20 for dimensions

        public int[,] Floor { get; set; }
        public bool GraphOn { get; set; }
        public int GraphSize { get; private set; }

        public Graph()
        {
            GraphSize = graphSize; 
            GraphOn = true;
            Floor = new int[graphSize, graphSize];
        }

        public string Display()
        {
            string tmpStr = "", strToReturn = "", border = "\t\t######################";

            for (int tmpY = 0; tmpY < Floor.GetLength(1); ++tmpY) // iterate through columns
            {
                for (int tmpX = 0; tmpX < Floor.GetLength(0); ++tmpX) // iterate through rows
                {
                    int curVal = Floor[tmpX, tmpY];

                    switch (curVal)
                    {
                        case 0: // pen mark not left
                            tmpStr += " ";
                            break;

                        case 1: // pen mark left
                            tmpStr += "*";
                            break;

                        default: // this is where the turtle is
                            tmpStr += "\u0278";
                            break;
                    }                   
                }

                strToReturn += "\t\t|" + tmpStr + "|" + "\n"; // add the row to the total string on a newline
                tmpStr = ""; // reset row for new marks
            }

            return border + "\n" + strToReturn  + border;
        }

        public void ToggleGraph()
        {
            GraphOn = GraphOn ? false : true;
        }
    }
}
