using Library;
using NUnit.Framework;
using PageObjects;
//using SpecFlow.API.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlow.API
{
    [Binding]
    public sealed class VerifyGet
    {
        private string cityName;
        public RestUtil _restUtil;
       
        // private readonly IObjectContainer _objectContainer;
        //public Hooks(IObjectContainer objectContainer, UIBrowser browser)
        public VerifyGet(RestUtil restUtil)
        {
            // _objectContainer = objectContainer;
            _restUtil = restUtil;


        }


      

        [Given(@"i have a url")]
        public void GivenIHaveAUrl()
        {
           // RestUtil.SetBaseURL();
            _restUtil.SetBaseURL(ConfigurationManager.AppSettings.Get("baseURL"));
            Reporter.Report("Pass", "Application launched on Chrome : " + ConfigurationManager.AppSettings.Get("baseURL"));
        }

       [When(@"i call get keyword(.*)")]
        public void WhenICallGetKeyword(string city)
        {
            cityName = city.Trim();
            //  RestUtil.SendRequestByEndPoint(city);
            _restUtil.SendRequestByEndPoint(city);
            Reporter.Report("Pass", "Enter keyword :"+city);
        }

        [Then(@"get api response in jason format")]
        public void ThenGetApiResponseInJasonFormat()
        {
            Console.WriteLine("***********************Get Json body and verify city name*****************");
            // Get Reponse entire body and verify city
            try
            {
                // if (RestUtil.GetResponse()) // use cotext injection
                if (_restUtil.GetResponse())
                {
                    Assert.AreEqual(true, true, "City exist");
                    Reporter.Report("Pass", "city exists");
                }
                else
                {
                    Assert.AreEqual(true, false, "City not exist");
                    Reporter.Report("Fail", "city not exists");
                }

                // RestUtil.GetStatusCode();
                _restUtil.GetStatusCode();
                // Assert.AreEqual(200, RestUtil.StatusCode);
                Assert.AreEqual(200, _restUtil.StatusCode);
                Reporter.Report("Pass", "stauts code is :"+ _restUtil.StatusCode);
            }
            catch(Exception e)
            {
                //  RestUtil.GetStatusCode();
                _restUtil.GetStatusCode();
                Reporter.Report("Fail", "stauts code is :" + _restUtil.StatusCode);
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine("***********************Get value based on key*****************");
            // get value of key
            //  RestUtil.GetResponse("City");// here we are specifiying directly key of jason file ie City no input
            _restUtil.GetResponse("City");
            Console.WriteLine("Get jason value based on key ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: " + _restUtil.strKeyVal);
            Reporter.Report("Pass", "Get jason value based on key " +_restUtil.strKeyVal);


        }

    }
}
