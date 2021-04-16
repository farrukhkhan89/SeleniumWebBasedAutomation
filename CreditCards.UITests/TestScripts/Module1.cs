using CreditCards.UITests.BaseClass;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCards.UITests.PageObjects.TestScripts
{
    [TestFixture]
    public class Module1:BaseTest
    {
        [Test]
        public void TestMethod1()
        {
            var searchPage= new SearchPage(driver);
            var resultPage=searchPage.NavigateToResultPage();
            var channelPage = resultPage.NavigateToChannel();
            string actualChannelName = channelPage.GetChannelName();
            string expectedChannelName = "TheTechie AutomationLabs";

            Assert.IsTrue(actualChannelName.Equals(expectedChannelName));
        }
    }
}
