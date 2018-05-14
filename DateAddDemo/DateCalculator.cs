using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DateAddDemo
{
    public class LeapYear
    {
        public static bool IsLeapYear(int year)
        {
            if (year % 4 == 0)
                return true;

            return false;
        }
    }

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

    public class RawDate
    {
        public string rawDate;

        private int ParseString(string numbers)
        {
            return int.Parse(numbers);
        }

        public bool IsDateValid(string date)
        {
            if (string.IsNullOrEmpty(date))
                return false;

            if (date.Length != 10)
                return false;

            if (Regex.Matches(date, "/").Count != 2)
                return false;

            string numbersWithoutForwardSlashes = date.Replace(@"/", "");

            int i;
            if (!int.TryParse(numbersWithoutForwardSlashes, out i))
                return false;

            string []splitDate = date.Split('/');

            int monthNumber = ParseString(splitDate[1]);

            if (monthNumber > 12 || monthNumber < 1)
                return false;

            int dayNumber = ParseString(splitDate[0]);

            if (dayNumber > 31 || dayNumber < 1)
                return false;

            int year = ParseString(splitDate[2]);

            if (year < 1)
                return false;

            var months = Month.GetMonths();

            var daysInMonth = months.Find(m => m.MonthNumber == monthNumber).DaysInMonth;

            if (monthNumber == 2 && LeapYear.IsLeapYear(year) && daysInMonth < 29)
                daysInMonth++;

            if (dayNumber > daysInMonth)
                return false;

            return true;
        }
    }

    public class DateCalculator
    {
        public RawDate AddDays(RawDate rawDate, int numberOfDaysToAdd)
        {
            if (numberOfDaysToAdd == 0)
                return rawDate;

            if(numberOfDaysToAdd < 0)
                return new RawDate();

            if (!rawDate.IsDateValid(rawDate.rawDate))
                return new RawDate();

            string []splitDate = rawDate.rawDate.Split('/');

            int days = int.Parse(splitDate[0]);
            int month = int.Parse(splitDate[1]);
            int year = int.Parse(splitDate[2]);
            var months = Month.GetMonths();

            days += numberOfDaysToAdd;

            int daysThisMonth = months.Find(m => m.MonthNumber == month).DaysInMonth;

            if (LeapYear.IsLeapYear(year) && month == 2)
            {
                daysThisMonth += 1;
            }

            while (days > daysThisMonth)
            {
                days = days - daysThisMonth;

                if (month == 12)
                {
                    month = 1;
                    year++;
                }
                else
                    month++;

                daysThisMonth = months.Find(m => m.MonthNumber == month).DaysInMonth;

                if (LeapYear.IsLeapYear(year) && month == 2)
                {
                    Debug.WriteLine("leapyear" + year);
                    daysThisMonth += 1;
                }
            }

            return new RawDate(){rawDate = days.ToString("0#") + "/" + month.ToString("0#") + "/" + year.ToString("0000") };
        }
    }
}
