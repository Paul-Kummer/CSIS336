using System;
using System.Collections.Generic;
using System.Text;

namespace exercise4._12
{
    class DateTest
    {
        static void Main()
        {
            Date date1 = new Date(31, 07, 1986);
            Console.WriteLine("\ninitial date");
            ShowDate();

            date1.Day = 01;
            date1.Month = 01;
            date1.Year = 1901;
            Console.WriteLine("\ndate values changed");
            ShowDate();

            void ShowDate()
            {
                Console.WriteLine(date1.DisplayDate());
                Console.WriteLine($"\nDay: {date1.Day}" +
                                  $"\nMonth: {date1.Month}" +
                                  $"\nYear: {date1.Year}");
            }
        }
    }
}
