using Library;
using OpenQA.Selenium;
using PageObjects.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlow.StepDefinitions
{
    [Binding]
    public sealed class CountriesList
    {

        private UIBrowser _browser;
        private CountriesPage _countriesPage;

        public CountriesList(UIBrowser browser, CountriesPage countriesPage)
        {
            _browser = browser;
            _countriesPage = countriesPage;

        }
        [Given(@"When user navigate to the site")]
        public void GivenWhenUserNavigateToTheSite()
        {
            _browser.Navigate(ConfigurationManager.AppSettings.Get("appURL"));
        }
        [Given(@"Verify the display of list box")]
        public void GivenVerifyTheDisplayOfListBox()
        {
           _countriesPage.VerifyDisplayofCountriesListBox(_browser.objDriver);
        }

        [Then(@"Verify the items are available as per expeted")]
        public void ThenVerifyTheItemsAreAvailableAsPerExpeted(Table table)
        {
            var tableData = table.CreateSet<TableData>();
            foreach (var item in tableData)
            {
                Console.WriteLine(item.Countries);
                _countriesPage.expCountries.Add(item.Countries);

            }
            _countriesPage.VerifyCountryNames(_browser.objDriver);

        }
    }
}
    
