using Microsoft.VisualStudio.TestTools.UnitTesting;
using someLib;

namespace myTest
{
    [TestClass]
    public class sumTests
    {
        [TestMethod]
        public void sum2plus2Test()
        {
            Sum sum = new Sum();
            Assert.AreEqual(4, sum.sum(2, 2));
        }

        [TestMethod]
        public void sum3plus2Test()
        {
            Sum sum = new Sum();
            Assert.AreEqual(4, sum.sum(3, 2));
        }
    }
}
