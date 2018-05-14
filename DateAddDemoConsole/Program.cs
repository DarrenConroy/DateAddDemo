using System;
using DateAddDemo;

namespace DateAddDemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            RawDate rawDate = new RawDate();

            while (true)
            {
                Console.WriteLine("--> Please enter a date with the format DD/MM/YYYY");

                string date = Console.ReadLine();

                bool isValidDate = rawDate.IsDateValid(date);

                if (isValidDate)
                {
                    Console.WriteLine("You entered the date: " + date);
                    Console.WriteLine();

                    Console.WriteLine("--> Please enter the amount of days to add");

                    string daysToAdd = Console.ReadLine();

                    int i;

                    if (int.TryParse(daysToAdd, out i))
                    {
                        if (i < 1)
                        {
                            Console.WriteLine("XXX INVALID NUMBER OF DAYS XXX");
                            continue;
                        }

                        rawDate = new RawDate() { rawDate = date };

                        DateCalculator dateCalculator = new DateCalculator();
                        RawDate result = dateCalculator.AddDays(rawDate, int.Parse(daysToAdd));

                        Console.WriteLine("New Date: " + result.rawDate);
                        
                    }
                    else
                    {
                        Console.WriteLine("XXX INVALID NUMBER OF DAYS XXX");
                    }
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("XXX INVALID DATE XXX");

                Console.WriteLine("----------------------");
                Console.WriteLine();
            }
        }
    }
}
