using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using FLAutomation.Settings;
namespace FLAutomation.ComponentHelper
{
    public static class ElementHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(ElementHelper));

        public static bool ClickButton(this IWebElement element)
        {
            try
            {
                if (element == null)
                {
                    Logger.Error("Button element is null");
                    return false;
                }
                element.Click();
                System.Threading.Thread.Sleep(3000);
                Logger.Info(" Button Click");
                return true;
            }
            catch
            {
                Logger.Error("Button not clicked");
                return false;
            }
        }

        public static bool ElementDisplayed(this IWebElement element)
        {
            try
            {
                if (element == null)
                {
                    Logger.Error("element is null");
                    return false;
                }
               return element.Displayed;
            }
            catch
            {
                Logger.Error("Button not clicked");
                return false;
            }
        }

        public static string GetText(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static bool ElementEnabled(this IWebElement element)
        {
            try
            {
                if (element == null)
                {
                    Logger.Error("element is null");
                    return false;
                }
                return element.Enabled;
            }
            catch
            {
                Logger.Error("Button not clicked");
                return false;
            }
        }

        public static bool ClickRadioButton(this IWebElement element)
        {
            try
            {
                if (element == null)
                {
                    Logger.Error("radio button element is null");
                    return false;
                }
                element.Click();
                Logger.Info(" radio Button Click");
                System.Threading.Thread.Sleep(1000);
                return true;
            }
            catch
            {
                Logger.Error("radio button not clicked");
                return false;
            }
        }

        public static bool IsRadioButtonSelected(this IWebElement element)
        {
            try
            {
                if (element == null)
                {
                    Logger.Error("radio button element is null");
                    return false;
                }
                string flag = element.GetAttribute("checked");

                if (flag == null)
                    return false;
                else
                    return flag.Equals("true") || flag.Equals("checked");
            }
            catch
            {
                Logger.Error("radio button not clicked");
                return false;
            }   
        }

        public static bool TypeInTextBox(this IWebElement element, string text)
        {
            try
            {
                if (element == null)
                {
                    Logger.Error("element is null");
                    return false;
                }
                element.Clear();
                element.SendKeys(text);
                System.Threading.Thread.Sleep(1000);
                Logger.Info($" Type in Textbox value : {text}");
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
