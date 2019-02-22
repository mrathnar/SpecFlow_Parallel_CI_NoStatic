using Library;
using PageObjects.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlow.StepDefinitions
{
    [Binding]
    public sealed class CountriesList
    {
       


       [Given(@"When user navigate to the site")]
        public void GivenWhenUserNavigateToTheSite()
        {
            //hooks will invoke this
        }

        [Given(@"Verify the display of list box")]
        public void GivenVerifyTheDisplayOfListBox()
        {
            CountriesPage.VerifyDisplayofCountriesListBox();
        }

        [Then(@"Verify the items are available as per expeted")]
        public void ThenVerifyTheItemsAreAvailableAsPerExpeted(Table table)
        {
            // this is for multiple lines fo data, at step level

            var tableData = table.CreateSet<TableData>();
            foreach (var item in tableData)
            {
                Console.WriteLine(item.Countries);
                CountriesPage.expCountries.Add(item.Countries);
            
            }
            CountriesPage.VerifyCountryNames();

        }
    }
}
    
