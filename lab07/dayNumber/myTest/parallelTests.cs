using Microsoft.VisualStudio.TestTools.UnitTesting;
using someLib;

namespace myTest
{
    [TestClass]
    public class parallelTests
    {
        [TestMethod]
        public void parallelTest()
        {
            classEvenNumber.ParallelFor();
        }

        [TestMethod]
        public void notParallelTest()
        {
            classEvenNumber.notParallelFor();
        }

        [TestMethod]
        public void ParallelForEachTest()
        {
            classEvenNumber.ParallelForEach();
        }
    }
}
