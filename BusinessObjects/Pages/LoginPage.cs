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
        private Input userEmailInput = new("login_name");
        private Input userPasswordInput = new("login_password");
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
        public CalendarPage OpenCalendarPage()
        {
            logger.Info("Navigate to Calendar");
            new Button(By.XPath("//*[@href='Calendar.cshtml'][@class='ptip_s']")).GetElement().Click();
            return new CalendarPage();
        }

        [AllureStep]
        public CaloricCalculatorFrame OpenCaloricCalculatorPage()
        {
            logger.Info("Navigate to daily caloric needs Calculator");
            new Button(By.XPath("//*[@data-reveal-id='OtherCalc']")).GetElement().Click();
            return new CaloricCalculatorFrame();
        }

        [AllureStep]
        public string GetMessage()
        {
            var mes = message.GetElement().Text;
            logger.Info($"Alert message: {mes}");
            return mes;
        }

        [AllureStep]
        public void LogOut()
        {
            logger.Info("Logout");
            new Button(By.XPath("//*[@href='logout.cshtml']")).GetElement().Click();
        }
    }
}
