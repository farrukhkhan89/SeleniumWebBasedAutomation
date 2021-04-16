using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace CreditCards.UITests
{
    public class CreditCardWebAppShould
    {
        const string homeUrl = "https://demoqa.com/";
        const string homeUrlPluralsight = "http://localhost:44108/";
        const string aboutUrlPluralsight = "http://localhost:44108/Home/About/";
        const string pageTitle = "ToolsQA";
        // const string pageTitlePluralsight =""
        const string aboutUrl = "https://demoqa.com/forms/";
        const string formsUrl = "https://demoqa.com/forms/";

        const string practicalForm = "https://demoqa.com/automation-practice-form/";
        const string creditCardAppTitle = "Credit Card Application - Credit Cards";

        const string creditCardApplyUrl = "http://localhost:44108/Apply";

        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeUrl);
                //DemoHelper.Pause(); 
                string pageTitle = driver.Title;

                Assert.Equal(pageTitle, pageTitle);
                Assert.Equal(homeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeUrl);
                // DemoHelper.Pause();
                driver.Navigate().Refresh();
                Assert.Equal(homeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageOnBack()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeUrlPluralsight);
                IWebElement generationToken =
                    driver.FindElement(By.Id("GenerationToken"));

                string initialToken = generationToken.Text;
                // DemoHelper.Pause();

                driver.Navigate().GoToUrl(aboutUrlPluralsight);
                //DemoHelper.Pause();

                driver.Navigate().Back();
                // DemoHelper.Pause();

                //  Assert.Equal(pageTitle, driver.Title);
                Assert.Equal(homeUrlPluralsight, driver.Url);

                string reloadingToken = driver.FindElement(By.Id("GenerationToken")).Text;
                Assert.NotEqual(initialToken, reloadingToken);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageOnForward()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(aboutUrl);
                DemoHelper.Pause();

                driver.Navigate().GoToUrl(homeUrl);
                DemoHelper.Pause();

                driver.Navigate().Back();
                DemoHelper.Pause();

                driver.Navigate().Forward();
                DemoHelper.Pause();

                Assert.Equal(pageTitle, pageTitle);
                Assert.Equal(homeUrl, driver.Url);

            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageThenForms()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeUrl);
                // DemoHelper.Pause();

                driver.Navigate().GoToUrl(formsUrl);
                // DemoHelper.Pause();

                IWebElement element = driver.FindElement(By.XPath("//span [contains(text(),'Practice Form')]"));

                //if (element != null)
                //{
                //    string practiceUrl = "https://demoqa.com/automation-practice-form";

                //    driver.Navigate().GoToUrl(practiceUrl);
                //}

                //  IWebElement element = driver.FindElement(By.XPath("html/body/div[2]/div[1]/img"));

                // IList<IWebElement> all = driver.FindElements(By.ClassName("menu-list"));
                // all[1].Click();

                //  all[1].Click();
                DemoHelper.Pause();
                //driver.Navigate().GoToUrl(formsUrl);
                //DemoHelper.Pause();

                //driver.Navigate().GoToUrl(practicalForm);
                //DemoHelper.Pause();

                //driver.Navigate().Forward();
                DemoHelper.Pause();

                Assert.Equal(pageTitle, pageTitle);
                Assert.Equal(homeUrl, driver.Url);

            }


        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void BeInitiatedFromHomePage_NewLowRate()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeUrlPluralsight);
                DemoHelper.Pause();

                IWebElement applyLink = driver.FindElement(By.Name("ApplyLowRate"));
                applyLink.Click();
                DemoHelper.Pause();

                Assert.Equal(creditCardAppTitle, driver.Title);
            }

        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void BeInitiatedFromHomePage_EasyApplication()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeUrlPluralsight);
                DemoHelper.Pause();

                IWebElement carouseNext = driver.FindElement(By.CssSelector("[data-slide='next']"));
                carouseNext.Click();
                DemoHelper.Pause(1000);
                //IWebElement carouseNexts = driver.FindElement(By.ClassName("show"));
                //if(carouseNexts.Text.Contains("Practice Form"))
                //{
                //    driver.Navigate().GoToUrl(practicalForm);
                //}

                IWebElement applyLink = driver.FindElement(By.LinkText("Easy: Apply Now!"));
                applyLink.Click();


                Assert.Equal(creditCardAppTitle, driver.Title);
            }

        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void BeInitiatedFromHomePage_PracticeForm()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(formsUrl);
                DemoHelper.Pause();

                var admi = driver.FindElement(By.XPath("//span [contains(text(),'Practice Form')]"));

                admi.Click();

                IWebElement applyLink = driver.FindElement(By.LinkText("Practice Form"));
                applyLink.Click();
                DemoHelper.Pause();

                Assert.Equal(creditCardAppTitle, driver.Title);
            }

        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void BeInitiatedFromHomePage_CustomerSerivce()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeUrlPluralsight);
                DemoHelper.Pause();

                IWebElement carouseNext = driver.FindElement(By.ClassName("show"));
                carouseNext.Click();
                DemoHelper.Pause(1000);
                //IWebElement carouseNexts = driver.FindElement(By.ClassName("show"));
                //if(carouseNexts.Text.Contains("Practice Form"))
                //{
                //    driver.Navigate().GoToUrl(practicalForm);
                //}

                IWebElement applyLink = driver.FindElement(By.LinkText("Easy: Apply Now!"));
                applyLink.Click();


                Assert.Equal(creditCardAppTitle, driver.Title);
            }

        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void DisplayProductAndRates()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeUrlPluralsight);
                DemoHelper.Pause();

                IWebElement firstTableCell = driver.FindElement(By.TagName("td"));
                string cellValue = firstTableCell.Text;


                Assert.Equal("Easy Credit Card", cellValue);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void BeInitiatedFromHomePage_RandomGreeting()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeUrlPluralsight);
                DemoHelper.Pause();

                IWebElement randomGreetingLinkText =
                    driver.FindElement(By.PartialLinkText("- Apply Now!"));

                randomGreetingLinkText.Click();
                DemoHelper.Pause();

                Assert.Equal(creditCardAppTitle, driver.Title);
                Assert.Equal(creditCardApplyUrl, driver.Url);

            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void BeInitiatedFromHomePage_RandomGreeting_Using_XPath()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(formsUrl);
                DemoHelper.Pause();

                //IWebElement randomGreetingLinkText =
                //    driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div[1]/div/div/div[2]/div"));

                IWebElement a = driver.FindElement(By.XPath("//div[@class='element-list collapse show']//*[name()='svg'][@stroke = 'currentColor']"));

                Actions builder = new Actions(driver);
                builder.Click(a).Build().Perform();


                string ur = driver.Url.Replace("/forms", "");
                driver.Navigate().GoToUrl(ur);


                // a.Click();

                //IList<IWebElement> all = driver.FindElements(By.TagName("svg"));
                // IList<IWebElement> all = driver.FindElements(By.ClassName("menu-list"))


                IWebElement randomGreetingLinkText =
                    driver.FindElement(By.XPath("//*[@id='item-0']/svg/path"));


                randomGreetingLinkText.Click();
                DemoHelper.Pause();

                Assert.Equal(creditCardAppTitle, driver.Title);
                Assert.Equal(creditCardApplyUrl, driver.Url);

            }

        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void BeSubmittedValid()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(formsUrl);
                DemoHelper.Pause();

                //IWebElement randomGreetingLinkText =
                //    driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div[1]/div/div/div[2]/div"));

                IWebElement a = driver.FindElement(By.XPath("//div[@class='element-list collapse show']//*[name()='svg'][@stroke = 'currentColor']"));

                Actions builder = new Actions(driver);
                builder.Click(a).Build().Perform();


                string ur = driver.Url.Replace("/forms", "");
                driver.Navigate().GoToUrl(ur);

                IWebElement firstNameField =
                   driver.FindElement(By.Id("firstName"));
                firstNameField.SendKeys("Farrukh");

                IWebElement lastNameField =
                   driver.FindElement(By.Id("lastName"));
                lastNameField.SendKeys("Khan");

                //userEmail
                driver.FindElement(By.Id("userEmail")).SendKeys("farrukhmask@hotmail.com");


                IWebElement singleRadioButton = driver.FindElement(By.Id("gender-radio-1"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].checked = true;", singleRadioButton);

                //userNumber
                driver.FindElement(By.Id("userNumber")).SendKeys("3132417761");

                //dateOfBirthInput
                IWebElement datePicker = driver.FindElement(By.Id("dateOfBirthInput"));
                //executeScript("document.getElementById('id').value='1988-01-01'");
                ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById('dateOfBirthInput').value='25 Apr 2021'", datePicker);
                //((IJavaScriptExecutor)driver).ExecuteScript("return document.getElementById('dateOfBirthInput').value", singleRadioButton);

                //hobbies-checkbox-1
                IWebElement hobbySports = driver.FindElement(By.Id("hobbies-checkbox-1"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].checked = true;", hobbySports);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void BeSubmittedValid_OnlyRequired()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(formsUrl);
                DemoHelper.Pause();

                //IWebElement randomGreetingLinkText =
                //    driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div[1]/div/div/div[2]/div"));

                IWebElement a = driver.FindElement(By.XPath("//div[@class='element-list collapse show']//*[name()='svg'][@stroke = 'currentColor']"));

                Actions builder = new Actions(driver);
                builder.Click(a).Build().Perform();


                string ur = driver.Url.Replace("/forms", "");
                driver.Navigate().GoToUrl(ur);


                IWebElement firstNameField =
                   driver.FindElement(By.Id("firstName"));
                firstNameField.SendKeys("Farrukh");

                IWebElement lastNameField =
                   driver.FindElement(By.Id("lastName"));
                lastNameField.SendKeys("Khan");

                //userEmail
                // driver.FindElement(By.Id("userEmail")).SendKeys("farrukhmask@hotmail.com");


                IWebElement singleRadioButton = driver.FindElement(By.Id("gender-radio-1"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].checked = true;", singleRadioButton);

                //userNumber
                driver.FindElement(By.Id("userNumber")).SendKeys("3132417761");

                //   driver.FindElement(By.Id("submit")).Click();

                IWebElement submitBtn = driver.FindElement(By.Id("submit"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", submitBtn);

            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void BeSubmittedValid_VerifyFields()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(formsUrl);
                DemoHelper.Pause();

                //IWebElement randomGreetingLinkText =
                //    driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div[1]/div/div/div[2]/div"));

                IWebElement a = driver.FindElement(By.XPath("//div[@class='element-list collapse show']//*[name()='svg'][@stroke = 'currentColor']"));

                Actions builder = new Actions(driver);
                builder.Click(a).Build().Perform();


                string ur = driver.Url.Replace("/forms", "");
                driver.Navigate().GoToUrl(ur);

                IWebElement firstNameField =
                   driver.FindElement(By.Id("firstName"));
                // firstNameField.SendKeys("Farrukh");

                IWebElement lastNameField =
                   driver.FindElement(By.Id("lastName"));



                IWebElement gender =
                    driver.FindElement(By.Name("gender"));
                IWebElement singleRadioButton = driver.FindElement(By.Id("gender-radio-1"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].checked = true;", singleRadioButton);

                Assert.True(!string.IsNullOrEmpty(firstNameField.GetAttribute("value")), "first name is required field");
                Assert.True(!string.IsNullOrEmpty(lastNameField.GetAttribute("value")), "last name is required field");
                Assert.True(!gender.Selected, "Gender is required field");


                //lastNameField.SendKeys("Khan");

                //userEmail
                // driver.FindElement(By.Id("userEmail")).SendKeys("farrukhmask@hotmail.com");


                //IWebElement singleRadioButton = driver.FindElement(By.Id("gender-radio-1"));
                //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].checked = true;", singleRadioButton);

                ////userNumber
                //driver.FindElement(By.Id("userNumber")).SendKeys("3132417761");

                ////   driver.FindElement(By.Id("submit")).Click();

                //IWebElement submitBtn = driver.FindElement(By.Id("submit"));
                //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", submitBtn);

            }
        }

        //[Fact]
        //[Trait("Category", "Smoke")]
        //public void Parse_SimpleValues_Calculated()
        //{
        //    Assert.Equal(25, 25);
        //    Assert.Equal(25, 23);
        //    Assert.Equal(35, 35);
        //    Assert.Equal(25, 28);

        //}
    }
}

