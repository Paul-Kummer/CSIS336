using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * **Exercise 13.10** (15 pts) - Format Exceptions.  Open project `Exercise_13_10` and complete the exercise from the book.  
 * In addition to handling `FormatException`, handle `DivideByZeroException` in cases when zero is entered as number of gallons.
 * 
 * Create an app that inputs miles driven and gallons used, and calculates miles per gallon. The example should use exception handling
 * to process the FormatExceptions that occur when converting the input strings to doubles. If invalid data is entered, display a message
 * informing the user.
 */

namespace Exercise_13_10
{
    class Program
    {
        enum Selection { Calcualte = 'c', Exit = 'q', None = 0}

        static void Main(string[] args)
        {
            var userEntry = Selection.None;

            Console.WriteLine("\tThis app will calculate a vehicles fuel efficiency.");
            Console.WriteLine("\tPlease Review the Menu, as menu options may have changed");    

            do
            {
                Console.WriteLine("\n[ Menu: (q, Exits) (c, Calculat MPG) (<any key>, Nothing) ]");
                Console.WriteLine("Select Menu Option: ");

                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'q':
                        userEntry = Selection.Exit;
                        break;

                    case 'c':
                        userEntry = Selection.Calcualte;
                        CalcMPG();
                        break;

                    default:
                        userEntry = Selection.None;
                        break;
                }
                
            } while (userEntry != Selection.Exit);
        }

        static void CalcMPG()
        {
            bool pressForward = true;
            double mPG, milesTraveled=0, gallonsUsed=0;

            // header
            Console.WriteLine("-------------------------------------------------------");

            // check that miles travelled can be converted to double then proceed or abort
            Console.WriteLine("How many miles traveled?: ");
            try
            {
                milesTraveled = double.Parse(Console.ReadLine());
            }

            catch (FormatException e)
            {
                Console.WriteLine($"Error: {e.Data}, Miles cannot be converted to a decimal");
                Console.WriteLine("\t-- Aborting Calcualtion --\n");
                pressForward = false;
            }

            // check that gallons used can be converted to double then proceed or abort
            if (pressForward)
            {
                Console.WriteLine("How many gallons of fuel consumed?: ");
                try
                {
                    gallonsUsed = double.Parse(Console.ReadLine());
                }

                catch (FormatException)
                {
                    Console.WriteLine($"Error: Gallons cannot be converted to a decimal");
                    Console.WriteLine("\t-- Aborting Calcualtion --\n");
                    pressForward = false;
                }
            }

            // check for a divide by zero exception and display results if no error or abort
            if(pressForward)
            {
                try
                {
                    mPG = milesTraveled / gallonsUsed;
                    Console.WriteLine($"\n\t[ Miles Per Gallon is: {mPG:f2} mpg ]\n\n");
                }

                catch (DivideByZeroException)
                {
                    Console.WriteLine("Error: Cannot divide by zero");
                    Console.WriteLine("\t-- Aborting Calculation --");
                }
            }
        }
    }
}
