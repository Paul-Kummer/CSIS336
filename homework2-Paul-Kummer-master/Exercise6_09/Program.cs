using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6_09
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find and correct the errors in each of the following segments of code:

            // a. Should print from 100 to 1:

            for (int i = 100; i >= 1; --i)
            {
                Console.WriteLine(i);
            }

            // b. Should display whether an integer value is odd or even:
            int value = 3;

            switch (value % 2)
            {
                case 0:
                    {
                        Console.WriteLine("Even integer");
                        break;
                    }
                    
                case 1:
                    {
                        Console.WriteLine("Odd Integer");
                        break;
                    }
                    
            }

            // c. Should output the odd integers from 19 to 1:
            for (int i = 19; i >= 1; i -= 2) //test this to make sure it prints 19
            {
                Console.WriteLine(i);
            }

            // d. Should output the even integers from 2 to 100:
            int counter = 2;

            do
            {
                Console.WriteLine(counter);
                counter += 2;
            } while (counter <= 100);  //test to make sure this doesn't need to be 102
        }
    }
}
