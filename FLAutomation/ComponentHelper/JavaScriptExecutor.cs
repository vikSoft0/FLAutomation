using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using log4net;
using FLAutomation.Settings;
using System.Threading;
namespace FLAutomation.ComponentHelper
{
    public static class JavaScriptExecutor
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(JavaScriptExecutor));
        public static object ExecuteScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            Logger.Info($" Execute Script @ {script}");
            return executor.ExecuteScript(script);

        }

        public static object ExecuteScript(string script, params object[] args)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            return executor.ExecuteScript(script, args);
        }

        public static void ScrollIntoViewAndClick(this IWebElement element)
        {
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(500);
            element.Click();
        }

        public static bool ScrollToAndClick(this IWebElement element)
        {
            try
            {
                ExecuteScript("arguments[0].scrollIntoView(true);", element);
                Thread.Sleep(2000);
                ExecuteScript("arguments[0].click();", element);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetElementInnerText(this IWebElement element)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            string innerText = (string)executor.ExecuteScript("return arguments[0].innerText;", element);
            return innerText;

        }

    }
}
