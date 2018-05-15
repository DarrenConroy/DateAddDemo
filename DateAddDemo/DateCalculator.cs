using System.Diagnostics;

namespace DateAddDemo
{
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
