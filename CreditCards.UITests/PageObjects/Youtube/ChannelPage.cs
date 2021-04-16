using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCards.UITests.PageObjects.Youtube
{
    public class ChannelPage
    {
        IWebDriver driver;
        public ChannelPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "yt-formatted-string#text.style-scope.ytd-channel-name")]
        public IWebElement ChannelName { get; set; }
        public string GetChannelName()
        {
            return ChannelName.Text;
        }
    }
}
