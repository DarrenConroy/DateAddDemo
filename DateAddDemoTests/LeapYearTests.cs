using System;
using DateAddDemo;
using NUnit.Framework;

namespace DateAddDemoTests
{
    [TestFixture]
    public class LeapYearTests
    {
        [TestCase(2015)]
        [TestCase(2017)]
        [TestCase(2018)]
        [TestCase(2019)]
        public void LeapYear_False(int year)
        {
            bool isLeapYear = LeapYear.IsLeapYear(year);
            Assert.IsFalse(isLeapYear);
        }

        [TestCase(2000)]
        [TestCase(2016)]
        [TestCase(2020)]
        [TestCase(2024)]
        [TestCase(2028)]
        [TestCase(2032)]
        public void LeapYear_True(int year)
        {
            bool isLeapYear = LeapYear.IsLeapYear(year);
            Assert.IsTrue(isLeapYear);
        }

    }
}
