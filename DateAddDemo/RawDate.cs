using System.Text.RegularExpressions;

namespace DateAddDemo
{
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
}