using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using FLAutomation.ComponentHelper;
using log4net;
using TechTalk.SpecFlow;
using NUnit.Framework;
using BoDi;
using FLAutomation.Configuration;
using FLAutomation.Settings;
namespace FLAutomation.BaseClasses
{
    public class BrowserDriver
    { 
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BrowserDriver));
       
        private static FirefoxProfile GetFirefoxptions()
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            //profile = manager.GetProfile("default");
            Logger.Info(" Using Firefox Profile ");
            return profile;
        }


        private static FirefoxOptions GetOptions()
        {
            FirefoxProfileManager manager = new FirefoxProfileManager();

            FirefoxOptions options = new FirefoxOptions()
            {
                Profile = manager.GetProfile("default"),
                AcceptInsecureCertificates = true,

            };
            return options;
        }

       
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            Logger.Info(" Using Chrome Options ");
            return option;
        }

        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
            Logger.Info(" Using Internet Explorer Options ");
            return options;
        }


        private static FirefoxDriver GetFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            FirefoxDriver driver = new FirefoxDriver(options);
            return driver;
        }

        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }

        public static IWebDriver GetBrowserDriver()
        {
            ObjectRepository.Config = new AppConfigReader();
            IWebDriver driver;
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    Logger.Info(" Using Firefox Driver  ");
                    driver= GetFirefoxDriver();
                    break;

                case BrowserType.Chrome:
                    driver = GetChromeDriver();
                    Logger.Info(" Using Chrome Driver  ");
                    break;

                case BrowserType.IExplorer:
                    driver = GetIEDriver();
                    Logger.Info(" Using Internet Explorer Driver  ");
                    break;

                default:
                    throw new NoSuchDriverException("Driver Not Found : " + ObjectRepository.Config.GetBrowser().ToString());
            }
            
               driver.Manage() .Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());
               driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            ObjectRepository.Driver = driver;
            return driver;
        }

        //public static void TearDown()
        //{
        //    if (ObjectRepository.Driver != null)
        //    {
        //        ObjectRepository.Driver.Close();
        //        ObjectRepository.Driver.Quit();
        //    }
        //    Logger.Info(" Stopping the Driver  ");
        //}
    }
}
