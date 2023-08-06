using OpenQA.Selenium;

namespace BusinessObjects.Elements
{
    public class CalendarCell : BaseElement
    {
        public CalendarCell(By locator) : base(locator)
        {
        }

        public CalendarCell(string day, string month, string year) : base($"//td[@data-day='{day}'][@data-month='{month}'][@data-year='{year}']")
        {
        }
    }
}
