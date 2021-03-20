using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptTest2
{
    public class ExceptionHandlingQuestions
    {
        public void Execute()
        {
            Console.WriteLine("\nException Handling Question");

            //----------------------------------------------------------------------------------------------------------
            // Question #1: The following code uses a flaky number reader to read numbers from the console and
            //              write them out as entered.  The flaky number reader throws exceptions when 1, 2 or 100
            //              are entered.  Add try/catch logic to the code below to catch the exceptions that occur
            //              when 1 or 2 are entered, write out the exception message and continue reading numbers.
            //              Don't handle the exception when 100 is entered.

            var numberReader = new FlakyClass();
            var nextNumber = 0;
            while (nextNumber != -1)
            {
                try
                {
                    nextNumber = numberReader.GetNextFlakyInput();
                    Console.WriteLine($"You entered {nextNumber}");
                }

                catch (InvalidOperationException e)
                {
                    Console.WriteLine($"\t--- Error ---  [ {e.Message} ]\n");
                }

                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"\t--- Error ---  [ {e.Message} ]\n");
                }

                catch (FormatException e)
                {
                    Console.WriteLine($"\t--- Error ---  [ {e.Message} ]\n");
                }

                // Can be used to catch and rethrow the exception if the generic exception is being used
                /*
                catch (ArgumentException e)
                {
                    throw;
                }
                */

                // Can be used to catch a generic exception
                /*
                catch(Exception e)
                {
                    Console.WriteLine($"\t--- Error ---  [ {e.Message} ]");
                }
                */
            }
        }
    }

    public class FlakyClass
    {
        public int GetNextFlakyInput()
        {
            Console.WriteLine("Enter a number:");
            int newNumber = int.Parse(Console.ReadLine());
            
            switch (newNumber)
            {
                case 1:
                    throw new InvalidOperationException("You can't enter 1");
                case 2:
                    throw new ArgumentOutOfRangeException("Numbers can only be -1 or >= 3");
                case 100:
                    throw new ArgumentException("Number can never be 100!");
                default:
                    return newNumber;
            }
        }

    }
}
