using Infra.Abstract;
using Infra.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Pages
{
    public class AuthenticationPage : AbstractWebPage
    {
        private By headerTextBy = By.ClassName("page-heading");
        private By emailTextboxBy = By.ClassName("account_input");
        private By createAccountButton = By.Id("SubmitCreate");
        public AuthenticationPage(AbstractWebActions driver) : base(driver)
        {
        }

        public AuthenticationPage GetAuthenticationPageHeaderText(out string headerText)
        {
            headerText = driver.GetElementText(headerTextBy);
            return this;
        }

        public AuthenticationPage TypeToEmailTextbox(string emailText)
        {
            driver.TypeToElement(emailTextboxBy, emailText);
            return this;
        }
        public CreateAccountPage ClickOnCreateAccountButton()
        {
            driver.ClickOnElement(createAccountButton);
            driver.WaitCondition(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(createAccountButton), 30000);

            return new CreateAccountPage(driver);
        }
    }
}
