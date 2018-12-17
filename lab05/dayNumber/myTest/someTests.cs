using Microsoft.VisualStudio.TestTools.UnitTesting;
using someLib;

namespace myTest
{
    //я закоммитил комментарий, моя гениальность не знает границ
    [TestClass]
    public class someTests
    {
        [TestMethod]
        public void winTest()
        {
            someClass some = new someClass();
            string expected = "Понедельник";
            string actual = some.getDatByWeek(1);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual("Вторник", some.getDatByWeek(2));
        }

        [TestMethod]
        public void failTest()
        {
            someClass some = new someClass();
            Assert.AreEqual("Вторник", some.getDatByWeek(2));
            Assert.AreEqual("Суббота", some.getDatByWeek(3));
        }
        [TestMethod]
        public void test4div2()
        {
            someClass some = new someClass();
            Assert.AreEqual(2, some.div(4, 2));
        }

        [TestMethod]
        public void testINT4div0()
        {
            someClass some = new someClass();
            Assert.AreEqual(0, some.div(4, 0));
        }

        [TestMethod]
        public void testDOUBLE4div0()
        {
            someClass some = new someClass();
            Assert.AreEqual(null, some.div(4.0, 0));
        }
    }
}
