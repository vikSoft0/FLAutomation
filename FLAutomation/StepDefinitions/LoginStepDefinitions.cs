using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using FLAutomation.ComponentHelper;
using FLAutomation.Settings;
using FLAutomation.Pages;
namespace FLAutomation.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Login")]
    public sealed class LoginStepDefinitions
    {
        LoginPage lPage;
        DashBoardPage dpPage;

        [Given(@"Given User is at Login Page")]
        public void GivenGivenUserIsAtLoginPage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
        }

        [When(@"User login in Applilcation with valid credentials")]
        public void WhenUserLoginInApplilcationWithValidCredentials()
        {
            lPage = new LoginPage(ObjectRepository.Driver);
            bool result = lPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            Assert.IsTrue(result);
            dpPage = new DashBoardPage(ObjectRepository.Driver);
        }

        [When(@"LogOut button should be displayed")]
        public void WhenLogOutButtonShouldBeDisplayed()
        {
            Assert.IsTrue(dpPage.IsLogOutButtonDisplayed);
        }

        [When(@"User LogOut from the Application")]
        public void WhenUserLogOutFromTheApplication()
        {
            Assert.IsTrue(dpPage.LogOut());
        }

        [Then(@"Login Page should available")]
        public void ThenLoginPageShouldAvailable()
        {
            Assert.IsTrue(lPage.IsLoginTextBoxDisplayed());
        }

    }
}
