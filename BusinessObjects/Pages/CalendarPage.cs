using BusinessObjects.Elements;
using Core;

namespace BusinessObjects.Pages
{
    public class CalendarPage
    {
        
        private DropDown plusButton = new("5", "8", "2023");

        public CalendarPage OpenPage()
        {
            Browser.Instance.NavigateToUrl("https://log.finalsurge.com/Calendar.cshtml#");

            plusButton.Select("5", "quick-add");
            return this;
        }
    }
}
