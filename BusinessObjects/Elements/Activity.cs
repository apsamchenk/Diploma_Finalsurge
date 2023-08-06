using Core;
using OpenQA.Selenium;

namespace BusinessObjects.Elements
{
    public class Activity : BaseElement
    {
        public Activity(string day, string month, string year, string value) : base($"//td[@data-day='{day}'][@data-month='{month}'][@data-year='{year}']//*[contains(text(), '{value}')]")
        {
        }

        public void MoveActivity(IWebElement source, IWebElement target)
        {
            Browser.Instance.DragPropElement(source, target);
        }
    }
}
