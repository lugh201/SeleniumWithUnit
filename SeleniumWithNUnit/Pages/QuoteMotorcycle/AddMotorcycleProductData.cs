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
    public class AddMotorcycleProductData:BasePage
    {
        public AddMotorcycleProductData(IWebDriver driver, ExtentReportsHelper extent)
        {
            this.driver = driver;
            this.extent = extent;

        }

        #region Page objectts
        private By tabActive = By.XPath("*//li[@class=\"idealsteps-step-active\"]/a[@id=\"enterproductdata\"]");

        private By dtStartDate =  By.Id("startdate");
        private By ddInsuranceSum = By.Id("insurancesum");
        private By ddDamageInsurace = By.Id("damageinsurance");
        private By lblEuroProtection = By.XPath("*//label[text()='Euro Protection']");
        private By lblLegalDefenseInsurance = By.XPath("*//label[text()='Legal Defense Insurance']");

        private By btnNext = By.Id("nextselectpriceoption");


        #endregion

        #region Getters and Setters

        public string StartDate { get; set; }
        public string InsuranceSum { get; set; }
        public string DamageInsurace { get; set;}

        #endregion

        public AddMotorcycleProductData Verify()
        {
            Assert.IsNotNull(FindElement(tabActive));
            extent.SetStepPass("Enter Product Data Tab is displayed");

            return this;
        }

        public AddMotorcycleProductData PopulateFields()
        {
            EnterText(dtStartDate, StartDate);
            SelectDropdown(ddInsuranceSum, InsuranceSum);
            SelectDropdown(ddDamageInsurace, DamageInsurace);
            Click(lblEuroProtection);

            extent.SetStepPass("Motorcycle Product Data Fields are populated.");

            return this;
        }

        public SelectMotorcyclePriceOption ClickNext()
        {
            Click(btnNext);
            extent.SetStepPass("Select Price Option will be displayed");

            return new SelectMotorcyclePriceOption(driver, extent);

        }


    }
}
