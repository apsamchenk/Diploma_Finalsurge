using BusinessObjects.Elements;
using BusinessObjects.Models;
using Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BusinessObjects.Pages
{
    public class LoginPage
    {
        private Input userEmailInput = new(By.XPath("//input[@name='login_name']"));
        private Input userPasswordInput = new(By.XPath("//input[@name='login_password']"));
        private Button loginButton = new(By.XPath("//button[@type='submit']"));
        private AlertMessage message = new(By.ClassName("alert"));

        private static Logger logger = LogManager.GetCurrentClassLogger();

        [AllureStep]
        public LoginPage OpenPage()
        {
            logger.Info("Navigate to url https://log.finalsurge.com/");
            Browser.Instance.NavigateToUrl("https://log.finalsurge.com/");
            return this;
        }

        [AllureStep]
        public LoginPage TryToLogin(UserModel user)
        {
            logger.Info($"Try to login as {user}");
            userEmailInput.GetElement().SendKeys(user.Email);
            userPasswordInput.GetElement().SendKeys(user.Password);
            loginButton.GetElement().Click();

            return this;
        }

        [AllureStep]
        public string GetMessage()
        {
            logger.Info("Verify error message for incorrect data for login");
            return message.GetElement().Text;
        }

        public CalendarPage OpenCalendarPage()
        {
            logger.Info("Navigate to Calendar");
            new Button(By.XPath("//*[@href='Calendar.cshtml'][@class='ptip_s']")).GetElement().Click();
            return new CalendarPage();
        }
    }
}
