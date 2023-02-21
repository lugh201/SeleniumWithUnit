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
    public class AddMotorcycleInsurantData:BasePage
    {

        public AddMotorcycleInsurantData(IWebDriver driver, ExtentReportsHelper extent)
        {
            this.driver = driver;
            this.extent = extent;
        }


        #region Page Objects

        private By tabActive = By.XPath("*//li[@class=\"idealsteps-step-active\"]/a[@id=\"enterinsurantdata\"]");
        private By txtFirstName = By.Id("firstname");
        private By txtLastName = By.Id("lastname");
        private By dtDateOfBirth = By.Id("birthdate");
        private By lblMale = By.XPath("*//label[text()='Male']");
        private By lblFemale = By.XPath("*//label[text()='Female']");
        private By txtStreetAddress = By.Id("streetaddress");
        private By ddCountry = By.Id("country");
        private By txtZipCode = By.Id("zipcode");
        private By txtCity = By.Id("city");
        private By ddOccupation = By.Id("occupation");
        private By chkSpeeding = By.XPath("*//input[@id='speeding']/parent::label");
        private By chkBungeeJumping = By.XPath("*//input[@id='bungeejumping']/parent::label");
        private By chkCliffDiving = By.XPath("*//input[@id='cliffdiving']/parent::label");
        private By chkSkyDiving = By.XPath("*//input[@id='skydiving']/parent::label");
        private By chkOther = By.XPath("*//input[@id='speeding']/parent::label");
 
        private By btnNext = By.Id("nextenterproductdata");

        #endregion

        #region Getters and Setters

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Male { get; set; }
        public string Female { get; set; }
        public string StreetAddress { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Occupation { get; set; }

        #endregion

        public AddMotorcycleInsurantData Verify()
        {
            Assert.IsNotNull(FindElement(tabActive));
            extent.SetStepPass("Enter Insurant Tab is displayed");

            return this;
        }

        public AddMotorcycleInsurantData PopulateFields()
        {
            EnterText(txtFirstName, FirstName);
            EnterText(txtLastName, LastName);
            EnterText(dtDateOfBirth, DateOfBirth);
            Click(lblMale);
            EnterText(txtStreetAddress, StreetAddress);
            SelectDropdown(ddCountry, Country);
            EnterText(txtZipCode, ZipCode);
            EnterText(txtCity, City);
            SelectDropdown(ddOccupation, Occupation);
            Click(chkSpeeding);
            Click(chkSkyDiving);

            extent.SetStepPass("Motorcycle Insurant Fields are populated.");

            return this;

        }

        public AddMotorcycleProductData ClickNext()
        {
            Click(btnNext);
            extent.SetStepPass("Enter Product Data will be displayed");

            return new AddMotorcycleProductData(driver, extent);

        }
    }



}

