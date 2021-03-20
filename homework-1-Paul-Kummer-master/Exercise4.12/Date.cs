using System;

namespace exercise4._12
{
    class Date
    {
        private int _minute;

        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Date(int tmpDay, int tmpMonth, int tmpYear)
        {
            Day = tmpDay;
            Month = tmpMonth;
            Year = tmpYear;
        }

        public string DisplayDate()
        {
            return $"{Month}/{Day}/{Year}";
        }
    }
}
