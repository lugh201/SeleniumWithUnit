using FinalAssessmentPt1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;


namespace FinalAssessmentPt1.Pages.QuoteMotorcycle
{
    public class SelectMotorcyclePriceOption:BasePage
    {
        public SelectMotorcyclePriceOption(IWebDriver driver, ExtentReportsHelper extent)
        {
            this.driver = driver;
            this.extent = extent;
        }

        private By rBtnUltimate = By.XPath("*//input[@id='selectultimate']/parent::label");
        private By btnNext = By.Id("nextsendquote");
        private By tabActive = By.XPath("*//li[@class=\"idealsteps-step-active\"]/a[@id=\"selectpriceoption\"]");

        public SelectMotorcyclePriceOption Verify()
        {
            Assert.IsNotNull(FindElement(tabActive));
            extent.SetStepPass("Price Option Tab is displayed");

            return this;
        }

        public SelectMotorcyclePriceOption SelectPriceOption()
        {
            Click(rBtnUltimate);
            extent.SetStepPass("Ultimate option is selected");

            return this;
        }

        public SendMotorcycleQuote ClickNext()
        {
          
        
            Click(btnNext);
            extent.SetStepPass("Send Quote Data will be displayed");

            return new SendMotorcycleQuote(driver, extent);

        }

    }
}
