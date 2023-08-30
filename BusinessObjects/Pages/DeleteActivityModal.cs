using BusinessObjects.Elements;
using NLog;
using OpenQA.Selenium;
using NUnit.Allure.Attributes;

namespace BusinessObjects.Pages
{
    public class DeleteActivityModal
    {
        private Button confirmDeleteButton = new(By.XPath("//*[@class='bootbox modal fade in']//*[text()='OK']"));
        private Button cancelDeleteButton = new(By.XPath("//*[@class='bootbox modal fade in']//*[text()='Cancel']"));

        private static Logger logger = LogManager.GetCurrentClassLogger();

        [AllureStep]
        public void ConfirmDelete()
        {
            logger.Info("Confirm activity delete");
            Thread.Sleep(2000);
            confirmDeleteButton.GetElement().Click();
        }

        [AllureStep]
        public void CancelDelete() 
        {
            logger.Info("Cancel activity delete");
            Thread.Sleep(2000);
            cancelDeleteButton.GetElement().Click();
        }
    }
}
