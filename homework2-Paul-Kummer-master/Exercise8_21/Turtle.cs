using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise8_21
{
    class Turtle
    {
        enum markType
        {
            Eraser = 0,
            Pen = 1,
            None = -1
        }

        public enum Facing
        {
            Unknown = 0,
            Up = 1,
            Right = 2,
            Down = 3,
            Left = 4
        }

        enum Rotate
        {
            Nowhere = 0,
            Right = 1,
            Left = 2
        }

        public Turtle(String name, int startX = 0, int startY = 0)
        {
            Name = name;
            XPos = startX;
            YPos = startY;
            PenDown = false;
            EraserDown = false;
            Direction = Facing.Right;
        }

        public bool PenDown { get; set; }
        public bool EraserDown { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public string Name { get; set; }
        public Facing Direction { get; private set; }

        // Tells the turtle to move a specified number of spaces in the direction its facing on a specified graph aka"Floor"
        public void Move(int spaces, Graph graph)
        {
            // determines if the turtle is erasing/ marking/ or just moving witout a trail
            markType marking;
            if (PenDown)
            {
                marking = markType.Pen;
            }

            else if (EraserDown)
            {
                marking = markType.Eraser;
            }

            else
            {
                marking = markType.None;
            }

            // determines how to update the Floor array by changing values based on what direction the turtles moves
            switch (Direction)
            {
                case Facing.Unknown: // could use this for random direction if you spin the turtle too many times
                    break;

                case Facing.Down:
                    foreach (int tmp in Enumerable.Range(YPos, spaces))
                    {
                        if (YPos < (graph.GraphSize - 1))
                        {
                            graph.Floor[XPos, YPos] = marking == markType.None ? 0 : (int)marking;
                            ++YPos;
                            graph.Floor[XPos, YPos] = -1; // turtles resting location
                        }
                    }
                    break;

                case Facing.Up:
                    // progresses the turtle across the floor by updating the Floor array 
                    // NOTE: add delay so the turtle doesn't move intantaneously
                    foreach (int tmp in Enumerable.Range(YPos, spaces)) 
                    {
                        if (YPos > 0)
                        {
                            graph.Floor[XPos, YPos] = marking == markType.None ? 0 : (int)marking;
                            --YPos;
                            graph.Floor[XPos, YPos] = -1; // turtles resting location
                        }
                    }
                    break;

                case Facing.Left:
                    foreach (int tmp in Enumerable.Range(YPos, spaces))
                    {
                        if (XPos > 0)
                        {
                            graph.Floor[XPos, YPos] = marking == markType.None ? 0 : (int)marking;
                            --XPos;
                            graph.Floor[XPos, YPos] = -1; // turtles resting location
                        }
                    }
                    break;

                case Facing.Right:
                    foreach (int tmp in Enumerable.Range(YPos, spaces))
                    {
                        if (XPos < (graph.GraphSize - 1))
                        {
                            graph.Floor[XPos, YPos] = marking == markType.None ? 0 : (int)marking;
                            ++XPos;
                            graph.Floor[XPos, YPos] = -1; // turtles resting location
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        public void Turn(int rotation)
        { 
            switch (rotation) //1:up, 2:right, 3:down, 4:left
            {
                case 3: // right turn
                    Direction = (int)Direction + 1 <= 4 ? (Facing) (int)Direction + 1 : (Facing)1;
                    break;

                case 4: // left turn
                    Direction = (int)Direction - 1 >= 1 ? (Facing)(int)Direction - 1 : (Facing)4;
                    break;

                default: // should never occur, but it exists just in case
                    Direction = Facing.Unknown;
                    break;
            }
        }

        // placing the turtle on the Floor at its current x,y coordinates
        public void Place(Graph graph)
        {
            graph.Floor[XPos, YPos] = -1;
        }

        // Both pen and eraser will switch the other to false so they both can't be active
        public void TogglePen()
        {
            PenDown = PenDown ? false : true;
            if (PenDown) { EraserDown = false; }
        }

        public void ToggleEraser()
        {
            EraserDown = EraserDown ? false : true;
            if (EraserDown) { PenDown = false; }
        }
    }
}
