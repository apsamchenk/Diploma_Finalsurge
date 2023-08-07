using NUnit.Framework;
using BusinessObjects;
using BusinessObjects.Pages;
using Core;
using BusinessObjects.Enums;
using OpenQA.Selenium;
using Allure.Commons;
using NUnit.Allure.Attributes;

namespace Finalsurge.Tests
{
    public class PaceCalculatorTests : BaseTest
    {
        [Test]
        [AllureDescription("Calculate pace for distance type")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke")]
        [AllureSuite("Pace calculator tests")]
        [AllureTms("TMS-14")]
        [AllureIssue("Jira-8")]
        public void CalculatePaceForDistanceType()
        {
            var user = UserBuilder.GetStandartUser();

            new LoginPage().
                OpenPage().
                TryToLogin(user).
                OpenPaceCalculatorPage().
                FillPaceCalcFieldsWithDistType("2", DistanceType.km, "1", "30","");

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//table//td[contains(text(), '45:00 min/km')]")));
        }

        [Test]
        [AllureDescription("Calculate pace for race distance")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke")]
        [AllureSuite("Pace calculator tests")]
        [AllureTms("TMS-15")]
        [AllureIssue("Jira-8")]
        public void CalculatePaceForRaceDistance()
        {
            var user = UserBuilder.GetStandartUser();

            new LoginPage().
                OpenPage().
                TryToLogin(user).
                OpenPaceCalculatorPage().
                FillPaceCalcFieldsWithRaceDist("Marathon", "4", "0", "30");
            
            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//table//td[contains(text(), '0:34 min/100m')]")));
        }

        [Test]
        [AllureDescription("Check error message")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke")]
        [AllureSuite("Pace calculator tests")]
        [AllureTms("TMS-16")]
        [AllureIssue("Jira-8")]
        public void CheckErrorMessage() 
        {
            var user = UserBuilder.GetStandartUser();

            new LoginPage().
                OpenPage().
                TryToLogin(user).
                OpenPaceCalculatorPage().
                FillPaceCalcFieldsWithDistType("", DistanceType.km, "1", "30", "");

            Assert.That(new PaceCalculatorFrame().GetMessage(), Is.EqualTo("×\r\nPlease fix the following errors:\r\n*Please enter a value for Distance."));
        }
    }
}
