using Microsoft.VisualStudio.TestTools.UnitTesting;
using someLib;

namespace myTest
{
    [TestClass]
    public class dayNumberTests
    {
        [TestMethod]
        public void winTest()
        {
            DayNumber some = new DayNumber();
            string expected = "Понедельник";
            string actual = some.getDatByWeek(1);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual("Вторник", some.getDatByWeek(2));
        }

        [TestMethod]
        public void failTest()
        {
            DayNumber some = new DayNumber();
            Assert.AreEqual("Вторник", some.getDatByWeek(2));
            Assert.AreEqual("Суббота", some.getDatByWeek(3));
        }
    }
}
