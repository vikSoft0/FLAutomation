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
   public class DashBoardPage:PageBase
    {
        private IWebDriver driver;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(LoginPage));
        public DashBoardPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;

        }

        #region WebElement
        public IWebElement CreateBookingButton => GenericHelper.WaitAndFindElementInPage(By.Id("btnCreateBooking"));
        public IWebElement LogOutButton => GenericHelper.WaitAndFindElementInPage(By.CssSelector("a[href='/logout']"));
        #endregion

        #region Actions

        public bool IsLogOutButtonDisplayed
        {
            get { return LogOutButton.ElementDisplayed(); }
        }

        public bool LogOut()
        {
            if (!LogOutButton.ClickButton())
            {
                Logger.Error("Button not clicked");
                return false;
            }
            return true;
        }

        public bool CreateBookingButtonClick()
        {
            if (!CreateBookingButton.ClickButton())
            {
                Logger.Error("Create Booking button not clicked");
                return false;
            }
            return true;
        }
        #endregion
    }
}
