using BusinessObjects.Elements;
using Core;
using BusinessObjects.Enums;
using NLog;
using NUnit.Allure.Attributes;

namespace BusinessObjects.Pages
{
    public class CaloricCalculatorFrame
    {
        private Input weightInput = new("Weight");
        private Input heightInput = new("HeightInchCent");
        private Input ageInput = new("Age");
        private Input distanceInput = new("RunDist");

        private RadioButton weightTypeKg = new("optionsRadios4", "WeightType");
        private RadioButton weightTypeLbs = new("optionsRadios3", "WeightType");
        private RadioButton heightTypeCm = new("optionsRadios4", "HeightType");
        private RadioButton heightTypeInches = new("optionsRadios3", "HeightType");
        private RadioButton maleGender = new("optionsRadios5", "Gender");
        private RadioButton femaleGender = new("optionsRadios6", "Gender");
        private RadioButton distTypeMiles = new("optionsRadios7", "DistType");
        private RadioButton distTypeKm = new("optionsRadios8", "DistType");

        private Button calculateButton = new("Calculate Caloric Needs");

        private AlertMessage alertMessage = new();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        [AllureStep]
        public void FillCaloricCalcFields(string weight, string height, string age, string dist, WeightType weightType, HeightType heightType, GenderType gender, DistanceType distType)
        {
            logger.Info($"Fill caloric calculator fields: weight - {weight}, height - {height}, age - {age}, weightType - {weightType}, heightType - {heightType}, gender - {gender}, distType - {distType}");

            Browser.Instance.SwitchToFrame("OtherCalciFrame");

            weightInput.GetElement().SendKeys(weight);
            heightInput.GetElement().SendKeys(height);
            ageInput.GetElement().SendKeys(age);
            distanceInput.GetElement().SendKeys(dist);

            if (weightType == WeightType.kg)
                weightTypeKg.GetElement().Click();
            else
                weightTypeLbs.GetElement().Click();

            if (heightType == HeightType.centimeters)
                heightTypeCm.GetElement().Click();
            else 
                heightTypeInches.GetElement().Click();

            if (gender == GenderType.female)
                femaleGender.GetElement().Click();
            else
                maleGender.GetElement().Click();

            if (distType == DistanceType.km)
                distTypeKm.GetElement().Click();
            else
                distTypeMiles.GetElement().Click();

            calculateButton.GetElement().Click();
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
