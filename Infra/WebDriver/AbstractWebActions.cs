using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.WebDriver
{
    public class AbstractWebActions : EventFiringWebDriver
    {
        private WebDriverWait explicitWait;
        private int defaultTimeoutMilliseconds = 30000;

        public AbstractWebActions(IWebDriver driver) : base(driver)
        {
            explicitWait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(defaultTimeoutMilliseconds));

        }
        public WebDriverWait ExplicitWait
        {
            get { return explicitWait; }
        }
        public virtual void WaitCondition(System.Func<IWebDriver, bool> conditionFunc, int timeoutInMilliseconds)
        {
            try
            {
                WebDriverWait explicitWait = new WebDriverWait(this, TimeSpan.FromMilliseconds(timeoutInMilliseconds));
                explicitWait.Until(conditionFunc);
            }
            catch (WebDriverTimeoutException ex)
            {
                throw ex;

            }
        }


        public virtual void ClickOnElement(By searchMechanisam)
        {
                IWebElement element = FindElement(searchMechanisam);
                element.Click();
        }
        public virtual bool IsElementDisplayed(By searchMechanisam)
        {
            IWebElement element = FindElement(searchMechanisam);
           return element.Displayed;
        }
        public virtual string GetElementText(By searchMechanisam)
        {
            IWebElement element = FindElement(searchMechanisam);
            return element.Text;
        }
        public virtual void TypeToElement(By searchMechanisam, string textToType)
        {
            IWebElement element = FindElement(searchMechanisam);
            element.Clear();
            element.SendKeys(textToType);
        }

    }
}