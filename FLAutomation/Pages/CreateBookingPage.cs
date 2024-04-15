using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using FLAutomation.BaseClasses;
using FLAutomation.ComponentHelper;
using FLAutomation.Models;
using log4net;
using System.Threading;
namespace FLAutomation.Pages
{
    public class CreateBookingPage:PageBase
    {
        private IWebDriver driver;
        private TestXMLDataModel xmlDataModel;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(CreateBookingPage));
        public CreateBookingPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
            xmlDataModel = TestDataReaderHelper.ReadTestDataXML();
        }

        #region WebElement
        public IWebElement PassCodeTextBox => GenericHelper.WaitAndFindElementInPage(By.CssSelector("input[placeholder=\"Postcode\"]"));
        public IWebElement CarPlateNumberTextBox => GenericHelper.WaitAndFindElementInPage(By.CssSelector("input[placeholder=\"Car plate number\"]"));
        public IWebElement ActionLink => GenericHelper.WaitAndFindElementInPage(By.CssSelector("button[title='Select & continune']"));
        public IWebElement MileageTextBox => GenericHelper.WaitAndFindElementInPage(By.XPath("//label[text()='Enter mileage (in Kms)']/following-sibling::span/input"));
        public IWebElement PostCodeVerifyButton => GenericHelper.WaitAndFindElementInPage(By.XPath("//button[contains(@class, 'verify-btn') and text() = 'Verify']"));
        public IWebElement SearchVehicleButton => GenericHelper.WaitAndFindElementInPage(By.XPath("//button[contains(@class, 'verify-btn') and text() = 'Search vehicle']"));
        public IWebElement PostCodeSpan => GenericHelper.WaitAndFindElementInPage(By.CssSelector("span.d-flex.align-content-center"));
        public IWebElement UseThisVehicleButton => GenericHelper.WaitAndFindElementInPage(By.XPath("//button[contains(@type, 'button') and text() = 'Use this vehicle']"));
        public IWebElement ServiceSection => GenericHelper.WaitForWebElementInPage(By.XPath("(//h5[text()=\"Select services\"]/parent::div/following-sibling::div/descendant::h5[text()=\"Services\"])[1]"),TimeSpan.FromSeconds(40000));
        public IWebElement btnConfirmServices => GenericHelper.WaitAndFindElementInPage(By.XPath("//button[contains(@type, 'button') and text() = 'Confirm services']"));
        public IWebElement txtAreaAditionalInfo => GenericHelper.WaitAndFindElementInPage(By.XPath("//textarea[@aria-multiline=\"true\"]"));
        public IWebElement btnAdditionInfoConfirm => GenericHelper.WaitAndFindElementInPage(By.XPath("(//button[contains(@type, 'button') and text() = 'Confirm'])[1]"));
        public IWebElement btnPickUpTime => GenericHelper.WaitAndFindElementInPage(By.CssSelector("span[id=\"PickUpTime_selectId\"]~button"));
        public IWebElement drpDeliverySlotDate => GenericHelper.WaitAndFindElementInPage(By.XPath("(//label[.='Delivery slot']/following-sibling::div/div/span/button)[1]"));
        public IWebElement drpDeliverySlotTime => GenericHelper.WaitAndFindElementInPage(By.XPath("(//label[.='Delivery slot']/following-sibling::div/div/span/button)[2]"));
        public IWebElement btnConfirmSlot => GenericHelper.WaitAndFindElementInPage(By.XPath("//button[contains(@type, 'button') and text() = 'Confirm slot']"));
        public IWebElement txtInputName => GenericHelper.WaitAndFindElementInPage(By.CssSelector("input[placeholder=\"Name\"]"));
        public IWebElement txtInputMobile => GenericHelper.WaitAndFindElementInPage(By.CssSelector("input[placeholder=\"Mobile number\"]"));
        public IWebElement txtInputEmail => GenericHelper.WaitAndFindElementInPage(By.CssSelector("input[placeholder=\"Email address\"]"));
        string serviceXpathLocator =  "//label[text()='{0}']/child::input";
        string timeSlotXpathLocator = "//li[@role=\"option\"]/span[contains(.,'{0}')]";
        #endregion


        #region Actions

        public bool SearchPostCode()
        {
            //enter pass code value
            if (!PassCodeTextBox.TypeInTextBox(xmlDataModel.Postcode))
            {
                Logger.Info("Postcode not entered in textbox");
                return false;
            }
            Thread.Sleep(3000);
            // click verify PassCode button
            if (!PostCodeVerifyButton.ClickButton())
            {
                Logger.Info("Verify button not clicked");
                return false;
            }
            Thread.Sleep(3000);
            return true;
        }

        public bool SearchCarPlateNumber()
        {
            //enter pass code value
            if (!CarPlateNumberTextBox.TypeInTextBox(xmlDataModel.CarPlateNumber))
            {
                Logger.Info("Postcode not entered in textbox");
                return false;
            }
            // click verify PassCode button
            if (!SearchVehicleButton.ClickButton())
            {
                Logger.Info("Verify button not clicked");
                return false;
            }
            return true;
        }

        public bool VerifyPostCode()
        {
            if (!PostCodeSpan.GetElementInnerText().Contains("Hamburg"))
            {
                Logger.Info("Label text not matched");
                return false;
            }
            return true;
        }

        public bool IsActionLinkDisplayed()
        {
            if(!ActionLink.ElementDisplayed())
            {
                Logger.Info("Action button not displayed");
                return false;
            }
            return true;
        }

        public bool EnterMileage()
        {
            if (!MileageTextBox.TypeInTextBox(xmlDataModel.Mileage))
            {
                Logger.Info("Mileage not entered");
                return false;
            }
            return true;
        }

        public bool ClickActionLink()
        {
            if (!ActionLink.ClickButton())
            {
                Logger.Info("Action link not clicked");
                return false;
            }
            return true;
        }

        public bool ClickUseThisVehicle()
        {
            if (!UseThisVehicleButton.ClickButton())
            {
                Logger.Info("Use This Vehicle button not clicked");
                return false;
            }
            return true;
        }

        public bool IsServiceSectionDisplayed()
        {
            if (!btnConfirmServices.ElementDisplayed())
            {
                Logger.Info("Service section not displayed");
                return false;
            }
            return true;
            
        }

        public bool SelectServices()
        {
            try
            {
                foreach (string service in xmlDataModel.Services)
                {
                    By locator = By.XPath(string.Format(serviceXpathLocator, service));
                    IWebElement serviceElement = GenericHelper.GetElement(locator);
                    serviceElement.ScrollToAndClick();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ClickConfirmServiceButton()
        {
            if (!btnConfirmServices.ScrollToAndClick())
            {
                Logger.Info("Confirm services button not clicked");
                return false;
            }
            return true;
        }

        public bool IsAditionalSectionVisible()
        {
            Thread.Sleep(8000);
            if (!txtAreaAditionalInfo.ElementDisplayed())
            {
                Logger.Info("Aditional information section is visible");
                return false;
            }
            return true;
            
        }

        public bool EnterAdditionalInformation()
        {
            if (!txtAreaAditionalInfo.TypeInTextBox(xmlDataModel.AditionalInfo))
            {
                Logger.Info("Mileage not entered");
                return false;
            }
            return true;
        }

        public bool ClickAddInfoButton()
        {
            if (!btnAdditionInfoConfirm.ClickButton())
            {
                Logger.Info("Confirm button not clicked");
                return false;
            }
            return true;
        }

        public bool EnterPickUpTimeSlot()
        {
            if (!btnPickUpTime.ClickButton())
            {
                Logger.Info("Pickup button not clicked");
                return false;
            }
            if (!SelectCollectionSlot())
            {
                Logger.Info("Collection slot not selected");
                return false;
            }
            if (!drpDeliverySlotDate.ClickButton())
            {
                Logger.Info("delivery date button not clicked");
                return false;
            }
            if (!SelectDeliveryDate())
            {
                Logger.Info("Collection slot not selected");
                return false;
            }
            if (!drpDeliverySlotTime.ClickButton())
            {
                Logger.Info("delivery date button not clicked");
                return false;
            }
            if (!SelectDeliveryTime())
            {
                Logger.Info("Collection slot not selected");
                return false;
            }
            if(!btnConfirmSlot.ClickButton())
            {
                Logger.Info("Confirm slot not clicked");
                return false;
            }
            return true;
        }

        public bool IsCollectionSlotVisible()
        {
            
            if (!btnPickUpTime.ElementDisplayed())
            {
                Logger.Info("Collection slot section is visible");
                return false;
            }
            return true;

        }

        public bool EnterUserInfo()
        {

            if (!txtInputName.TypeInTextBox(xmlDataModel.UserName))
            {
                Logger.Info("input name is filled "+ xmlDataModel.UserName);
                return false;
            }
            if (!txtInputMobile.TypeInTextBox(xmlDataModel.Mobile))
            {
                Logger.Info("input mobile is filled " + xmlDataModel.Mobile);
                return false;
            }

            if (!txtInputEmail.TypeInTextBox(xmlDataModel.Email))
            {
                Logger.Info("input Email is filled " + xmlDataModel.Email);
                return false;
            }
            return true;

        }
        private bool SelectCollectionSlot()
        {
            By locator = By.XPath(string.Format(timeSlotXpathLocator, xmlDataModel.CollectionSlotTime));
            IWebElement serviceElement = GenericHelper.GetElement(locator);
            serviceElement.ScrollToAndClick();
            return true;
        }
        private bool SelectDeliveryDate()
        {
            By locator = By.XPath(string.Format(timeSlotXpathLocator, DateTime.Now.ToString("dd-MM-yyyy")));
            IWebElement serviceElement = GenericHelper.GetElement(locator);
            serviceElement.ScrollToAndClick();
            return true;
        }
        private bool SelectDeliveryTime()
        {
            By locator = By.XPath(string.Format(timeSlotXpathLocator, xmlDataModel.DeliverySlotTime));
            IWebElement serviceElement = GenericHelper.GetElement(locator);
            serviceElement.ScrollToAndClick();
            return true;
        }
        #endregion
    }
}
