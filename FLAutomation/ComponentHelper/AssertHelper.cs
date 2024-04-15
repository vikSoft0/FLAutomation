using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using log4net;
namespace FLAutomation.ComponentHelper
{
    public class AssertHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(AssertHelper));
        public static void AreEqual(string expected, string actual)
        {
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}
