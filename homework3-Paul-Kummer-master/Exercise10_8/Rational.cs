using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * a. add two rational nums
 * b. sub two rational nums
 * c. mult two rational nums
 * d. divide two rational nums
 * e. display rational num
 * f. display as float rational num
 */

namespace Exercise10_8
{
    public class Rational
    {
        private int den = 1;
        private int num = 0;

        public int GCF { get; private set; }

        public Rational()
        {
        }

        public Rational(int numerator, int denominator = 1) : this()
        {
            GCF = FindGCF(numerator, denominator);
            Numerator = numerator;
            Denominator = denominator;
        }

        public int Numerator 
        { 
            get
            {
                return num;
            }

            private set
            {
                num = value / GCF;
            }
        }


        public int Denominator
        {
            get
            {
                return den;
            }

            private set
            {
                // throw an error if the rational is divided by zero
                if (value == 0)
                {
                    throw new DivideByZeroException( $"{nameof(Denominator)} must not be zero");
                }

                // move the negative sign to the numerator, cancel if numerator already negative
                if (value < 0)
                {
                    num *= -1; // if num get method is used a division by GCF happens again creating incorrect value
                    den = (-1 * value) / GCF;
                }

                else
                {
                    den = value / GCF;
                }
            }
        }

        public static Rational operator +(Rational ratOne, Rational ratTwo)
        {
            int newNum = (ratOne.Numerator * ratTwo.Denominator) + (ratTwo.Numerator * ratOne.Denominator);
            int newDen = (ratOne.Denominator * ratTwo.Denominator);

            return new Rational(newNum, newDen);
        }

        public static Rational operator -(Rational tmpRatOne, Rational tmpRatTwo)
        {
            int newNum = (tmpRatOne.Numerator * tmpRatTwo.Denominator) - (tmpRatOne.Numerator * tmpRatOne.Denominator);
            int newDen = (tmpRatOne.Denominator * tmpRatTwo.Denominator);

            return new Rational(newNum, newDen);
        }

        public static Rational operator *(Rational tmpRatOne, Rational tmpRatTwo)
        {
            int newNum = tmpRatOne.Numerator * tmpRatTwo.Numerator;
            int newDen = tmpRatOne.Denominator * tmpRatTwo.Denominator;

            return new Rational(newNum, newDen);
        }

        public static Rational operator /(Rational tmpRatOne, Rational tmpRatTwo)
        {
            int newNum = tmpRatOne.Numerator * tmpRatTwo.Denominator;
            int newDen = tmpRatOne.Denominator * tmpRatTwo.Numerator;

            return new Rational(newNum, newDen);
        }

        // e. display rational num
        public override string ToString() => $"{Numerator}/{Denominator}";

        // f. display floating point rational num
        public string PrintFloat(int precison=0) // can't figure out hot to implement variable precison
        {
            decimal newDec = (decimal)Numerator / Denominator;
            return $"{newDec:F5}";
        }

        static int FindGCF(int top, int bottom) // find the greatest common factor
        {
            List<int> topFactorials = new List<int>() { 1, top};
            List<int> bottomFactorials = new List<int>() { 1, bottom };

            // find all factorials for the numerator
            for (int x = 2; x <= Math.Abs(top); x++)
            {
                if (top % x == 0)
                {
                    topFactorials.Add(x);
                }
            }

            // find all factorials for the denominator
            for (int x = 2; x <= Math.Abs(bottom); x++)
            {
                if (bottom % x == 0)
                {
                    bottomFactorials.Add(x);
                }
            }

            // LINQ to find common factorials
            var matches =
                from topF in topFactorials
                join bottomF in bottomFactorials
                on topF equals bottomF
                orderby topF descending // make the largest value first
                select topF;

            return matches.First();
        }
    }
}
