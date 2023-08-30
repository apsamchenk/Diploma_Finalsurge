using Core;
using OpenQA.Selenium;

namespace BusinessObjects.Elements
{
    public class DropDown : BaseElement
    {
        public DropDown(By locator) : base(locator)
        {
        }
        public DropDown(string name) : base($"//select[@name='{name}']")
        {
        }

        public DropDown(string day, string month, string year) : base($"//td[@data-day='{day}'][@data-month='{month}'][@data-year='{year}']//div[@class='calendar-add dropdown']")
        {
        }

        public DropDown(string day, string month, string year, string title) : base($"//td[@data-day='{day}'][@data-month='{month}'][@data-year='{year}']//*[contains(text(), 'Run')]/ancestor::div/*[@class='dropdown-menu pull-right']")
        { 
        }

        public void Select(string option)
        {
            WebDriver.FindElement(locator).Click();
            WebDriver.FindElement(By.XPath($"//option[@value='{option}']")).Click();
        }

        public void SelectOptionFromCalendarCellMenu(string day, string option)
        {
            Browser.Instance.MoveToElement(WebDriver.FindElement(locator));
            WebDriver.FindElement(locator).Click();
            WebDriver.FindElement(By.XPath($"//*[@class='{option}'][@data-day='{day}']")).Click();
        }

        public void SelectOptionFromActivityMenu(string day, string option)
        {
            WebDriver.FindElement(By.XPath($"//*[@data-day='{day}']//*[@class='{option}']")).Click();
        }
    }
}
