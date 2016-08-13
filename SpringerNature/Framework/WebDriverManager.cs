using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;

namespace SpringerNature.Framework
{
    static public class WebDriverManager
    {
        public enum DriverType
        {
            PhantomJS,
            InternetExplorer,
            Chrome,
            Unassigned
        }
        private static IWebDriver driver = null;
        private static DriverType activeDriverType;



        static public void InitializeWebDriver(DriverType driverType = DriverType.Unassigned)
        {
            if (driverType == DriverType.Unassigned)
            {
                String configBrowser = ConfigurationManager.AppSettings.Get("Browser");

                switch (configBrowser.ToLower())
                {
                    case "chrome":
                        driverType = DriverType.Chrome;
                        break;
                    case "phantomjs":
                        driverType = DriverType.PhantomJS;
                        break;
                    case "ie":
                        driverType = DriverType.InternetExplorer;
                        break;
                    case "firefox":
                        break;
                    default:
                        Console.WriteLine("Invalid broswer type read from app.config. Defaulting to IE.");
                        driverType = DriverType.InternetExplorer;
                        break;

                }
            }
            switch (driverType)
            {
                case DriverType.PhantomJS:
                    driver = new PhantomJSDriver();
                    break;
                case DriverType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case DriverType.InternetExplorer:
                    driver = new InternetExplorerDriver();
                    break;
            }
            activeDriverType = driverType;
        }
        static public void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
        /// <summary>
        /// this method returns the current instance of the selenium web driver. if there is not a current instance
        /// it will create a new instance and pass that back.
        /// </summary>
        /// <returns></returns>
        static public IWebDriver GetDriver()
        {
            if (driver == null)
            {

                String browserType = ConfigurationManager.AppSettings.Get("Browser");

                switch (browserType.ToLower())
                {
                    case "phantomjs":

                        InitializeWebDriver(DriverType.PhantomJS);
                        break;
                    case "chrome":
                        InitializeWebDriver(DriverType.Chrome);
                        break;
                    case "ie":
                        InitializeWebDriver(DriverType.InternetExplorer);
                        break;
                }
            }
            return driver;
        }
    }
}
