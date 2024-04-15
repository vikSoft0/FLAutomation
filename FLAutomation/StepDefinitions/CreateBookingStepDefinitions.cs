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
    [Scope(Feature = "CreateBooking")]
    public class CreateBookingStepDefinitions
    {
        LoginPage lPage;
        DashBoardPage dpPage;
        CreateBookingPage cbPage;
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
        [When(@"User Click on Create a booking button")]
        public void WhenUserClickOnCreateABookingButton()
        {
            cbPage = new CreateBookingPage(ObjectRepository.Driver);
            Assert.IsTrue(dpPage.CreateBookingButtonClick());
        }

        [Then(@"Create Booking should be displayed")]
        public void ThenCreateBookingShouldBeDisplayed()
        {
            Assert.IsTrue(ObjectRepository.Driver.Url.ToString().Contains("book-service"));
        }

        [When(@"User Enter PostCide and Verify")]
        public void WhenUserEnterPostCideAndVerify()
        {
            Assert.IsTrue(cbPage.SearchPostCode());
        }

        [Then(@"PostCode should verify")]
        public void ThenPostCodeShouldVerify()
        {
            Assert.IsTrue(cbPage.VerifyPostCode());
        }

        [When(@"User Enter Car Plate Number and Search Vehicle")]
        public void WhenUserEnterCarPlateNumberAndSearchVehicle()
        {
            Assert.IsTrue(cbPage.SearchCarPlateNumber()); 

        }

        [Then(@"Respected Result Should Available")]
        public void ThenRespectedResultShouldAvailable()
        {
            Assert.IsTrue(cbPage.IsActionLinkDisplayed());
        }

        [When(@"User Click Action Link and Enter Mileage and Click Button")]
        public void WhenUserClickActionLinkAndEnterMileageAndClickButton()
        {
            Assert.IsTrue(cbPage.ClickActionLink());
            Assert.IsTrue(cbPage.EnterMileage());
            Assert.IsTrue(cbPage.ClickUseThisVehicle());
        }

        [Then(@"Service Secion Should be displayed")]
        public void ThenServiceSecionShouldBeDisplayed()
        {
            Assert.IsTrue(cbPage.IsServiceSectionDisplayed());
        }

        [When(@"User Select services and confirm services")]
        public void WhenUserSelectServicesAndConfirmServices()
        {
            Assert.IsTrue(cbPage.SelectServices());
            Assert.IsTrue(cbPage.ClickConfirmServiceButton());
        }

        [Then(@"Additional Information section should displayed")]
        public void ThenAdditionalInformationSectionShouldDisplayed()
        {
            Assert.IsTrue(cbPage.IsAditionalSectionVisible());
        }

        [When(@"User put Informaion and confirm")]
        public void WhenUserPutInformaionAndConfirm()
        {
            Assert.IsTrue(cbPage.EnterAdditionalInformation());
            Assert.IsTrue(cbPage.ClickAddInfoButton());
        }

        [Then(@"Collection and delivery slot should disply")]
        public void ThenCollectionAndDeliverySlotShouldDisply()
        {
            Assert.IsTrue(cbPage.IsCollectionSlotVisible());
        }

        [When(@"User select Collection and delivery slot and confirm slot")]
        public void WhenUserSelectCollectionAndDeliverySlotAndConfirmSlot()
        {
            Assert.IsTrue(cbPage.EnterPickUpTimeSlot());
        }

        [Then(@"Users for collection and delivery should display")]
        public void ThenUsersForCollectionAndDeliveryShouldDisplay()
        {
            Assert.IsTrue(cbPage.EnterUserInfo());
        }
         

    }
}
