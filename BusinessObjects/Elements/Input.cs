using OpenQA.Selenium;

namespace BusinessObjects.Elements
{
    public class Input : BaseElement
    {
        public Input(By locator) : base(locator)
        {
        }

        public Input(string name) : base($"//label[text()='{name}']/following::div/input")
        {
        }

        public void Select(string option)
        {
            WebDriver.FindElement(locator).Click();
            WebDriver.FindElement(By.XPath($"//*[@title='{option}']")).Click();
        }
    }
}
