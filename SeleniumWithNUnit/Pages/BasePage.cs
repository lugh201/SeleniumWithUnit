using FinalAssessmentPt1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssessmentPt1.Pages
{
    public class BasePage
    {
        public IWebDriver driver;
        public ExtentReportsHelper extent;
        public BasePage NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            extent.SetStepPass($"Navigated to url: {url}");
            return this;
        }
        
        public IWebElement FindElement(By element)
        {
            return driver.FindElement(element);
        }

        public BasePage Click(By element)
        {
            FindElement(element).Click();
            return this;
        }

        public BasePage EnterText(By element, string text)
        {
            FindElement(element).SendKeys(text);
            return this;
        }

        public BasePage SelectDropdown(By element, string text)
        {
            SelectElement dropDown = new SelectElement(FindElement(element));
            dropDown.SelectByValue(text);
            return this;
        }

        public void PauseBySeconds(int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }


    }
}
