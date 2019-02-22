using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using TechTalk.SpecFlow;
using Library.Utilites;
//using OpenQA.Selenium.PhantomJS;
//using Framework;

namespace Library
{
    public class BrowserDriver
    {

        public static IWebDriver objDriver;
        private static string driverPath = "D:\\SpecFlow\\SpecFlowSol\\"+ ConfigurationManager.AppSettings.Get("driverPath");
       private static string driverPath1 = Utility.ProjectPath + ConfigurationManager.AppSettings.Get("driverPath");
        public enum BrowserType
        {
            Chrome, IExplorer, Firefox, PhantomJS

        }
        
        
        public static void GetInternetExplorerDriver()
        {
                     
            InternetExplorerDriverService ieService = InternetExplorerDriverService.CreateDefaultService(driverPath);
            objDriver = new InternetExplorerDriver(ieService);
            Console.WriteLine("IE browser invoked");

        }

        public static void GetChromeDriver()
        {
        
            ChromeOptions options = new ChromeOptions();
            ChromeDriverService chrService = ChromeDriverService.CreateDefaultService(driverPath);
            objDriver = new ChromeDriver(chrService, options);

            //  return objDriver;

        }
        public static void GetFirefoxDriver()
        {

            Console.WriteLine("Firefox Browser Invoked");
            FirefoxDriverService frxService = FirefoxDriverService.CreateDefaultService(driverPath);
            frxService.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            objDriver = new FirefoxDriver(frxService);

        }


        



    }


}
