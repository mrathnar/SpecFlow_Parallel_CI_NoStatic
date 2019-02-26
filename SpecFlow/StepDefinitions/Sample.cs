using PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlow.StepDefinitions
{
    [Binding]
    public sealed class Sample
    {
        [Given(@"user navigate to the site")]
        public void GivenUserNavigateToTheSite()
        {
            InformationPage.EnterFirstName();
        }

    }
}
