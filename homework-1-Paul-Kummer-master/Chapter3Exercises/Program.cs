using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------- 3.14 Displaying Numbers-------");

            // Part a
            Console.WriteLine("1 2 3 4");

            // Part b
            Console.Write("1 ");  
            Console.Write("2 ");
            Console.Write("3 ");
            Console.Write("4 ");

            // Part c
            int arg1 = 1, arg2 = 2, arg3 = 3, arg4 = 4;

            Console.WriteLine("\n{0} {1} {2} {3}", arg1, arg2, arg3, arg4);



            Console.WriteLine("\n------- 3.17 Comparing Integers-------");

            int usrInt1, usrInt2, usrInt3, tmpInt = 1;

            Console.WriteLine("Input Number 1: ");
            string usrInput = Console.ReadLine();

            Console.WriteLine("Input Number 2: ");
            string usrInput2 = Console.ReadLine();

            Console.WriteLine("Input Number 3: ");
            string usrInput3 = Console.ReadLine();

            usrInt1 = int.Parse(usrInput);
            usrInt2 = int.Parse(usrInput2);
            usrInt3 = int.Parse(usrInput3);

            List<int> usrNums = new List<int>()
            {
                usrInt1,
                usrInt2,
                usrInt3
            };

            foreach(int tmpValue in usrNums)
            {
                tmpInt *= tmpValue;
            };

            Console.WriteLine("\nSum :{0}", usrNums.Sum());

            Console.WriteLine("Avg: {0}", usrNums.Average());

            Console.WriteLine("Product: {0}", tmpInt);

            Console.WriteLine("Max: {0}", usrNums.Max());

            Console.WriteLine("Min: {0}", usrNums.Min());



            Console.WriteLine("\n------- 3.24 Odd or Even-------");
            
            bool startLooping = true; //controls when the loop stops

            while (startLooping)
            {
                Console.WriteLine("Input Number: (enter nothing to stop loop)");
                string usrInput4 = Console.ReadLine();

                if (usrInput4 == string.Empty) //checks for empty string, telling the loop to stop
                {
                    startLooping = false;
                }

                else //if not an empty string, covert user input to integer and check whether its odd or even
                {
                    int usrIntInput = int.Parse(usrInput4);

                    if (usrIntInput % 2 == 0)
                    {
                        Console.WriteLine("Number {0} Is Even\n", usrInput4);
                    }

                    else
                    {
                        Console.WriteLine("Number {0} is Odd\n", usrInput4);
                    }
                }
            }



            Console.WriteLine("\n------- 3.25 Multiples-------");

            startLooping = true;

            while (startLooping)
            {
                string usrInput5, usrInput6;

                Console.WriteLine("Input Number to Divide: (enter nothing to stop loop)");
                usrInput5 = Console.ReadLine();
                if (usrInput5 == string.Empty) //checks for empty string, telling the loop to stop
                {
                    startLooping = false;
                }

                else
                {
                    Console.WriteLine("Input Divisor: (enter nothing to stop loop)");
                    usrInput6 = Console.ReadLine();
                    if (usrInput6 == string.Empty) //checks for empty string, telling the loop to stop
                    {
                        startLooping = false;
                    }

                    if (startLooping == true) //if not an empty string, covert user input to integer and check whether its odd or even
                    {
                        int usrIntInput1 = int.Parse(usrInput5);
                        int usrIntInput2 = int.Parse(usrInput6);

                        if (usrIntInput1 % usrIntInput2 == 0)
                        {
                            Console.WriteLine("Number {0} Is Divisible by {1}\n", usrInput5, usrInput6);
                        }

                        else
                        {
                            Console.WriteLine("Number {0} Is NOT Divisible by {1}\n", usrInput5, usrInput6);
                        }
                    }
                }
            }



            Console.WriteLine("\n------- 3.28 Digits of an integer-------");
            /* input 1 number of 5 digits 12345
               output each number seperated by 3 spaces*/

            bool checkValid = true;
            while (checkValid)
            {
                Console.WriteLine("Input a Five Digit Number: ");
                string usrInput7 = Console.ReadLine();

                if (usrInput7.Length == 5)
                {
                    checkValid = false;
                    
                    foreach(char tmp in usrInput7)
                    {
                        Console.Write("{0,-4}", tmp);
                    }
                }

                else
                {
                    Console.WriteLine("Invalid number length. Please Enter a five digit integer");
                }
            }


        }
    }
}
