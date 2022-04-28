using Infra.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Abstract
{
    [TestClass]
    public abstract class AbstractTestCase
    {
        private AbstractWebActions driver;

        protected AbstractWebActions Driver
        {
            get { return driver; }
            set { driver = value; }
        }
        [TestInitialize]
        public virtual void BeforeTest()
        {
            driver = DriverFactory.CreateWebDriver();
            driver.Manage().Window.Maximize();
        }
        [TestCleanup]
        public void EndTest()
        {
            AfterTest();
            driver.Quit();
        }
        public virtual void AfterTest()
        {
        }
    }
}
