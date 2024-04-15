using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using FLAutomation.BaseClasses;
using FLAutomation.ComponentHelper;
using log4net;
namespace FLAutomation.Pages
{
    public class LoginPage : PageBase
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(LoginPage));
        private IWebDriver driver;


        #region WebElement
        public IWebElement LoginTextBox => GenericHelper.WaitAndFindElementInPage(By.Id("UserName"));
        public IWebElement PassTextBox => GenericHelper.WaitAndFindElementInPage(By.Id("Password"));

        public IWebElement LoginButton => GenericHelper.WaitAndFindElementInPage(By.Id("btnLogintoFleet"));
        #endregion

        public LoginPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;

        }

        #region Actions

        public bool Login(string usename, string password)
        {
            if (!LoginTextBox.TypeInTextBox(usename))
            {
                Logger.Error("Text not entered in textbox");
                return false;
            }
            if (!PassTextBox.TypeInTextBox(password))
            {
                Logger.Error("Text not entered in textbox");
                return false;
            }
            if (!LoginButton.ClickButton())
            {
                Logger.Error("Text not entered in textbox");
                return false;
            }
            return true;
        }

        public bool IsLoginTextBoxDisplayed()
        {
            if(!LoginTextBox.ElementDisplayed()){
                Logger.Warn("Text not entered in textbox");
                return false;
            }
            return true;
        }
        #endregion

        #region Navigation

        public void NavigateToHome()
        {
            //HomeLink.Click();
        }

        #endregion
    }
}
