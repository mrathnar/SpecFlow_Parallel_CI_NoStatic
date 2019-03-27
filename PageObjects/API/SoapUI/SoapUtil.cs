using Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace SpecFlow.API.Helper
{ 
    public class SoapUtil
    {
        //  private readonly string url = "https://graphical.weather.gov:443/xml/SOAP_server/ndfdXMLserver.php";
        //private readonly string url= "http://webservices.oorsprong.org/websamples.countryinfo/CountryInfoService.wso?WSDL";
        private static HttpWebRequest httpWebRequest;
        private static HttpWebResponse httpWebResponse;
        //private static XDocument xmls;
        public static string actXMLData;
        public static  int statusCode;
        private static XDocument xDoc;
        public static string xmlData;

               
        public void SetBaseURL(string soapURL)
        {
            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(new Uri(soapURL));
        }

        //public static void Soap_GetXmlBody()
        //{
        //     WebResponse webRespone = httpWebRequest.GetResponse();
        //     StreamReader streamReader = new StreamReader(webRespone.GetResponseStream());
        //     actXMLData = streamReader.ReadToEnd();
        //     Soap_GetStatusCode();
        //     if (statusCode!=200)
        //    {
        //      throw new Exception("Error calling Service. \nStatus:" + httpWebResponse.StatusCode.ToString() + "\nDescription:" + httpWebResponse.StatusDescription.ToString());
        //    }
        //}

        public static void Soap_GetXmlBody(string verb)
        {
            if (verb == "GET")
            {
                CreateWebRequests(verb);
                WebResponse webRespone = httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(webRespone.GetResponseStream());
                actXMLData = streamReader.ReadToEnd();
                Soap_GetStatusCode();
            }
            else if(verb=="POST")
            {


                // xml = XDocument.Load("D:\\SpecFlow-API\\SpecFlowSol\\SpecFlow.API\\Helper\\CountryCodes.xml");
                xDoc = XDocument.Load(ConfigurationManager.AppSettings.Get("xmlPath") + "\\CountryCodes.xml");
                CreateWebRequests(verb);

                InsertSoapEnvelopeIntoWebRequest(xDoc, httpWebRequest);

                WebResponse webRespone = httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(webRespone.GetResponseStream());
                actXMLData = streamReader.ReadToEnd();
                Soap_GetStatusCode();
            }


            if (statusCode != 200)
            {
                throw new Exception("Error calling Service. \nStatus:" + httpWebResponse.StatusCode.ToString() + "\nDescription:" + httpWebResponse.StatusDescription.ToString());
            }

            Console.WriteLine(actXMLData);
            //Reporter.Report("Pass", "xml body is :" + actXMLData);
        }

        public static void CreateWebRequests(string verb)
        {
            httpWebRequest.ContentType = "text/xml";
            httpWebRequest.Method = verb;
        }

        public static int Soap_GetStatusCode()
        {
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            statusCode = (int)httpWebResponse.StatusCode;
            Console.WriteLine("Status code is : "+ statusCode);
            Reporter.Report("Pass", "Response code is :" + +statusCode);
            // if (httpWebResponse.StatusCode != HttpStatusCode.OK)
            return statusCode;
           
            
        }
        private static void InsertSoapEnvelopeIntoWebRequest(XDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
