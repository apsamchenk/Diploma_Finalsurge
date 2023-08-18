using OpenQA.Selenium;

namespace BusinessObjects.Elements
{
    public class TableElement : BaseElement
    {
        public TableElement(By locator) : base(locator)
        {
        }

        public TableElement(string value) : base($"//table//td[contains(text(), '{value}')]")
        {
        }
    }
}
