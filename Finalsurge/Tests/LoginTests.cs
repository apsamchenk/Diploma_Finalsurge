using NUnit.Framework;
using BusinessObjects;
using BusinessObjects.Pages;
using Core;


namespace Finalsurge.Tests
{
    public class LoginTests
    {
        [Test]

        public void InvalidLoginTest()
        {
            var user = UserBuilder.GetRandomUser();

            new LoginPage().OpenPage().Login(user);

            Assert.That(new LoginPage().GetMessage(), Is.EqualTo("Invalid login credentials. Please try again."));

            Browser.Instance.CloseBrowser();
        }

        [Test]

        public void LoginTest()
        {
            var user = UserBuilder.GetStandartUser();

            new LoginPage().OpenPage().Login(user);

            Browser.Instance.CloseBrowser();
        }

        [Test]

        public void InvalidPasswordTest()
        {
            var user = UserBuilder.GetRandomPasswordUser();

            new LoginPage().OpenPage().Login(user);

            Assert.That(new LoginPage().GetMessage(), Is.EqualTo("Invalid login credentials. Please try again."));

            Browser.Instance.CloseBrowser();
        }
    }
}
