using SpecFlow.API.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Configuration;
using Library;

namespace SpecFlow.API.stepdefs.Soap
{
    [Binding]
    public sealed class Soap_Verify_Get
    {

        public SoapUtil _soapUtil;

        // private readonly IObjectContainer _objectContainer;
        //public Hooks(IObjectContainer objectContainer, UIBrowser browser)
        public Soap_Verify_Get(SoapUtil soapUtil)
        {
            // _objectContainer = objectContainer;
            _soapUtil = soapUtil;


        }


        [Given(@"i have a soap url")]
        public void GivenIHaveASoapUrl()  
        {
            _soapUtil.SetBaseURL(ConfigurationManager.AppSettings.Get("soapURL"));
        }

        [When(@"i call xml")]
        public void WhenICallXml()
        {
            SoapUtil.Soap_GetXmlBody("GET");
            string keyword = "GET";
            Reporter.Report("Pass", " Perfromed  " +"\"" + keyword + "\"" + " action:");

        }

        [Then(@"get api response in xml Format")]
        public void ThenGetApiResponseInXmlFormat()
        {
            if(SoapUtil.actXMLData.Contains("tCountryInfo"))
               
                {
                Reporter.Report("Pass", " Exptected data existed in xml :"+ "tCountryInfo");
                Console.WriteLine(" test passed"); 
            }
            else
            {
                Reporter.Report("Fail", " Get Operation failed :");
                Console.WriteLine(" test failed");
            }
        }

    }
}
