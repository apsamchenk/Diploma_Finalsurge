using BusinessObjects.Elements;
using BusinessObjects.Enums;
using NLog;
using NUnit.Allure.Attributes;

namespace BusinessObjects.Pages
{
    public class PaceCalculatorFrame
    {
        private Input distance = new("RunDist");
        private Input timeHours = new("TimeHH");
        private Input timeMinutes = new("TimeMM");
        private Input timeSeconds = new("TimeSS");

        private DropDown distType = new("DistType");
        private DropDown raceDist = new("RaceDist");

        private Button calculatePaces = new("Calculate Paces");

        private AlertMessage alertMessage = new();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        [AllureStep]
        public void FillPaceCalcFieldsWithDistType(string dist, DistanceType option, string hours, string min, string sec)
        {
            logger.Info($"Fill pace calculator fields: distance - {dist}, distanceType - {option}, hours - {hours}, min - {min}, sec - {sec}");
            distance.GetElement().SendKeys(dist);
            distType.Select(option.ToString());
            timeHours.GetElement().SendKeys(hours);
            timeMinutes.GetElement().SendKeys(min);
            timeSeconds.GetElement().SendKeys(sec);

            calculatePaces.GetElement().Click();
        }

        [AllureStep]
        public void FillPaceCalcFieldsWithRaceDist(string option, string hours, string min, string sec)
        {
            logger.Info($"Fill pace calculator fields: race distance - {option}, hours - {hours}, min - {min}, sec - {sec}");
            raceDist.Select(option);
            timeHours.GetElement().SendKeys(hours);
            timeMinutes.GetElement().SendKeys(min);
            timeSeconds.GetElement().SendKeys(sec);

            calculatePaces.GetElement().Click();
        }

        [AllureStep]
        public string GetMessage()
        {
            var mes = alertMessage.GetElement().Text;
            logger.Info($"Alert message: {mes}");
            return mes;
        }
    }
}
