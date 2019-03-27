using Library;
using OpenQA.Selenium;
using PageObjects.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlow.StepDefinitions
{
    [Binding]
    public sealed class LinkCollection
    {
        private UIBrowser _browser;
        private LinkCheckPage _linkPage;

        public LinkCollection(UIBrowser browser, LinkCheckPage linkPage)
        {
            _browser = browser;
            _linkPage = linkPage;
            
        }

        [Given(@"When i navigate to homepage")]
        public void GivenWhenINavigateToHomepage()
        {
          _browser.Navigate(ConfigurationManager.AppSettings.Get("appURL"));
        }

        [Then(@"Verify no\.of links on page")]
        public void ThenVerifyNo_OfLinksOnPage()
        {
            _linkPage.VerifyLinkCount(_browser.objDriver);
        }

    }
}
