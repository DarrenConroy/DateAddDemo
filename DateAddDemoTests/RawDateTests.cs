using System;
using DateAddDemo;
using NUnit.Framework;

namespace DateAddDemoTests
{
    [TestFixture]
    public class RawDateTests
    {
        [Test]
        public void IsDateValid_EmptyStringDate_False()
        {
            RawDate rawDate = new RawDate();
            bool isDateValue = rawDate.IsDateValid("");

            Assert.IsFalse(isDateValue);
        }

        [Test]
        public void IsDateValid_RealDate_True()
        {
            RawDate rawDate = new RawDate();
            bool isDateValue = rawDate.IsDateValid("01/01/2001");

            Assert.IsTrue(isDateValue);
        }

        [TestCase("01/01/200")]
        [TestCase("01/01/20")]
        [TestCase("01/01/2")]
        [TestCase("01/01/")]
        [TestCase("01/01")]
        [TestCase("01/0")]
        [TestCase("01/")]
        [TestCase("01/")]
        [TestCase("01")]
        [TestCase("0")]
        [TestCase("//")]
        [TestCase("")]
        [TestCase(null)]
        public void IsDateValid_BadDate_False(string date)
        {
            RawDate rawDate = new RawDate();
            bool isDateValue = rawDate.IsDateValid(date);

            Assert.IsFalse(isDateValue);
        }

        [TestCase("AB/CD/EFGH")]
        [TestCase("99/99/EFGH")]
        public void IsDateValid_WithText_False(string date)
        {
            RawDate rawDate = new RawDate();
            bool isDateValue = rawDate.IsDateValid(date);

            Assert.IsFalse(isDateValue);
        }

        [TestCase("01/01/2001")]
        [TestCase("01/01/9999")]
        [TestCase("29/02/2020")]
        public void IsDateValid_WithNumbers_True(string date)
        {
            RawDate rawDate = new RawDate();
            bool isDateValue = rawDate.IsDateValid(date);

            Assert.IsTrue(isDateValue);
        }

        [TestCase("32/01/2001")]
        [TestCase("32/00/2001")]
        [TestCase("01/13/2001")]
        [TestCase("00/12/2001")]
        public void IsDateValid_WithNumbers_False(string date)
        {
            RawDate rawDate = new RawDate();
            bool isDateValue = rawDate.IsDateValid(date);

            Assert.IsFalse(isDateValue);
        }

        [TestCase("31/02/2001")]
        [TestCase("30/02/2001")]
        [TestCase("29/02/2001")]
        [TestCase("31/04/2001")]
        [TestCase("31/06/2001")]
        [TestCase("31/09/2001")]
        [TestCase("31/11/2001")]
        [TestCase("29/02/2019")]
        public void IsDateValid_IncorrectDays_False(string date)
        {
            RawDate rawDate = new RawDate();
            bool isDateValue = rawDate.IsDateValid(date);

            Assert.IsFalse(isDateValue);
        }

        [TestCase("28/02/2001")]
        [TestCase("30/04/2001")]
        [TestCase("30/06/2001")]
        [TestCase("30/09/2001")]
        [TestCase("30/11/2001")]
        public void IsDateValid_CorrectDays_False(string date)
        {
            RawDate rawDate = new RawDate();
            bool isDateValue = rawDate.IsDateValid(date);

            Assert.IsTrue(isDateValue);
        }
    }
}
