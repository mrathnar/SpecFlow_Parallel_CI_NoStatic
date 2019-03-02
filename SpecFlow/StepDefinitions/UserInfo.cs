using Library;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects;
using PageObjects.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlow
{
    [Binding]
    public sealed class UserInfo

    {
         private UIBrowser _browser;
         private InformationPage _infoPage;

        public UserInfo(UIBrowser browser,InformationPage infoPage)
        {
            _browser = browser;
            _infoPage = infoPage;

        }

        [Given(@"User navigates to the site")]
        public void GivenUserNavigateToSite()
        {
            
            _browser.Navigate(ConfigurationManager.AppSettings.Get("appURL"));

        }

        [When(@"Enter data in (.*) (.*) (.*) (.*)")]
        public void WhenEnterDataIn(string uname, string pwd, string email, string loc)
        {
           _infoPage.EnterUserInfo(_browser.objDriver, uname, pwd, email, loc);
        }

        [When(@"Clicked on  Login button")]
        public void WhenClickedOnLoginButton()
        {
            _infoPage.ClickOnLoginButton(_browser.objDriver);
        }

        [Then(@"Login sucessful text will display in text filed (.*)")]
        public void ThenLoginSucessfulTextWillDisplayInTextFiled(string expVal)
        {
           Assert.AreEqual(expVal, _infoPage.GetLoginValidationMessage(_browser.objDriver));
        }

        [Then(@"page shoud contains following buttons")]
        public void ThenPageShoudContainsFollowingButtons(Table table)
        {
            // this is for sigle line data, at step level
            var tableData = table.CreateInstance<TableData>();
            Assert.AreEqual(tableData.Button1, _infoPage.IsLoginExist(_browser.objDriver));
            Assert.AreEqual(tableData.Button2, _infoPage.IsSubmitExist(_browser.objDriver));

            // Assert.AreEqual(tableData.Button2, _infoPage.IsOKExist(_browser.objDriver));


            // this is for multiple lines fo data, at step level
            //var tabledata1 = table.createset<tabledata>();
            //foreach (var item in tabledata1)
            //{
            //    console.writeline(item.button1);
            ////    console.writeline(item.button2);
            //    console.writeline(item.button3);
        }

    }
        


    }

