using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//change the internal representation of time2 to use seconds from midnight
//instead of using HH:MM:SS, there will be no net change from the user's perspective

namespace Exercise10_4
{
    public class Time2
    {
        private int hour; // 0 - 23 seconds
        private int minute; // 0 - 59 seconds
        private int second; // 0 - 59 seconds
        private int secondsFromMid = 0; // 0 - 86,399 seconds

        // constructor can be called with zero, one, two or three arguments
        public Time2(int hour = 0, int minute = 0, int second = 0)
        {
            SetTime(hour, minute, second); // invoke SetTime to validate time
        }

        // Time2 constructor: another Time2 object supplied as an argument
        public Time2(Time2 time)
           : this(time.Hour, time.Minute, time.Second) { }

        // set a new time value using universal time; invalid values
        // cause the properties' set accessors to throw exceptions
        public void SetTime(int hour, int minute, int second)
        {
            Hour = hour; // set the Hour property
            Minute = minute; // set the Minute property
            Second = second; // set the Second property
        }

        // property that gets and sets the hour
        public int Hour
        {
            get
            {
                return secondsFromMid / 3600;
            }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                       value, $"{nameof(Hour)} must be 0-23");
                }

                hour = value; // 3600 seconds per hour
                SecFromMid(value, Minute, Second); // pass hour value to find new sec to midnight
            }
        }

        // property that gets and sets the minute
        public int Minute
        {
            get
            {
                return (secondsFromMid - (Hour * 3600)) / 60;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                       value, $"{nameof(Minute)} must be 0-59");
                }

                minute = value; // 60sec per minute
                SecFromMid(Hour, value, Second); // pass minute value to find new sec to midnight
            }
        }

        // property that gets and sets the second
        public int Second
        {
            get
            {
                return secondsFromMid - ((Hour * 3600) + (Minute * 60));
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                       value, $"{nameof(Second)} must be 0-59");
                }

                second = value;
                SecFromMid(Hour, Minute, value); // pass second value to find new sec to midnight
            }
        }
        
        // determines seconds from midnight
        private void SecFromMid(int hr = 0, int min = 0, int sec = 0)
        {
            secondsFromMid = hr * 3600 + min * 60 + sec; 
        }

        // convert to string in universal-time format (HH:MM:SS)
        public string ToUniversalString() =>
           $"{Hour:D2}:{Minute:D2}:{Second:D2}";

        // convert to string in standard-time format (H:MM:SS AM or PM)
        public override string ToString() =>
           $"{((Hour == 0 || Hour == 12) ? 12 : Hour % 12)}:" +
           $"{Minute:D2}:{Second:D2} {(Hour < 12 ? "AM" : "PM")}";
    }
}
