using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using someLib;

namespace myTest
{
    [TestClass]
    class divTests
    {
        [TestMethod]
        public void test4div2()
        {
            Div div = new Div();
            Assert.AreEqual(2, div.div(4, 2));
        }

        [TestMethod]
        public void testINT4div0()
        {
            Div div = new Div();
            Assert.AreEqual(0, div.div(4, 0));
        }

        [TestMethod]
        public void testDOUBLE4div0()
        {
            Div div = new Div();
            Assert.AreEqual(null, div.div(4.0, 0));
        }
    }
}
