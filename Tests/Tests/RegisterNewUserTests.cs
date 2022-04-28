using Infra.Abstract;
using Infra.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Pages;

namespace Tests.Tests
{
    [TestClass]
    public class RegisterNewUserTests: AbstractTestCase
    {
        private string pageHeaderText,actualUserName;
        private Random random = new Random();

        [TestMethod]
        [TestCategory("reg")]
        public void RegisterNewUserTest()
        {
            #region Step 1 - Enter To Website
            Driver.Navigate().GoToUrl( @ConfigurationManager.AppSettings["AutomationpracticeURL"]);
            #endregion

            #region Step 2 - Click on Signin Page
            AuthenticationPage authenticationPage = new HomePage(Driver).
                ClickOnSignInButtonAndGoToAuthenticationPage().
                GetAuthenticationPageHeaderText(out pageHeaderText);
            Assert.AreEqual("AUTHENTICATION", pageHeaderText, "Did not get to Authentication Page");
            #endregion

            #region Step 3 - Enter Email adress
            authenticationPage.TypeToEmailTextbox("abc123@abc123" + random.Next(1, 10000)+ ".com");
            #endregion

            #region Step 4 - Click on Create account
            CreateAccountPage createAccountPage =
            authenticationPage
                .ClickOnCreateAccountButton()
                .GetCreateAccountPageHeaderText(out pageHeaderText);
            Assert.AreEqual("CREATE AN ACCOUNT", pageHeaderText, "Did not get to Create an account Page");

            #endregion

            #region Step 5 - fill fields
            DataTest dataTest = ExcelHelper.ReadXlsxDataToDataTest();

            createAccountPage.
                TypeToFirstNameTextbox(dataTest.Firstname).
                TypeToLastNameTextbox(dataTest.Lastname).
                TypeToPasswordTextbox(dataTest.Password).
                TypeToAddressTextbox(dataTest.Address).
                TypeToCityTextbox(dataTest.City).
                SelectState(dataTest.State).
                TypeToZipTextbox(dataTest.Zip).
                SelectCountry(dataTest.Country).
                TypeToNumberTextbox(dataTest.Number);
            #endregion

            #region Step 6 - Click on register button
            createAccountPage.ClickOnRegisterButton();

            new HomePage(Driver).GetUserLabelText(out actualUserName);
            Assert.IsTrue(actualUserName.Contains(dataTest.Firstname) && actualUserName.Contains(dataTest.Lastname), "User not logged on");
            #endregion
        }
    }
}
