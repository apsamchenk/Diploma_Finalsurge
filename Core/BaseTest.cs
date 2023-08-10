using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Core
{
    [TestFixture]
    [AllureNUnit]
    public class BaseTest
    {
        private AllureLifecycle allure;

        [OneTimeSetUp]
        public void SetUp()
        {
            allure = AllureLifecycle.Instance;
        }

        [TearDown]
        public void TearDown() 
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Browser.Instance.Driver).GetScreenshot();
                byte[] bytes = screenshot.AsByteArray;
                allure.AddAttachment("Screenshot", "image/png", bytes);
            }
            Browser.Instance.CloseBrowser();
        }
    }
}
