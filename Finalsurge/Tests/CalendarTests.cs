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

            Assert.IsNotNull(new CalendarPage().FindActivity("5", "8", "2023", "Run"));
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

            Assert.IsNotNull(new CalendarPage().FindActivity(DateTime.Today.Day.ToString(), DateTime.Today.Month.ToString(), DateTime.Today.Year.ToString(), "Swim"));
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

            Assert.IsNotNull(new CalendarPage().FindActivity("6", "8", "2023", "Walk"));

            new CalendarPage().MoveActivity("6", "8", "2023", "Walk", "10", "8", "2023");

            Assert.Throws<NoSuchElementException>(() => new CalendarPage().FindActivity("6", "8", "2023", "Walk"));
            Assert.IsNotNull(new CalendarPage().FindActivity("10", "8", "2023", "Walk"));
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

            Assert.IsNotNull(new CalendarPage().FindActivity("12", "8", "2023", "Other"));

            new CalendarPage().CopyExistingActivity("12", "8", "2023", "Other").FillCopyFiels("8/15/2023");

            Assert.IsNotNull(new CalendarPage().FindActivity("12", "8", "2023", "Other"));
            Assert.IsNotNull(new CalendarPage().FindActivity("15", "8", "2023", "Other"));
        }
    }
}