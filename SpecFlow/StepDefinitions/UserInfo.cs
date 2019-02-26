using NUnit.Framework;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlow
{
    [Binding]
    public sealed class UserInfo
    {
        [Given(@"User navigates to the site")]
        public void GivenUserNavigateToSite()
        {
            //InformationPage.EnterFirstName();
        }

        [When(@"Enter data in (.*) (.*) (.*) (.*)")]
        public void WhenEnterDataIn(string uname, string pwd, string email, string loc)
        {
            InformationPage.EnterUserInfo(uname, pwd, email, loc);
        }

        [When(@"Clicked on  Login button")]
        public void WhenClickedOnLoginButton()
        {
            InformationPage.ClickOnLoginButton();
        }

        [Then(@"Login sucessful text will display in text filed (.*)")]
        public void ThenLoginSucessfulTextWillDisplayInTextFiled(string expVal)
        {
          //  Assert.AreEqual(expVal, InformationPage.GetLoginValidationMessage());
        }

        [Then(@"page shoud contains following buttons")]
        public void ThenPageShoudContainsFollowingButtons(Table table)
        {
            // this is for sigle line data, at step level

            var tableData = table.CreateInstance<TableData>();
            Assert.AreEqual(tableData.Button1, InformationPage.IsLoginExist());
            Console.WriteLine(tableData.Button2, InformationPage.IsSubmitExist());
            Console.WriteLine(tableData.Button2, InformationPage.IsOKExist());


            // this is for multiple lines fo data, at step level
            //var tabledata1 = table.createset<tabledata>();
            //foreach (var item in tabledata1)
            //{
            //    console.writeline(item.button1);
            //    console.writeline(item.button2);
            //    console.writeline(item.button3);
        }

    }
        


    }

