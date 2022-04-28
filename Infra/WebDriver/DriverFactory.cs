using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infra.WebDriver
{
   public class DriverFactory
    {

        public static AbstractWebActions CreateWebDriver(bool privateMode = false, bool changeDownloadDirectory = false, string downloadDirectory = null, bool enableAutomation = false)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            int index = path.LastIndexOf("/");
            if (index > 0)
            {
                path = path.Substring(0, index);
            }
            EdgeOptions options = new EdgeOptions();
            EdgeDriver edgeDriver = new EdgeDriver(EdgeDriverService.CreateDefaultService(path + @"\WebDriver\WebDriversExecutables\", "msedgedriver.exe"), options);
            return new AbstractWebActions(edgeDriver);
            //"C:\Klal\KlalInfra\Infra\WebDriver\WebDriversExecutables
        }
    }
}
