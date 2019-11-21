using Example.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.Impl.UnitTest
{
    [TestClass]
    public class CalcTest
    {
        private ICalc instance;
        [TestInitialize]
        public void Init()
        {
            this.instance = new Calc();
        }

        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(3, instance.Add(1, 2));
        }

        [TestMethod]
        public void TestSub()
        {
            Assert.AreEqual(1, instance.Sub(2, 1));
        }
        [TestMethod]
        public void TestMutil()
        {
            Assert.AreEqual(2, instance.Mutil(1, 2));
        }
        [TestMethod]
        public void TestDiv()
        {
            Assert.AreEqual(2, instance.Div(10, 5));
        }
    }
}
