using OpenQA.Selenium;

namespace BusinessObjects.Elements
{
    internal class RadioButton : BaseElement
    {
        public RadioButton(By locator) : base(locator)
        {
        }

        public RadioButton(string id, string name) : base($"//*[@id='{id}'][@name='{name}']")
        {
        }
    }
}
