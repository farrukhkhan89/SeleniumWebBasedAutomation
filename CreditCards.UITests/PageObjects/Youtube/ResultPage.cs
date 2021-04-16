using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCards.UITests.PageObjects.Youtube
{
    public class ResultPage
    {
        IWebDriver driver;
        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.LinkText, Using = "TheTechie AutomationLabs")]
        public IWebElement ChannelNameLinkText { get; set; }

        public ChannelPage NavigateToChannel()
        {
            ChannelNameLinkText.Click();
            return new ChannelPage(driver);
        }

    }
}
