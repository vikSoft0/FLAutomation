using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using BoDi;

namespace FLAutomation.BaseClasses
{
    public class PageBase
    {
        private IWebDriver driver;
         
        public PageBase(IWebDriver _driver)
        {
            this.driver = _driver;
        }
    }
}
