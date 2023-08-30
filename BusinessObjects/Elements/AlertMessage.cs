using OpenQA.Selenium;

namespace BusinessObjects.Elements
{
    public class AlertMessage : BaseElement
    {
        public AlertMessage(By locator) : base(locator)
        {
        }

        public AlertMessage() : base($"//*[contains(@class, 'alert')]")
        {
        }
    }
}
