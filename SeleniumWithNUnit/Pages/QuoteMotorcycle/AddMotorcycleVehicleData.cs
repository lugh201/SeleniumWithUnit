using FinalAssessmentPt1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssessmentPt1.Pages.QuoteMotorcycle
{
    public class AddMotorcycleVehicleData:BasePage
    {
        public AddMotorcycleVehicleData(IWebDriver driver,ExtentReportsHelper extent)
        {
            this.driver = driver;
            this.extent = extent;
        }

        #region Motorcycle Quote tabs
        private By linkVehicleData = By.Id("entervehicledata");
        private By linkInsurantData = By.Id("enterinsurantdata");
        private By linkProductData = By.Id("enterproductdata");
        private By linkPriceOption = By.Id("selectpriceoption");
        private By linkSendQuote = By.Id("sendquote");
        #endregion

        #region Page Objects
        private By ddMake = By.Id("make");
        private By ddModel = By.Id("model");
        private By txtCylinderCapacity = By.Id("cylindercapacity");
        private By txtEnginePerformance = By.Id("engineperformance");
        private By dtDateOfManufacture = By.Id("dateofmanufacture");
        private By ddNumberOfSeats = By.Id("numberofseatsmotorcycle");
        private By txtListPrice = By.Id("listprice");
        private By txtAnnualMileage = By.Id("annualmileage");
        private By btnNext = By.Id("nextenterinsurantdata");

        #endregion

        #region Getters and Setters

        public string Model { get; set; }
        public string Make { get; set; }
        public string CylinderCapacity { get; set; }
        public string EnginePerformance { get; set; }
        public string DateOfManufacture { get; set; }
        public string NumberOfSeats { get; set; }

        public string ListPrice { get; set; }

        public string AnnualMileage { get; set; }

        #endregion


        public AddMotorcycleVehicleData Verify()
        {
            Assert.IsTrue(FindElement(linkVehicleData).Displayed);
            extent.SetStepPass("Enter Vehicle Data Tab is displayed");

            Assert.IsTrue(FindElement(linkInsurantData).Displayed);
            extent.SetStepPass("Enter Insurant Data Tab is displayed");

            Assert.IsTrue(FindElement(linkProductData).Displayed);
            extent.SetStepPass("Enter Product Data Tab is displayed");

            Assert.IsTrue(FindElement(linkPriceOption).Displayed);
            extent.SetStepPass("Select Price Option Tab is displayed");

            Assert.IsTrue(FindElement(linkSendQuote).Displayed);
            extent.SetStepPass("Send Quote Tab is displayed");

            return this;
        }

        public AddMotorcycleVehicleData PopulateFields()
        {
            SelectDropdown(ddMake, Make);
            SelectDropdown(ddModel, Model);
            EnterText(txtCylinderCapacity, CylinderCapacity);
            EnterText(txtEnginePerformance, EnginePerformance);
            EnterText(dtDateOfManufacture, DateOfManufacture);
            SelectDropdown(ddNumberOfSeats, NumberOfSeats);
            EnterText(txtListPrice, ListPrice);
            EnterText(txtAnnualMileage, AnnualMileage);

            extent.SetStepPass("Motorcycle Vehicle Data Fields are populated.");

            return this;

        }

        public AddMotorcycleInsurantData ClickNext()
        {
            Click(btnNext);
            extent.SetStepPass("Enter Insurant Data will be displayed");

            return new AddMotorcycleInsurantData(driver, extent);

        }
    }
}
