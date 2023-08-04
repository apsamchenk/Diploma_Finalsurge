using BusinessObjects.Elements;
using BusinessObjects.Models;
using Core;
using OpenQA.Selenium;

namespace BusinessObjects.Pages
{
    public class LoginPage
    {
        private Input userEmailInput = new(By.XPath("//input[@name='login_name']"));
        private Input userPasswordInput = new(By.XPath("//input[@name='login_password']"));
        private Button loginButton = new(By.XPath("//button[@type='submit']"));
        private AlertMessage message = new(By.ClassName("alert"));

        public LoginPage OpenPage()
        {
            Browser.Instance.NavigateToUrl("https://log.finalsurge.com/");
            return this;
        }

        public LoginPage Login(UserModel user)
        {
            userEmailInput.GetElement().SendKeys(user.Email);
            userPasswordInput.GetElement().SendKeys(user.Password);
            loginButton.GetElement().Click();

            return this;
        }

        public string GetMessage()
        {
            return message.GetElement().Text;
        }
    }
}
