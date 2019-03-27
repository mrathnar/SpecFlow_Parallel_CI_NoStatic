using SpecFlow.API.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Configuration;
using System.Xml.Linq;
using System.Xml;
using Library;

namespace SpecFlow.API.stepdefs.Soap
{
    [Binding]
    public sealed class Soap_Verify_Post
    {

        public SoapUtil _soapUtil;

        // private readonly IObjectContainer _objectContainer;
        //public Hooks(IObjectContainer objectContainer, UIBrowser browser)
        public Soap_Verify_Post(SoapUtil soapUtil)
        {
            // _objectContainer = objectContainer;
            _soapUtil = soapUtil;


        }


        [Given(@"i have a soap urls")]
        public void GivenIHaveASoapUrls()
        {
            _soapUtil.SetBaseURL(ConfigurationManager.AppSettings.Get("soapURL"));
        }

        [When(@"i perfrom post request")]
        public void WhenIPerfromPostRequest()
        {
            
            SoapUtil.Soap_GetXmlBody("POST");
            string keyword = "POST";
            Reporter.Report("Pass", " Perfromed  " + "\"" + keyword + "\"" + " action:");

            Reporter.Report("Pass", " post action performed :");

        }

        [Then(@"get api response in xml Formats")]
        public void ThenGetApiResponseInXmlFormats()
        {
            if (SoapUtil.actXMLData.Contains("New Delhi"))
            {
                Console.WriteLine(" test passed");
                Reporter.Report("Pass", " Captured capital sucessfully");

            }
            else
            {
                Console.WriteLine(" test failed");
                Reporter.Report("Fail", " Could not captured capital sucessfully");
            }
        }


    }
}
