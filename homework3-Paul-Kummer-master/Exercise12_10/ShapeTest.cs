using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise12_10
{
    class ShapeTest
    {
        static void Main()
        {
            //2-d shapes
            var oneSquare = new Square(4, 4);
            var twoSquare = new Square(6.1m, 6.1m);
            var badSquare = new Square(-10, 0);

            var oneCircle = new Circle(4);
            var twoCircle = new Circle(6.1m);
            var badCircle = new Circle(-10.5m);


            //3-d shapes
            var oneCube = new Cube(4);
            var twoCube = new Cube(6.1m);
            var badCube = new Cube(-1.1m);

            var oneSphere = new Sphere(4);
            var twoSphere = new Sphere(6.1m);
            var badSphere = new Sphere(-.5m);

            //object array
            Shape[] shapeArr = 
            { 
                oneCircle, twoCircle, twoSphere, oneCube, badCircle, 
                oneSquare, twoSquare, badSquare, badSphere, twoCube,
                badCube, oneSphere
            };

            foreach (Shape tmpShape in shapeArr)
            {
                Console.WriteLine("\n\t[ New Shape Details ]");
                Console.WriteLine("=== Obj To String ===\n" + tmpShape);
                Console.WriteLine("\n=== Obj Dim Type ==="); 
                if (tmpShape is TwoDimensionalShape) // added class check
                {
                    Console.WriteLine("2d Shape"); // print that it is 2d
                    Console.WriteLine("\n=== Obj Properties ===");
                    Console.WriteLine($"Area: {tmpShape.Area:F4}"); // print the area
                }

                if (tmpShape is ThreeDimensionalShape)
                {
                    ThreeDimensionalShape tmpThreeD = (ThreeDimensionalShape)tmpShape;
                    Console.WriteLine("3d Shape"); // print that it is 2d
                    Console.WriteLine("\n=== Object Properties ===");
                    Console.WriteLine($"Area: {tmpThreeD.Area:F4}"); // print the area
                    Console.WriteLine($"Volume: {tmpThreeD.Volume:F4}"); // print the volume
                }
                Console.WriteLine("\n=== Object Type ===\n" + GetType(tmpShape));
            }          
        }

        public static string GetType(Shape tmpObj)
        {
            string stringToReturn;

            switch (tmpObj)
            {
                case Circle ci:
                    stringToReturn = "Circle";
                    break;

                case Square sq:
                    stringToReturn = "Square";
                    break;

                case Sphere sp:
                    stringToReturn = "Sphere";
                    break;

                case Cube cu:
                    stringToReturn = "Cube";
                    break;

                default :
                    stringToReturn = "Unrecognized Shape";
                    break;
            }

            return stringToReturn;
        }

    }
}
