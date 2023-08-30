using OpenQA.Selenium;

namespace BusinessObjects.Elements
{
    public class Input : BaseElement
    {
        public Input(By locator) : base(locator)
        {
        }

        public Input(string name) : base($"//input[@name='{name}']")
        {
        }

        public Input(string activityId, string inputId) : base($"//*[@id='{activityId}']//*[@id='{inputId}']")
        {
        }
    }
}
