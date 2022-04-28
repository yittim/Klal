using Infra.Abstract;
using Infra.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Pages
{
    public class CreateAccountPage : AbstractWebPage
    {
        private By headerTextBy = By.ClassName("page-heading");
        private By firstNameTextboxBy = By.Id("customer_firstname");
        private By lastNameTextboxBy = By.Id("customer_lastname");
        private By passwordTextboxBy = By.Id("passwd");
        private By addressTextboxBy = By.Id("address1");
        private By cityTextboxBy = By.Id("city");
        private By statecomboBy = By.Id("id_state");
        private By zipTextboxBy = By.Id("postcode");
        private By countryComboBy = By.Id("id_country");
        private By numberTextboxBy = By.Id("phone_mobile");
        private By registeButtonBy = By.Id("submitAccount");
        public CreateAccountPage(AbstractWebActions driver) : base(driver)
        {
        }

        public CreateAccountPage GetCreateAccountPageHeaderText(out string headerText)
        {
            headerText = driver.GetElementText(headerTextBy);
            return this;
        }
        public CreateAccountPage TypeToFirstNameTextbox(string text)
        {
            driver.TypeToElement(firstNameTextboxBy, text);
            return this;
        }
        public CreateAccountPage TypeToLastNameTextbox(string text)
        {
            driver.TypeToElement(lastNameTextboxBy, text);
            return this;
        }
        public CreateAccountPage TypeToPasswordTextbox(string text)
        {
            driver.TypeToElement(passwordTextboxBy, text);
            return this;
        }
        public CreateAccountPage TypeToCityTextbox(string text)
        {
            driver.TypeToElement(cityTextboxBy, text);
            return this;
        }
        public CreateAccountPage TypeToAddressTextbox(string text)
        {
            driver.TypeToElement(addressTextboxBy, text);
            return this;
        }
        public CreateAccountPage TypeToZipTextbox(string text)
        {
            driver.TypeToElement(zipTextboxBy, text);
            return this;
        }

        public CreateAccountPage SelectCountry(string text)
        {
            new SelectElement(driver.FindElement(countryComboBy)).SelectByText(text);
            return this;
        }
        public CreateAccountPage SelectState(string text)
        {
            new SelectElement(driver.FindElement(statecomboBy)).SelectByText(text);
            return this;
        }
        public CreateAccountPage TypeToNumberTextbox(string text)
        {
            driver.TypeToElement(numberTextboxBy, text);
            return this;
        }
        public CreateAccountPage ClickOnRegisterButton()
        {
            driver.ClickOnElement(registeButtonBy);
            return this;
        }
    }
}
