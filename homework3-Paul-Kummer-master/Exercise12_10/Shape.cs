using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * [ class heirarchy ]
 * abstract shape
 * 
 * ->2d shape : shape
 * # abstract readonly Area "calculate shape area" 
 * 
 * -->circle : 2d shape
 * -->square : 2d shape
 * 
 * ->3d shape : shape
 * # abstract readonly Area "calculate surface area of shape"
 * # abstract readonly Volume "calculate volume of shape"
 * 
 * -->sphere : 3d shape
 * -->cube :3d shape
 * 
 * #create app that utilizes an array of shape references to objs of conc class
 * #foreach obj in array display text description
 * #in foreach use is type to determine type and show types repective area or area and vol
 */

namespace Exercise12_10
{

    abstract class Shape
    {
        public Shape()
        {
        }

        public abstract decimal Area { get; } // all shapes have an area
    }

    // is a Shape
    abstract class TwoDimensionalShape : Shape
    {
        //protected readonly decimal area; // impossible to set with derived classes

        public TwoDimensionalShape() : base()
        {
        }

        public override string ToString()
        {
            return $"*** Two Dimensional Shape ***\nArea: {Area:F4}";
        }
    }

    // is a Shape and TwoDimensionalShape
    class Circle : TwoDimensionalShape
    {
        private readonly decimal radius;
        private readonly decimal area;

        public Circle(decimal tmpRadius) : base()
        {
            radius = tmpRadius >= 0 ? tmpRadius : 0;
            area = (decimal)Math.PI * (decimal)Math.Pow((double)Radius, 2);
        }

        public override decimal Area => area;

        public decimal Radius => radius;

        public override string ToString()
        {
            return "*** Circle ***\n" + base.ToString();
        }
    }

    // is a Shape and TwoDimensionalShape
    class Square : TwoDimensionalShape
    {
        private readonly decimal length, width;
        private readonly decimal area;

        public Square(decimal tmpLength, decimal tmpWidth) : base()
        {
            length = tmpLength >= 0 ? tmpLength : 0;
            width = tmpWidth >= 0 ? tmpWidth : 0;
            area = Length * Width;
        }

        public decimal Length => length;

        public decimal Width => width;

        public override decimal Area => area;

        public override string ToString()
        {
            return "*** Square ***\n" + base.ToString();
        }
    }

    // is a Shape
    abstract class ThreeDimensionalShape : Shape
    {
        public ThreeDimensionalShape (): base() 
        {    
        }

        public abstract decimal Volume { get; }

        public override string ToString()
        {
            return $"*** Three Dimensional Shape ***\nArea: {Area:F4}\nVolume: {Volume:F4}";
        }
    }

    // is a Shape and ThreeDimensionalShape
    class Sphere : ThreeDimensionalShape
    {
        private readonly decimal radius;
        private readonly decimal area, volume;

        public Sphere (decimal tmpRadius) : base()
        {
            radius = tmpRadius >= 0 ? tmpRadius : 0;
            area = (decimal)(4 * Math.PI * Math.Pow((double)Radius, 2));
            volume = (decimal)((4 / 3) * Math.PI * Math.Pow((double)Radius, 3));
        }

        public decimal Radius => radius;

        public override decimal Area => area;

        public override decimal Volume => volume;

        public override string ToString()
        {
            return "*** Sphere ***\n" + base.ToString();
        }
    }

    // is a Shape and ThreeDimensionalShape
    class Cube : ThreeDimensionalShape
    {
        private readonly decimal length;
        private readonly decimal area, volume;

        public Cube(decimal tmpLength) : base()
        {
            length = tmpLength >= 0 ? tmpLength : 0;
            area = (decimal)(6 * Math.Pow((double)Length, 2));
            volume = (decimal)Math.Pow((double)Length, 3);
        }

        public decimal Length => length;

        public override decimal Area => area;

        public override decimal Volume => volume;

        public override string ToString()
        {
            return "*** Cube ***\n" + base.ToString();
        }
    }
}
