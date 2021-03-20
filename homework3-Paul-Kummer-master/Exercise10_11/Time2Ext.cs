using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10_11
{
    public class Time2Test
    {
        static void Main()
        {
            var t1 = new Time2(); // 00:00:00            
            var t2 = new Time2(2); // 02:00:00         
            var t3 = new Time2(21, 34); // 21:34:00    
            var t4 = new Time2(12, 25, 42); // 12:25:42
            var t5 = new Time2(t4); // 12:25:42        

            Console.WriteLine("Constructed with:\n");
            Console.WriteLine("t1: all arguments defaulted");
            Console.WriteLine($"   {t1.ToUniversalString()}"); // 00:00:00
            Console.WriteLine($"   {t1.ToString()}\n"); // 12:00:00 AM

            Console.WriteLine(
               "t2: hour specified; minute and second defaulted");
            Console.WriteLine($"   {t2.ToUniversalString()}"); // 02:00:00
            Console.WriteLine($"   {t2.ToString()}\n"); // 2:00:00 AM

            Console.WriteLine(
               "t3: hour and minute specified; second defaulted");
            Console.WriteLine($"   {t3.ToUniversalString()}"); // 21:34:00
            Console.WriteLine($"   {t3.ToString()}\n"); // 9:34:00 PM

            Console.WriteLine("t4: hour, minute and second specified");
            Console.WriteLine($"   {t4.ToUniversalString()}"); // 12:25:42
            Console.WriteLine($"   {t4.ToString()}\n"); // 12:25:42 PM

            Console.WriteLine("t5: Time2 object t4 specified");
            Console.WriteLine($"   {t5.ToUniversalString()}"); // 12:25:42
            Console.WriteLine($"   {t5.ToString()}"); // 12:25:42 PM

            // using extension method tick
            Console.WriteLine("\n\t--- Testing Extension Method Tick ---");
            var secToMin = new Time2(0, 0, 59);
            var minToHour = new Time2(0, 59, 59);
            var hourToHour = new Time2(23, 59, 59);

            // test increment to a minute
            Console.WriteLine("secToMin Time2 object before Tick");
            Console.WriteLine($"   {secToMin.ToUniversalString()}"); // 00:00:59
            Console.WriteLine($"   {secToMin.ToString()}"); // 00:00:59 AM

            secToMin.Tick();

            Console.WriteLine("secToMin Time2 object after Tick");
            Console.WriteLine($"   {secToMin.ToUniversalString()}"); // 00:00:59
            Console.WriteLine($"   {secToMin.ToString()}\n"); // 00:00:59 AM

            // test increment to an hour
            Console.WriteLine("minToHour: Time2 object before Tick");
            Console.WriteLine($"   {minToHour.ToUniversalString()}"); // 00:59:59
            Console.WriteLine($"   {minToHour.ToString()}"); // 00:59:59 AM

            minToHour.Tick();

            Console.WriteLine("minToHour: Time2 object after Tick");
            Console.WriteLine($"   {minToHour.ToUniversalString()}"); // 00:59:59
            Console.WriteLine($"   {minToHour.ToString()}\n"); // 00:59:59 AM

            // test increment from hour to hour
            Console.WriteLine("hourToHour: Time2 object before Tick");
            Console.WriteLine($"   {hourToHour.ToUniversalString()}"); // 23:59:59
            Console.WriteLine($"   {hourToHour.ToString()}"); // 11:59:59 PM

            hourToHour.Tick();

            Console.WriteLine("hourToHour: Time2 object after Tick");
            Console.WriteLine($"   {hourToHour.ToUniversalString()}"); // 23:59:59
            Console.WriteLine($"   {hourToHour.ToString()}\n"); // 11:59:59 PM


            // attempt to initialize t6 with invalid values
            try
            {
                var t6 = new Time2(27, 74, 99); // invalid values
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("\nException while initializing t6:");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Type any key to quit...");
            Console.ReadKey();
        }
    }

    static class Time2Extension
    {
        public static void Tick(this Time2 tok)
        {
            if (tok.Second == 59 && tok.Minute == 59 && tok.Hour == 23)
            {
                tok.Second = 0;
                tok.Minute = 0;
                tok.Hour = 0;
            }

            else if (tok.Second == 59 && tok.Minute == 59)
            {
                tok.Second = 0;
                tok.Minute = 0;
                tok.Hour++;
            }

            else if (tok.Second == 59)
            {
                tok.Second = 0;
                tok.Minute++;
            }

            else
            {
                tok.Second++;
            }
        }
    }
}
