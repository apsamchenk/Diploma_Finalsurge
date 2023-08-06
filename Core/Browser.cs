using OpenQA.Selenium;
using Core.Configuration;
using OpenQA.Selenium.Interactions;

namespace Core
{
    public class Browser
    {
        private static readonly ThreadLocal<Browser> BrowserInstances = new();
        public static Browser Instance => GetBrowser();
        private IWebDriver driver;
        public IWebDriver? Driver { get { return driver; } }

        private static Browser GetBrowser()
        {
            return BrowserInstances.Value ?? (BrowserInstances.Value = new Browser());
        }

        private Browser()
        {
            driver = AppConfiguration.Browser.Type.ToLower() switch
            {
                "chrome" => DriverFactory.GetChromeDriver(),
                "firefox" => DriverFactory.GetFirefoxDriver(),
                _ => DriverFactory.GetChromeDriver()
            };

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(AppConfiguration.Browser.ImplicityWait);
            driver.Manage().Window.Maximize();
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
            BrowserInstances.Value = null;
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void MoveToElement(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }

        public void DragPropElement(IWebElement source, IWebElement target)
        {
            Actions actions = new Actions(driver);
            actions.DragAndDrop(source, target).Perform();
        }

        public void AcceptAllert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void SwitchToFrame(string id)
        {
            driver.SwitchTo().Frame(id);
        }
    }
}
