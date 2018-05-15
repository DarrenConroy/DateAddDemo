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
}