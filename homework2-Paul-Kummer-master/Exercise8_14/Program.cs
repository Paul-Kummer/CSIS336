using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Creates the product of integers using a variable length argument method
 */



namespace Exercise8_14
{
    class Program
    {
        static void Main()
        {
            int tmpValue, arrayLen = 0;
            var arrayToPass = new int[arrayLen];
            bool stayInLoop;
            
            Console.WriteLine("This program will ask you to continously enter integers\n" +
                "That will eventually all be multiplied to each other,\n" +
                "Returning the product of those integers.\n\n");

            Console.WriteLine("Would you like to run a test of variable parameter lengths? (Y for yes, any key for manual entry):");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                // Test variables for method Product
                int testNum0 = 0, testNum1 = 1, testNum2 = 2, testNum3 = 3, testNum4 = 4, testNum5 = 5, testNumNeg1 = -1;

                // variables containing resluts of Product tests
                int prodOne = Product(testNum0, testNum1, testNum2, testNum3, testNum4, testNum5, testNumNeg1); 
                int prodTwo = Product(testNum1, testNum2, testNum3, testNum4, testNum5); 
                int prodThree = Product(testNum1, testNum2, testNum3, testNum4, testNum5, testNumNeg1); 
                int prodFour = Product(testNum2, testNum5, testNumNeg1); 
                int prodFive = Product(testNum3, testNum5); 
                int prodSix = Product(testNum1); 
                int prodSeven = Product(); 

                Console.WriteLine($"{"Test One:",12} {"product of (0,1,2,3,4,5,-1)",30}: {prodOne,-4}");// = 0
                Console.WriteLine($"{"Test Two:",12} {"product of (1,2,3,4,5)",30}: {prodTwo,-4}");// = 120
                Console.WriteLine($"{"Test Three:",12} {"product of (1,2,3,4,5,-1)",30}: {prodThree,-4}");// = -120
                Console.WriteLine($"{"Test Four:",12} {"product of (2,5,-1)",30}: {prodFour,-4}");// = -10
                Console.WriteLine($"{"Test Five:",12} {"product of (3,5)",30}: {prodFive,-4}");// = 15
                Console.WriteLine($"{"Test Six:",12} {"product of (1)",30}: {prodSix,-4}");// = 1
                Console.WriteLine($"{"Test Seven:",12} {"product of no integers ()",30}: {prodSeven,-4}");// = 0
                Console.WriteLine("\n\t--- END TEST ---\n" +
                    "\n\tany key to exit");

                Console.ReadKey(true);
            }

            else // lets the user decide which numbers to be used for the product.
            {
                do // will continue while user wants to keep doing different products
                {
                    do // will continue until user wants to know the product of the numbers just entered
                    {
                        Console.WriteLine($"\nEnter an integer, (enter non-integer to finish):");
                        stayInLoop = int.TryParse(Console.ReadLine(), out tmpValue);

                        if (stayInLoop)
                        {
                            Array.Resize<int>(ref arrayToPass, ++arrayLen);
                            arrayToPass[arrayLen - 1] = tmpValue; // subtract one to refer to an index within range
                        }
                    } while (stayInLoop);

                    tmpValue = Product(arrayToPass); // uses overloaded method instead of the multiple parameters of the test

                    Console.WriteLine($"\nThe product of the integers is: {tmpValue}");
                    Console.WriteLine("\n\t--- Do another Product? (Y, to do another) ---");

                    // reset values back to default
                    Array.Resize<int>(ref arrayToPass, 0);
                    tmpValue = 0;
                } while (Console.ReadKey().Key == ConsoleKey.Y);
            }
        }

        static int Product(params int[] args)
        {

            int curValue = 0;

            if (args.Length > 0)
            {
                curValue = 1;

                foreach (int tmpVal in args)
                {
                    curValue *= tmpVal;
                }
            }

            return curValue;
        }

        static int Product(Array tmpArray) //overloaded method to use an array instead of variable length params
        {
            int curValue = 1;

            foreach (int tmpVal in tmpArray)
            {
                curValue *= tmpVal;
            }

            return curValue;
        }
    }
}
