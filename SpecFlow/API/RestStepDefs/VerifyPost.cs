using NUnit.Framework;
using PageObjects;
//using SpecFlow.API.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Configuration;
using Library;

namespace SpecFlow.API.stepdefs
{
    [Binding]
    public sealed class VerifyPost
    {
        public RestUtil _restUtil;

        // private readonly IObjectContainer _objectContainer;
        //public Hooks(IObjectContainer objectContainer, UIBrowser browser)
        public VerifyPost(RestUtil restUtil)
        {
            // _objectContainer = objectContainer;
            _restUtil = restUtil;


        }


        [Given(@"i have a url of app")]
        public void GivenIHaveAUrlOfApp()
        {
            //RestUtil.SetBaseURL();
            _restUtil.SetBaseURL(ConfigurationManager.AppSettings.Get("baseURL1"));
            Reporter.Report("Pass", "Application launched on Chrome : " + ConfigurationManager.AppSettings.Get("baseURL1"));
        }

        [When(@"i call put keyword ""(.*)""")]
        public void WhenICallPutKeyword(string strPosts)
        {
            //  RestUtil.PostRequestByEndPoint(strPosts);
            _restUtil.PostRequestByEndPoint(strPosts);
            Reporter.Report("Pass", "end point url is :" + strPosts);
        }

        [Then(@"insert data in jason format")]
        public void ThenInsertDataInJasonFormat()
        {

            //RestUtil.PostRequest();
            //RestUtil.GetStatusCode();
            //Assert.AreEqual(201, RestUtil.StatusCode);

            _restUtil.PostRequest();
            _restUtil.GetStatusCode();
            Assert.AreEqual(201, _restUtil.StatusCode);


        }

    }
}
