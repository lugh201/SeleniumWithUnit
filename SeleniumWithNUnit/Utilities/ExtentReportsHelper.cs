using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;

namespace FinalAssessmentPt1.Utilities
{
    public class ExtentReportsHelper
    {
        public static ExtentReports Extent { get; set; }
        public static ExtentHtmlReporter Reporter { get; set; }
        public static ExtentTest Test { get; set; }

        public ExtentReportsHelper()
        {
            if (Extent == null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\net6.0", "") + @"Report\";
                
                Extent = new ExtentReports();
                Reporter = new ExtentHtmlReporter(path);
                Reporter.Config.DocumentTitle = "Automated Testing Report";
                Reporter.Config.ReportName = "Extent Report" + DateTime.Now;
                Reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
                Extent.AttachReporter(Reporter);
                Extent.AddSystemInfo("Machine", Environment.MachineName);
                Extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
            }
        }

        public void CreateTest(string testName) => Test = Extent.CreateTest(testName);

        public void Close() => Extent.Flush();


        #region Test Step Status
        public void SetStepPass(string stepDescription) => Test.Log(Status.Pass, stepDescription);

        public void SetStepInfo(string stepDescription) => Test.Log(Status.Info, stepDescription);

        public void SetStepWarning(string stepDescription) => Test.Log(Status.Warning, stepDescription);
        #endregion

        #region Test Status
        public void SetTestStatusPass() => Test.Pass("Test Executed Sucessfully!");

        public void SetTestStatusSkipped() => Test.Skip("Test skipped!");

        public void SetTestStatusFail(string? message = null)
        {
            var printMessage = "<p><b>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }
            Test.Fail(printMessage);
        }
        #endregion

        public void AddTestFailureScreenshot(string base64ScreenCapture)
        {
            Test.AddScreenCaptureFromBase64String(base64ScreenCapture, "Screenshot");
        }            

        public void TakeScreenshot(string screenShotName, IWebDriver driver)
        {
            ITakesScreenshot ts = ((ITakesScreenshot)driver);
            Screenshot screenshot = ts.GetScreenshot();
            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\net6.0", "");
            string path = path1 + @"Report\Screenshots\" + screenShotName + ".png";
            string localpath = new Uri(path).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            Test.Log(Status.Info, MediaEntityBuilder.CreateScreenCaptureFromPath(localpath).Build());
        }

    }
}