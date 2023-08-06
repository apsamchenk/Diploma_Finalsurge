using BusinessObjects.Elements;
using NLog;
using OpenQA.Selenium;
using NUnit.Allure.Attributes;

namespace BusinessObjects.Pages
{
    public class CalendarPage
    {
        private DropDown cellActions;
        private DropDown activityActions;

        private Button quickAddButton = new(By.XPath("//*[@id='QuickAddToggle']"));

        private Activity existingActivity;

        private CalendarCell targetCalendarCell;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        [AllureStep]
        public QuickAddForm QuickAddByCellMenu(string day, string month, string year)
        {
            logger.Info($"New activity quick add by cell menu to date {day}/{month}/{year}");
            cellActions = new(day, month, year);
            cellActions.SelectOptionFromCalendarCellMenu(day, "quick-add");
            return new QuickAddForm();
        }

        [AllureStep]
        public QuickAddForm QuickAddByButton()
        {
            logger.Info("New activity quick add by button");
            quickAddButton.GetElement().Click();
            return new QuickAddForm();
        }

        [AllureStep]
        public void MoveActivity(string day, string month, string year, string title, string targetDay, string targetMonth, string targetYear)
        {
            logger.Info($"Move activity {title} from date {day}/{month}/{year} to date {targetDay}/{targetMonth}/{targetYear}");
            existingActivity = new(day, month, year, title);
            targetCalendarCell = new(targetDay, targetMonth, targetYear);
            existingActivity.MoveActivity(existingActivity.GetElement(), targetCalendarCell.GetElement());
        }

        [AllureStep]
        public QuickAddForm CopyExistingActivity(string day, string month, string year, string title)
        {
            logger.Info($"Copy activity {title} from date {day}/{month}/{year}");
            existingActivity = new(day, month, year, title);
            activityActions = new(day, month, year, title);
            existingActivity.GetElement().Click();
            activityActions.SelectOptionFromActivityMenu("quick-copy");
            return new QuickAddForm();
        }

        [AllureStep]
        public DeleteActivityModal DeleteActivity(string day, string month, string year, string title)
        {
            logger.Info($"Delete activity {title} from date {day}/{month}/{year}");
            existingActivity = new(day, month, year, title);
            activityActions = new(day, month, year, title);
            existingActivity.GetElement().Click();
            activityActions.SelectOptionFromActivityMenu("quick-delete");
            return new DeleteActivityModal();
        }
    }
}
