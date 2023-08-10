using NUnit.Framework;
using BusinessObjects;
using BusinessObjects.Pages;
using Core;
using BusinessObjects.Enums;
using OpenQA.Selenium;
using Allure.Commons;
using NUnit.Allure.Attributes;
using BusinessObjects.Steps;

namespace Finalsurge.Tests
{
    public class CaloricCalculatorTests : BaseTest
    {
        [Test]
        [AllureDescription("Calculate calories for female")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke")]
        [AllureSuite("Caloric calculator tests")]
        [AllureTms("TMS-11")]
        [AllureIssue("Jira-7")]
        public void CalculateCaloriesForFemale()
        {
            var user = UserBuilder.GetStandartUser();

            UISteps.GoToCaloricCalculator(user).
                FillCaloricCalcFields("65", "170", "30", "5", WeightType.kg, HeightType.centimeters, GenderType.female, DistanceType.km);

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//table//td[contains(text(), '2,009 kCal')]")));
        }

        [Test]
        [AllureDescription("Calculate calories for male")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke")]
        [AllureSuite("Caloric calculator tests")]
        [AllureTms("TMS-12")]
        [AllureIssue("Jira-7")]
        public void CalculateCaloriesForMale()
        {
            var user = UserBuilder.GetStandartUser();

            UISteps.GoToCaloricCalculator(user).
                FillCaloricCalcFields("65", "170", "30", "5", WeightType.kg, HeightType.centimeters, GenderType.male, DistanceType.km);

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//table//td[contains(text(), '2,208 kCal')]")));
        }

        [Test]
        [AllureDescription("Check error message")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke")]
        [AllureSuite("Caloric calculator tests")]
        [AllureTms("TMS-13")]
        [AllureIssue("Jira-7")]
        public void CheckErrorMessage() 
        {
            var user = UserBuilder.GetStandartUser();

            UISteps.GoToCaloricCalculator(user).
                FillCaloricCalcFields("", "170", "30", "5", WeightType.kg, HeightType.centimeters, GenderType.female, DistanceType.km);

            Assert.That(new CaloricCalculatorFrame().GetMessage(), Is.EqualTo("×\r\nPlease fix the following errors:\r\n*Please enter a value for Weight."));
        }
    }
}
