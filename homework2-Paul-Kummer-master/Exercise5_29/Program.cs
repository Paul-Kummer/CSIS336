using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5_29
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 5, y = 8;

            Console.WriteLine("--------Exercise 5.29 a.----------------");
            // a. By adding braces, correct the following code to print:
            // @@@@@
            // $$$$$
            // &&&&&

            if (y == 8)
            { 

                if (x == 5)
                {
                    Console.WriteLine("@@@@@");
                }

                else
                {
                    Console.WriteLine("#####");
                }
            }

            Console.WriteLine("$$$$$");
            Console.WriteLine("&&&&&");

            Console.WriteLine("--------Exercise 5.29 b.----------------");
            // b. By adding braces, correct the following code to print:
            // @@@@@

            if (y == 8)
            {
                if (x == 5)
                {
                    Console.WriteLine("@@@@@");
                }

                else
                {
                    Console.WriteLine("#####");
                    Console.WriteLine("$$$$$");
                    Console.WriteLine("&&&&&");
                }
            }
           
            

            Console.WriteLine("--------Exercise 5.29 c.----------------");
            // c. By adding braces, correct the following code to print:
            // @@@@@
            // &&&&&

            if (y == 8)
            {
                if (x == 5)
                    Console.WriteLine("@@@@@");
                else
                {
                    Console.WriteLine("#####");
                    Console.WriteLine("$$$$$");
                }
            }
           
            Console.WriteLine("&&&&&");

            Console.WriteLine("--------Exercise 5.29 d.----------------");
            // d. By adding braces, correct the following code to print:
            // #####
            // $$$$$
            // &&&&&

            x = 5;
            y = 7;
            if (y == 8)
            {
                if (x == 5)
                {
                    Console.WriteLine("@@@@@"); //no print
                }
            }

            else
            {
                Console.WriteLine("#####"); //1st
                Console.WriteLine("$$$$$"); //2nd
                Console.WriteLine("&&&&&"); //3rd
            }
        }
    }
}
