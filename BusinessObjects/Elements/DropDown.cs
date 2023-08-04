using Core;
using OpenQA.Selenium;

namespace BusinessObjects.Elements
{
    public class DropDown : BaseElement
    {
        public DropDown(By locator) : base(locator)
        {
        }

        public DropDown(string day, string month, string year) : base($"//td[@data-day='{day}'][@data-month='{month}'][@data-year='{year}']//div[@class='calendar-add dropdown']")
        {
        }

        public void Select(string day, string option)
        {
            Browser.Instance.MoveToElement(WebDriver.FindElement(locator));
            WebDriver.FindElement(locator).Click();
            WebDriver.FindElement(By.XPath($"//*[@class='{option}'][@data-day='{day}']")).Click();
        }
    }
}
