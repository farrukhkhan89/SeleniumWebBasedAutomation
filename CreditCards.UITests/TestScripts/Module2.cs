using CreditCards.UITests.BaseClass;
using CreditCards.UITests.PageObjects.Demoga;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCards.UITests.TestScripts
{
    [TestFixture]
    public class Module2: BaseTest2
    {
        [Test]
        public void Check_SubmitFormWithOnlyRequiredFields()
        {
            var homePage = new HomePage(driver);
            var formsPage = homePage.NavigateToForms();
            var practiceForms = formsPage.ClickToToPracticeForms();

            practiceForms.FillFormOnlyRequiredAndSubmit();

            Assert.AreEqual("Thanks for submitting the form", practiceForms.GetSuccessMessage());
        }

        [Test]
        public void Check_SubmitEmptyFormsAndValidate()
        {
            var homePage = new HomePage(driver);
            var formsPage = homePage.NavigateToForms();
            var practiceForms = formsPage.ClickToToPracticeForms();

            Assert.True(!string.IsNullOrEmpty(practiceForms.FirstName.GetAttribute("value")), "first name is required field");
            Assert.True(!string.IsNullOrEmpty(practiceForms.LastName.GetAttribute("value")), "last name is required field");
            Assert.True(!practiceForms.Gender.Selected, "Gender is required field");

            practiceForms.ValidateAndSubmitEmptyForm();

            //Assert.AreEqual("Thanks for submitting the form", practiceForms.GetSuccessMessage());
        }
    }
}
