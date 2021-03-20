using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10_8
{
    public class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("### INSTANTIANTING RATIONAL NUMBERS ###");

            // test default
            Console.WriteLine("[]");
            var defaultRat = new Rational();
            PrintRat(defaultRat);

            // test 1/2
            Console.WriteLine("[1/2]");
            var simpleRat = new Rational(1,2);
            PrintRat(simpleRat);

            // test -2/4
            Console.WriteLine("[-2/4]");
            var negativeNumRat = new Rational(-2, 4);
            PrintRat(negativeNumRat);

            // test 2/-4
            Console.WriteLine("[2/-4]");
            var negativeDenRat = new Rational(2, -4);
            PrintRat(negativeDenRat);

            // test -3/-4
            Console.WriteLine("[-3/-4]");
            var doublNegativeRat = new Rational(-3, -4);
            PrintRat(doublNegativeRat);

            // test 10/12
            Console.WriteLine("[10/12]");
            var bigNumRat = new Rational(10, 12);
            PrintRat(bigNumRat);

            // test 12/10
            Console.WriteLine("[12/10]");
            var bigDenRat = new Rational(12, 10);
            PrintRat(bigDenRat);

            // test 10/0 throws error
            //Console.WriteLine("[10/0]");
            //var errorRat = new Rational(10, 0);
            //PrintRat(errorRat);

            Console.WriteLine("### TRYING OPERATIONS RATIONAL NUMBERS ###");
            // test addition
            Console.WriteLine("[12/10 + 10/12 = 61/30]");
            PrintRat(bigDenRat + bigNumRat);

            // test subtraction
            Console.WriteLine("[1/2 - 2/-4 = 0/4]");
            PrintRat(simpleRat - negativeDenRat);

            // test multiplication
            Console.WriteLine("[(-3/-4) * (12/10) = 9/10 ]");
            PrintRat(doublNegativeRat * bigDenRat);

            // test division
            Console.WriteLine("[(-2/4) / (2/-4) = 1/1]");
            PrintRat(negativeNumRat / negativeDenRat);
        }

        static void PrintRat(Rational tmp)
        {
            Console.WriteLine($"Numerator: {tmp.Numerator}, Denominator: {tmp.Denominator}" +
                $"\nGFC      --> {tmp.GCF}" +
                $"\nRational --> {tmp}" +
                $"\nFloat    --> {tmp.PrintFloat()}\n");
        }
    }
}
