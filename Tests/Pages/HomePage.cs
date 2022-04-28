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
    public class HomePage : AbstractWebPage
    {
        private By signInButtonBy = By.ClassName("login");
        private By userLabelBy = By.XPath("//*[@class='header_user_info']//span");
        public HomePage(AbstractWebActions driver) : base(driver)
        {
        }

        public AuthenticationPage ClickOnSignInButtonAndGoToAuthenticationPage()
        {
            driver.ClickOnElement(signInButtonBy);
            return new AuthenticationPage(driver);
        }

        public HomePage GetUserLabelText(out string userLabel)
        {
            userLabel = driver.GetElementText(userLabelBy);
            return this;
        }
    }
}
