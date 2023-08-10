using NUnit.Framework;
using BusinessObjects;
using BusinessObjects.Pages;
using Core;
using Allure.Commons;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using BusinessObjects.Steps;

namespace Finalsurge.Tests
{
    public class CalendarTests : BaseTest
    {
        [Test]
        [AllureDescription("Quick add new activity by calendar cell")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke")]
        [AllureSuite("Calendar tests")]
        [AllureTms("TMS-5")]
        [AllureIssue("Jira-2")]
        public void QuickAddByCalendarCell()
        {
            var user = UserBuilder.GetStandartUser();

            UISteps.GoToCalendar(user).
                QuickAddByCellMenu("5", "8", "2023").
                FillActivityFields("Run", "Run activity", "New run activity");

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//td[@data-day='5'][@data-month='8'][@data-year='2023']//*[contains(text(), 'Run')]")));
        }

        [Test]
        [AllureDescription("Quick add new activity by button")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke")]
        [AllureSuite("Calendar tests")]
        [AllureTms("TMS-6")]
        [AllureIssue("Jira-3")]
        public void QuickAddByButton()
        {
            var user = UserBuilder.GetStandartUser();

            UISteps.GoToCalendar(user).
                QuickAddByButton().
                FillActivityFields("Swim", "Swim activity", "New swim activity");

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath($"//td[@data-day='{DateTime.Today.Day}'][@data-month='{DateTime.Today.Month}'][@data-year='{DateTime.Today.Year}']//*[contains(text(), 'Swim')]")));
        }

        [Test]
        [AllureDescription("Move existing activity to another cell")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke")]
        [AllureSuite("Calendar tests")]
        [AllureTms("TMS-7")]
        [AllureIssue("Jira-4")]
        public void MoveActivityToAnotherCell()
        {
            var user = UserBuilder.GetStandartUser();

            UISteps.GoToCalendar(user).
                QuickAddByCellMenu("6", "8", "2023").
                FillActivityFields("Walk", "Walk activity", "New walk activity");
            
            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//td[@data-day='6'][@data-month='8'][@data-year='2023']//*[contains(text(), 'Walk')]")));

            new CalendarPage().MoveActivity("6", "8", "2023", "Walk", "10", "8", "2023");

            Assert.Throws<NoSuchElementException>(() => Browser.Instance.Driver.FindElement(By.XPath("//td[@data-day='6'][@data-month='8'][@data-year='2023']//*[contains(text(), 'Walk')]")));
            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//td[@data-day='10'][@data-month='8'][@data-year='2023']//*[contains(text(), 'Walk')]")));
        }

        [Test]
        [AllureDescription("Copy existing activity to another cell")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke")]
        [AllureSuite("Calendar tests")]
        [AllureTms("TMS-8")]
        [AllureIssue("Jira-5")]
        public void CopyActivityToAnotherCell()
        {
            var user = UserBuilder.GetStandartUser();

            UISteps.GoToCalendar(user).
                QuickAddByCellMenu("12", "8", "2023").
                FillActivityFields("Other", "Other activity", "New other activity");

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//td[@data-day='12'][@data-month='8'][@data-year='2023']//*[contains(text(), 'Other')]")));

            new CalendarPage().CopyExistingActivity("12", "8", "2023", "Other").FillCopyFiels("8/15/2023");

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//td[@data-day='12'][@data-month='8'][@data-year='2023']//*[contains(text(), 'Other')]")));
            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//td[@data-day='15'][@data-month='8'][@data-year='2023']//*[contains(text(), 'Other')]")));
        }
    }
}
