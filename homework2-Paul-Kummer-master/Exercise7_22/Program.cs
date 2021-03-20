using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7_22
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal tmpVal;
            bool isNotDone = true;
            do
            {
                Console.WriteLine("What would you like to convert to, " +
                    "[0:Finished, " +
                    "1:Celsius to Fahrenheit, " +
                    "2:Fahrenheit to Celsius]: ");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D0:
                    {
                            Console.WriteLine("\n\t*** Finished ***\n");
                            isNotDone = false;
                            break;
                    }

                    case ConsoleKey.D1:
                    {
                            Console.WriteLine("\n\t--- Converting Celsius to Fahrenheit ---");
                            tmpVal = getTempFromUser();

                            Console.WriteLine($"\t\t[ Conversion is: {Celsius(tmpVal):f2}°C ]\n\n");
                            break;
                    }

                    case ConsoleKey.D2:
                    {
                            Console.WriteLine("\n\t--- Converting Fahrenheit to Celsius ---");
                            tmpVal = getTempFromUser();

                            Console.WriteLine($"\t\t[ Conversion is: {Fahrenheit(tmpVal):f2}°F ]\n\n");
                            break;
                    }

                    default:
                    {
                            Console.WriteLine("\t!!! Invalid Menu Option, please choose from [0, 1, 2]\n\n");
                            break;
                    }
                }

            } while (isNotDone) ;
        }

        static decimal getTempFromUser()
        {
            decimal tempToConvert;
            bool notDone = true;

            do
            {
                Console.Write("What is the temperature you would like to convert: ");

                if (decimal.TryParse(Console.ReadLine(), out tempToConvert))
                {
                    notDone = false;
                }

                else
                {
                    Console.WriteLine("\t! INVALID ENTRY, please enter a number only !\n");
                }
            } while (notDone);

            return (tempToConvert);
        }

        //a. convert degree fahrenheit to celsius with expression body method
        static decimal Celsius(decimal degreeF) => ((5.0m / 9.0m) * (degreeF - 32));

        //b. covert degree celsius to farenheit with expression body method
        static decimal Fahrenheit(decimal degreeC) => (((9.0m / 5.0m) * degreeC) + 32);
    }
}
