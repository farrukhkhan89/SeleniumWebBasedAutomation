using NUnit.Framework;
using SeleniumTask.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTask.PageObjects.TestScripts
{
    [TestFixture]
    public class Module1:BaseTest
    {
        [Test]
        public void TestMethod1()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
