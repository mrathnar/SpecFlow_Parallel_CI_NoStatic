using PageObjects.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlow.StepDefinitions
{
    [Binding]
    public sealed class LinkCollection
    {
        [Given(@"When i navigate to homepage")]
        public void GivenWhenINavigateToHomepage()
        {
            // run from hooks
        }

        [Then(@"Verify no\.of links on page")]
        public void ThenVerifyNo_OfLinksOnPage()
        {
            LinkCheckPage.VerifyLinkCount();
        }

    }
}
