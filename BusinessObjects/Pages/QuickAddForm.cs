using BusinessObjects.Elements;
using NLog;
using NUnit.Allure.Attributes;

namespace BusinessObjects.Pages
{
    public class QuickAddForm
    {
        private Input workOutDate = new("QuickAdd", "WorkoutDate");
        private Input activityType = new("QuickAdd", "ActivityType");
        private Input workOutName = new("QuickAdd", "Name");
        private Input workOutDescription = new("QuickAdd", "Desc");
        
        private Button addWorkout = new("Add Workout");
        private Button copyWorkout = new("Copy Workout");

        private static Logger logger = LogManager.GetCurrentClassLogger();

        [AllureStep]
        public void FillActivityFields(string type, string name, string desc)
        {
            logger.Info($"Fill fields for quick add: Activity type - {type}, Workout Name - {name}, Workout description - {desc}");
            activityType.GetElement().SendKeys(type);
            workOutName.GetElement().SendKeys(name);
            workOutDescription.GetElement().SendKeys(desc);
            addWorkout.GetElement().Click();
        }

        [AllureStep]
        public void FillCopyFiels(string date)
        {
            logger.Info($"Fill date for activity copy - {date}");
            workOutDate.GetElement().SendKeys(date);
            copyWorkout.GetElement().Click();
        }
    }
}
