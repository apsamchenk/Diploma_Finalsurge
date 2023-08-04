using NUnit.Framework;
using BusinessObjects;
using BusinessObjects.Pages;

namespace Finalsurge.Tests
{
    public class CalendarTests
    {
        [Test]

        //эксперимент

        public void Exp()
        {
            var user = UserBuilder.GetStandartUser();

            new LoginPage().OpenPage().Login(user);
            new CalendarPage().OpenPage();
        }
    }
}
