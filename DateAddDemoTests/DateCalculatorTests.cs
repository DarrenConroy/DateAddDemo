using System;
using DateAddDemo;
using NUnit.Framework;

namespace DateAddDemoTests
{
    [TestFixture]
    public class DateCalculatorTests
    {
        [Test]
        public void AddDays_RawDateNotNull()
        {
            DateCalculator dateCalculator = new DateCalculator();
            RawDate rawDate = new RawDate() {rawDate = ""};
            RawDate returnedRawDate = dateCalculator.AddDays(rawDate, 0);

            Assert.IsNotNull(returnedRawDate);
        }

        [Test]
        public void AddDays_RawDate_rawDate_IsStringEmpty()
        {
            DateCalculator dateCalculator = new DateCalculator();
            RawDate rawDate = new RawDate() { rawDate = "" };
            RawDate returnedRawDate = dateCalculator.AddDays(rawDate, 0);

            Assert.IsEmpty(returnedRawDate.rawDate);
        }

        [Test]
        public void AddDays_10101972_1_11101972()
        {
            DateCalculator dateCalculator = new DateCalculator();
            RawDate rawDate = new RawDate(){rawDate = "10/10/1972"};
            RawDate result = dateCalculator.AddDays(rawDate, 1);
            Assert.AreEqual(new RawDate(){rawDate = "11/10/1972"}.rawDate, result.rawDate);
        }

        [Test]
        public void AddDays_10101972_21_31101972()
        {
            DateCalculator dateCalculator = new DateCalculator();
            RawDate rawDate = new RawDate() { rawDate = "10/10/1972" };
            RawDate result = dateCalculator.AddDays(rawDate, 21);
            Assert.AreEqual(new RawDate() { rawDate = "31/10/1972" }.rawDate, result.rawDate);
        }

        [Test]
        public void AddDays_10101972_22_01111972()
        {
            DateCalculator dateCalculator = new DateCalculator();
            RawDate rawDate = new RawDate() { rawDate = "10/10/1972" };
            RawDate result = dateCalculator.AddDays(rawDate, 22);
            Assert.AreEqual(new RawDate() { rawDate = "01/11/1972" }.rawDate, result.rawDate);
        }

        [Test]
        public void AddDays_10101972_52_01121972()
        {
            DateCalculator dateCalculator = new DateCalculator();
            RawDate rawDate = new RawDate() { rawDate = "10/10/1972" };
            RawDate result = dateCalculator.AddDays(rawDate, 52);
            Assert.AreEqual(new RawDate() { rawDate = "01/12/1972" }.rawDate, result.rawDate);
        }

        [Test]
        public void AddDays_10101972_365_10101973()
        {
            DateCalculator dateCalculator = new DateCalculator();
            RawDate rawDate = new RawDate() { rawDate = "10/10/1972" };
            RawDate result = dateCalculator.AddDays(rawDate, 365);
            Assert.AreEqual(new RawDate() { rawDate = "10/10/1973" }.rawDate, result.rawDate);
        }

        [Test]
        public void AddDays_28022020_1_29022020()
        {
            DateCalculator dateCalculator = new DateCalculator();
            RawDate rawDate = new RawDate() { rawDate = "28/02/2020" };
            RawDate result = dateCalculator.AddDays(rawDate, 1);
            Assert.AreEqual(new RawDate() { rawDate = "29/02/2020" }.rawDate, result.rawDate);
        }

        [Test]
        public void AddDays_28022019_1_01032019()
        {
            DateCalculator dateCalculator = new DateCalculator();
            RawDate rawDate = new RawDate() { rawDate = "28/02/2019" };
            RawDate result = dateCalculator.AddDays(rawDate, 1);
            Assert.AreEqual(new RawDate() { rawDate = "01/03/2019" }.rawDate, result.rawDate);
        }

        [Test]
        public void AddDays_28022020_1460_27022024()
        {
            DateCalculator dateCalculator = new DateCalculator();
            RawDate rawDate = new RawDate() { rawDate = "28/02/2020" };
            RawDate result = dateCalculator.AddDays(rawDate, 1460);
            Assert.AreEqual(new RawDate() { rawDate = "27/02/2024" }.rawDate, result.rawDate);
        }

        [Test]
        public void AddDays_28022020_1461_28022024()
        {
            DateCalculator dateCalculator = new DateCalculator();
            RawDate rawDate = new RawDate() { rawDate = "28/02/2020" };
            RawDate result = dateCalculator.AddDays(rawDate, 1461);
            Assert.AreEqual(new RawDate() { rawDate = "28/02/2024" }.rawDate, result.rawDate);
        }

        [Test]
        public void AddDays_28022020_10000_16072047()
        {
            DateCalculator dateCalculator = new DateCalculator();
            RawDate rawDate = new RawDate() { rawDate = "28/02/2020" };
            RawDate result = dateCalculator.AddDays(rawDate, 10000);
            Assert.AreEqual(new RawDate() { rawDate = "16/07/2047" }.rawDate, result.rawDate);
        }

        [Test]
        public void AddDays_28022020_2920_26022028()
        {
            DateCalculator dateCalculator = new DateCalculator();
            RawDate rawDate = new RawDate() { rawDate = "28/02/2020" };
            RawDate result = dateCalculator.AddDays(rawDate, 2920);
            Assert.AreEqual(new RawDate() { rawDate = "26/02/2028" }.rawDate, result.rawDate);
        }

        [Test]
        public void AddDays_10101972_Minus1_RawDateNull()
        {
            DateCalculator dateCalculator = new DateCalculator();
            RawDate rawDate = new RawDate() { rawDate = "10/10/1972" };
            RawDate result = dateCalculator.AddDays(rawDate, -1);
            Assert.IsNull(result.rawDate);
        }
    }
}
