using System.Collections.Generic;

namespace DateAddDemo
{
    public class Month
    {
        private int _monthNumber;
        private int _daysInMonth;

        public int DaysInMonth => _daysInMonth;
        public int MonthNumber => _monthNumber;

        public static List<Month> GetMonths()
        {
            return new List<Month>()
            {
                new Month(){_monthNumber = 1, _daysInMonth = 31},
                new Month(){_monthNumber = 2, _daysInMonth = 28},
                new Month(){_monthNumber = 3, _daysInMonth = 31},
                new Month(){_monthNumber = 4, _daysInMonth = 30},
                new Month(){_monthNumber = 5, _daysInMonth = 31},
                new Month(){_monthNumber = 6, _daysInMonth = 30},
                new Month(){_monthNumber = 7, _daysInMonth = 31},
                new Month(){_monthNumber = 8, _daysInMonth = 31},
                new Month(){_monthNumber = 9, _daysInMonth = 30},
                new Month(){_monthNumber = 10, _daysInMonth = 31},
                new Month(){_monthNumber = 11, _daysInMonth = 30},
                new Month(){_monthNumber = 12, _daysInMonth = 31}
            };
        }
    }
}