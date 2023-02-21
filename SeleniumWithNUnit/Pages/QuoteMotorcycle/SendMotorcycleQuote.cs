using FinalAssessmentPt1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssessmentPt1.Pages.QuoteMotorcycle
{
    public class SendMotorcycleQuote : BasePage
    {
        public SendMotorcycleQuote(IWebDriver driver, ExtentReportsHelper extent)
        {
            this.driver = driver;
            this.extent = extent;
        }

        #region Page objectts
        private By tabActive = By.XPath("*//li[@class=\"idealsteps-step-active\"]/a[@id=\"sendquote\"]");

        private By txtEmail = By.Id("email");
        private By txtPhone = By.Id("phone");
        private By txtUsername = By.Id("username");
        private By txtPassword = By.Id("password");
        private By txtConfirmPassword = By.Id("confirmpassword");

        private By btnNext = By.Id("sendemail");

        private By confirmationMessage = By.XPath("*//h2");
        private By btnConfirm = By.XPath("*//button[@class='confirm']");




        #endregion

        #region Getters and Setters

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        #endregion

        public SendMotorcycleQuote Verify()
        {
            Assert.IsNotNull(FindElement(tabActive));
            extent.SetStepPass("Send Quote Tab is displayed");

            return this;
        }

        public SendMotorcycleQuote PopulateFields()
        {
            EnterText(txtEmail, Email);
            EnterText(txtPhone, Phone);
            EnterText(txtUsername, Username);
            EnterText(txtPassword, Password);
            EnterText(txtConfirmPassword, ConfirmPassword);

            extent.SetStepPass("Motorcycle Send Quote Data Fields are populated.");

            return this;
        }

        public SendMotorcycleQuote SendQuote()
        {
            Click(btnNext);
            extent.SetStepPass("Send e-mail success popup will be displayed");     

            return this;

        }

        public SendMotorcycleQuote ValidateEmail()
        {
           

            Assert.IsTrue(FindElement(confirmationMessage).Displayed);
            extent.SetStepPass("Sending e-mail success!");

            Click(btnConfirm);
            extent.SetStepPass("OK button is clicked");


            return this;

        }

    }
}
