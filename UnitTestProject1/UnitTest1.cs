using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CorrectAnswer()
        {
            var startMas = new TimeSpan[100];
            Assert.AreEqual(2, SF2022User04Lib.Calculations.AvailablePeriods());
        }
    }
}
