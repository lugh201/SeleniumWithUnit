using FinalAssessmentPt1.Pages.QuoteMotorcycle;
using FinalAssessmentPt1.Utilities;
using NUnit.Framework;

namespace FinalAssessmentPt1.Tests
{
    [TestFixture]
    public class AddMotorcycleQuoteTest:BaseTest
    {

        [Test]
        public void QuoteMotorcycleTests()
        {
            var homepage = new VehicleInsuranceHomePage(driver, extent);
            homepage.Verify();
            


            var vehicleDataPage = homepage.ClickQuoteMotorcycle();
            vehicleDataPage.Verify();

            #region  Vehicle Data
            vehicleDataPage.Make = "Audi";
            vehicleDataPage.Model = "Scooter";
            vehicleDataPage.CylinderCapacity = "500";
            vehicleDataPage.EnginePerformance = "1000";
            vehicleDataPage.DateOfManufacture = "02/01/2017";
            vehicleDataPage.NumberOfSeats = "2";
            vehicleDataPage.ListPrice = "5000";
            vehicleDataPage.AnnualMileage = "70000";

            #endregion

            vehicleDataPage.PopulateFields();

            var insurantDataPage =  vehicleDataPage.ClickNext();
            insurantDataPage.Verify();

            #region Insurant Data
            insurantDataPage.FirstName = "John";
            insurantDataPage.LastName = "Great";
            insurantDataPage.StreetAddress = "123 Test Way";
            insurantDataPage.Country = "United States";
            insurantDataPage.ZipCode = "98011";
            insurantDataPage.City = "Bothell";
            insurantDataPage.Occupation = "Employee";
            insurantDataPage.DateOfBirth = "02/01/1970";


            #endregion
            insurantDataPage.PopulateFields();

            var productDataPage = insurantDataPage.ClickNext();
            productDataPage.Verify();

            #region Product Data
            productDataPage.StartDate = "03/28/2023";
            productDataPage.InsuranceSum = "3000000";
            productDataPage.DamageInsurace = "Full Coverage";

            #endregion


            productDataPage.PopulateFields();

            var priceOptionPage = productDataPage.ClickNext();
            priceOptionPage.Verify();
            priceOptionPage.SelectPriceOption();
            var sendQuotePage = priceOptionPage.ClickNext();

            sendQuotePage.Verify();

            #region Send Quote Data
            sendQuotePage.Email = "auto@test.com";
            sendQuotePage.Phone = "0981234567";
            sendQuotePage.Username = "auto1";
            sendQuotePage.Password= "Password1";
            sendQuotePage.ConfirmPassword = "Password1";

            #endregion
            sendQuotePage.PopulateFields();
            sendQuotePage.SendQuote();
            
            sendQuotePage.ValidateEmail();
        }
    }
}
