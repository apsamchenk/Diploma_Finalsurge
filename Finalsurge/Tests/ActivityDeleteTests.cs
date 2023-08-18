using BusinessObjects.Pages;
using BusinessObjects;
using NUnit.Framework;
using Core;
using Allure.Commons;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using BusinessObjects.Steps;

namespace Finalsurge.Tests
{
    public class ActivityDeleteTests : BaseTest
    {
        [Test]
        [AllureDescription("Delete existing activity with confirm")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke")]
        [AllureSuite("Activity delete tests")]
        [AllureTms("TMS-9")]
        [AllureIssue("Jira-6")]
        public void DeleteActivity()
        {
            var user = UserBuilder.GetStandartUser();

            UISteps.GoToCalendar(user).
                QuickAddByCellMenu("20", "8", "2023").
                FillActivityFields("Bike", "New activity", "New bike activity");

            Assert.IsNotNull(new CalendarPage().FindActivity("20", "8", "2023", "Bike"));

            new CalendarPage().
                DeleteActivity("20", "8", "2023", "Bike").
                ConfirmDelete();

            Thread.Sleep(1000);
            Assert.Throws<NoSuchElementException>(() => new CalendarPage().FindActivity("20", "8", "2023", "Bike"));
        }

        [Test]
        [AllureDescription("Cancel activity removal")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTag("Smoke")]
        [AllureSuite("Activity delete tests")]
        [AllureTms("TMS-10")]
        [AllureIssue("Jira-6")]
        public void CancelDeleteActivity()
        {
            var user = UserBuilder.GetStandartUser();

            UISteps.GoToCalendar(user).
                QuickAddByCellMenu("25", "8", "2023").
                FillActivityFields("Walk", "New activity", "New walk activity");

            Assert.IsNotNull(new CalendarPage().FindActivity("25", "8", "2023", "Walk"));

            new CalendarPage().
                DeleteActivity("25", "8", "2023", "Walk").
                CancelDelete();

            Assert.IsNotNull(new CalendarPage().FindActivity("25", "8", "2023", "Walk"));
        }
    }
}
