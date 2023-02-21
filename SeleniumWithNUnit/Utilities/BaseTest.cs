using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalAssessmentPt1.Utilities
{
    public class BaseTest
    {

        private readonly string url = "http://sampleapp.tricentis.com/101/";
        public IWebDriver driver;
        public ExtentReportsHelper extent;

        [OneTimeSetUp]
        public void SetUpReport()
        {
            extent = new ExtentReportsHelper();
        }

        [SetUp]
        public void SetUp()
        {
            extent.CreateTest(TestContext.CurrentContext.Test.Name);
            driver = new ChromeDriver();
            extent.SetStepPass("ChromeDriver is launched.");
            driver.Navigate().GoToUrl(url);
            extent.SetStepPass("Navigated to URL: " + url);
            driver.Manage().Window.Maximize();
            extent.SetStepPass("Browser is maximized.");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        public void CloseBrowser()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                switch (status)
                {
                    case TestStatus.Failed:
                        extent.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        extent.AddTestFailureScreenshot(ScreenCaptureAsBase64String(driver));
                        break;
                    case TestStatus.Skipped:
                        extent.SetTestStatusSkipped();
                        break;
                    default:
                        extent.SetTestStatusPass();
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                driver.Quit();
            }
        }

        [OneTimeTearDown]
        public void CloseExtentReport()
        {
            try
            {
                extent.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ScreenCaptureAsBase64String(IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }



    }
}
