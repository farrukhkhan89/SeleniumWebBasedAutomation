using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CreditCards.UITests.BaseClass
{
    public class BaseTest
    {
        public IWebDriver driver;
       
        [SetUp]
        public void Open()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.youtube.com/";
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }

    }
}
