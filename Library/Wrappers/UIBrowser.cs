using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

//using TechTalk.SpecFlow;

//using OpenQA.Selenium.PhantomJS;
//using FrameWork;

namespace Library
{
    
    public  class UIBrowser : BrowserDriver

    {  
        
        

        public static  void Launch(string url)
        {
            BrowserType browsesrtype;
            ScenarioContext.Current["browser"] = ConfigurationManager.AppSettings.Get("Browser");
            browsesrtype = (BrowserType)Enum.Parse(typeof(BrowserType), ScenarioContext.Current["browser"].ToString());
            switch (browsesrtype)
            {
                case BrowserType.IExplorer:
                    BrowserDriver.GetInternetExplorerDriver();
                    objDriver.Navigate().GoToUrl(url);
                    objDriver.Manage().Window.Maximize();
                    Thread.Sleep(5000);
                    break;
                case BrowserType.Chrome:
                    BrowserDriver.GetChromeDriver();
                    objDriver.Navigate().GoToUrl(url);
                    objDriver.Manage().Window.Maximize();
                    Reporter.Report("Pass", "Application launched on Chrome sucessfully");
                    break;
                case BrowserType.Firefox:
                    BrowserDriver.GetFirefoxDriver();
                    objDriver.Navigate().GoToUrl(url);
                    objDriver.Manage().Window.Maximize();
                    break;
              //  case default:
                //    Console.WriteLine("Browser not found");
                //    break;

            }

        }

        public static  void CloseBrowser()
        {
            objDriver.Close();
        }

        public static void QuitBrowser()
        {
            objDriver.Quit();
        }

    }

}





