using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using NUnit.Framework;

namespace Testing
{
    
    [TestFixture]
    public class UnitTest1
    {
        [Test, Ignore("It will Fail")]
        public void TestMethod1()
        {
            Assert.That(false, Is.True);
        }

        [Test]
        public void TestMethod2()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestMethod3()
        {
            throw new NotSupportedException();
        }

        [Test]
        public void NameOfTest_Senario_ExpectedResult()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
