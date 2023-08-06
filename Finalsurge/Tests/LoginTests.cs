using NUnit.Framework;
using BusinessObjects;
using BusinessObjects.Pages;
using Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace Finalsurge.Tests
{
    public class LoginTests : BaseTest
    {
        [Test]
        [AllureDescription("Valid login test")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke")]
        [AllureSuite("Authorization tests")]
        [AllureTms("TMS-1")]
        [AllureIssue("Jira-1")]
        public void ValidLoginTest()
        {
            var user = UserBuilder.GetStandartUser();

            new LoginPage().OpenPage().TryToLogin(user);
        }

        [Test]
        [AllureDescription("Invalid login test")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTag("Smoke")]
        [AllureSuite("Authorization tests")]
        [AllureTms("TMS-2")]
        [AllureIssue("Jira-1")]
        public void InvalidLoginTest()
        {
            var user = UserBuilder.GetRandomUser();

            new LoginPage().OpenPage().TryToLogin(user);

            Assert.That(new LoginPage().GetMessage(), Is.EqualTo("Invalid login credentials. Please try again."));
        }

        [Test]
        [AllureDescription("Invalid password test")]
        [AllureOwner("Anna Samchenko")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTag("Smoke")]
        [AllureSuite("Authorization tests")]
        [AllureTms("TMS-3")]
        [AllureIssue("Jira-1")]
        public void InvalidPasswordTest()
        {
            var user = UserBuilder.GetRandomPasswordUser();

            new LoginPage().OpenPage().TryToLogin(user);

            Assert.That(new LoginPage().GetMessage(), Is.EqualTo("Invalid login credentials. Please try again."));
        }
    }
}
