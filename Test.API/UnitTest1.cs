using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit;
//using NUnit.Framework;

namespace Testing
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod, Ignore]
        public void TestMethod1()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(NotSupportedException))]
        public void TestMethod3()
        {
            throw new NotSupportedException();
        }

        [TestMethod]
        public void NameOfTest_Senario_ExpectedResult()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
