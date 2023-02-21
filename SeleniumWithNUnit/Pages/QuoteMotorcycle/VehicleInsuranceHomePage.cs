
using FinalAssessmentPt1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;


namespace FinalAssessmentPt1.Pages.QuoteMotorcycle
{
    public class VehicleInsuranceHomePage:BasePage
    {
        public VehicleInsuranceHomePage (IWebDriver driver, ExtentReportsHelper extent)
        {
            this.driver = driver;
            this.extent = extent;   
        }

        private By linkQuoteAutomobile = By.Id("nav_automobile");
        private By linkQuoteTruck = By.Id("nav_truck");
        private By linkQuoteMotorcycle = By.Id("nav_motorcycle");
        private By linkQuoteCamper = By.Id("nav_camper");

        public VehicleInsuranceHomePage Verify()
        {
            Assert.IsTrue(FindElement(linkQuoteAutomobile).Displayed);
            extent.SetStepPass("Automobile link is displayed");

            Assert.IsTrue(FindElement(linkQuoteTruck).Displayed);
            extent.SetStepPass("Truck link is displayed");

            Assert.IsTrue(FindElement(linkQuoteMotorcycle).Displayed);
            extent.SetStepPass("Motorcycle link is displayed");

            Assert.IsTrue(FindElement(linkQuoteCamper).Displayed);
            extent.SetStepPass("Camper link is displayed");

            return this;
        }

        public AddMotorcycleVehicleData ClickQuoteMotorcycle()
        {
            Click(linkQuoteMotorcycle);
            extent.SetStepPass("Vehicle Data will be displayed");

            return new AddMotorcycleVehicleData(driver, extent);



        }


    }
}
