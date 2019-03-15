//using NUnit.Framework;
using Library;
using RestSharp;
using RestSharp.Serialization.Json;
//using RestSharp.Serialization.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public  class RestUtil
    {
        public  RestClient restClient;
         public  RestRequest restRequest;
        public  IRestResponse restResponse;
        // private  const string baseURL = "http://restapi.demoqa.com/utilities/weather/city/";
      //  private const string baseURL = "http://localhost:3000/";
        public  int StatusCode;
        public  string resData;
        public  string cityName;
        public  string strKeyVal;


        // to create client connection
        public  void SetBaseURL(string bseURL)
        {
            restClient = new RestClient(bseURL);
        }

        // Create Request
        public  void SendRequestByEndPoint(string endPoint)
        {
            cityName = endPoint;
            restRequest = new RestRequest(endPoint, Method.GET);// where city is endPointj,posts
            
        }

        public  void PostRequestByEndPoint(string endPoint)
        {
            //cityName = endPoint;
            restRequest = new RestRequest(endPoint, Method.POST);// where city is endPointj,posts

        }

        public  bool GetResponse()
        {
            
            // for status code using in next method
            restResponse = restClient.Execute(restRequest);
            //get content
           var resDatas = restClient.Execute(restRequest).Content;
            resData = resDatas;
            Console.WriteLine(resData.ToString());
            Reporter.Report("Pass", "Json body is :"+ resData.ToString());


            if (resData.Contains(cityName.Trim()))
                return true;
            else
                return false;
        }
        public  void GetResponse(string key)
        {
            try
            {
                // for status code using in next method
                restResponse = restClient.Execute(restRequest);
                var objDeserialize = new JsonDeserializer();
                var keyVal = objDeserialize.Deserialize<Dictionary<string, string>>(restResponse);
                strKeyVal = keyVal[key];
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public  void GetStatusCode()
        {

           // restResponse = restClient.Execute(restRequest);

            // get satus code
            HttpStatusCode statusCode = restResponse.StatusCode;
             StatusCode = (int)statusCode;
            Console.WriteLine("Response code is :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::  " + StatusCode);
            Reporter.Report("Pass", "Response code is :" + +StatusCode);


            //return intStatusCode;


        }




        public  void PostRequest()
        {

      
            restRequest.AddJsonBody(new Posts() { id="26",title = "postTest",author = "Rathna" });
            restResponse = restClient.Execute<Posts>(restRequest);
           

            

        }



    }
}