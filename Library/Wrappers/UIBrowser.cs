using Library.Utilites;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

//using TechTalk.SpecFlow;

//using OpenQA.Selenium.PhantomJS;
//using FrameWork;

namespace Library
{

    public class UIBrowser //: Selenium

    {
         public IWebDriver objDriver{get;  set; }
        //private IWebDriver objDriver;
        Utility utility = new Utility();
       private  string driverPath = "D:\\SpecFlow\\SpecFlowSol\\" + ConfigurationManager.AppSettings.Get("driverPath");
       // private  string driverPath = Utility.ProjectPath + ConfigurationManager.AppSettings.Get("driverPath");
        public enum BrowserType
        {
            Chrome, IExplorer, Firefox, PhantomJS

        }

       // BrowserDriver browserDriver = new BrowserDriver();

        public   void IntiateBrowserDriver()
        {
            BrowserType browsesrtype;
            ScenarioContext.Current["browser"] = ConfigurationManager.AppSettings.Get("Browser");
            browsesrtype = (BrowserType)Enum.Parse(typeof(BrowserType), ScenarioContext.Current["browser"].ToString());
            switch (browsesrtype)
            {
                case BrowserType.IExplorer:
                    InternetExplorerDriverService ieService = InternetExplorerDriverService.CreateDefaultService(driverPath);
                    objDriver = new InternetExplorerDriver(ieService);
                    Console.WriteLine("IE browser invoked");
                    objDriver.Manage().Window.Maximize();
                  
                   
                    Thread.Sleep(5000);
                    break;
                case BrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    ChromeDriverService chrService = ChromeDriverService.CreateDefaultService(driverPath);
                    objDriver = new ChromeDriver(chrService, options);
                    objDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(500);
                    objDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(500);
                    objDriver.Manage().Window.Maximize();
                    //x = objDriver;
                    
                    //objDriver.Navigate().GoToUrl(url);  // objDriver.Url = url;

                    
                    
                    break;
                case BrowserType.Firefox:
                    Console.WriteLine("Firefox Browser Invoked");
                    FirefoxDriverService frxService = FirefoxDriverService.CreateDefaultService(driverPath);
                    frxService.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    objDriver = new FirefoxDriver(frxService);

                    //objDriver.Navigate().GoToUrl(url);
                    objDriver.Manage().Window.Maximize();
                    break;
              

            }

        }
        //public IWebDriver GetDriver()
        //{
        //    return objDriver;
        //}
        public void Navigate(string url)
        {
            try
            {
                objDriver.Navigate().GoToUrl(url);
                Reporter.Report("Pass", "Application launched on Chrome : " +url);
            }
            catch(Exception e)
            {
                Reporter.Report("Fail", "Application not launched on Chrome : " ,objDriver);
                Console.WriteLine(e.Message);
               // throw new Exception("fail" + e.StackTrace);
            }
        }
        public   void CloseBrowser()
        {
            objDriver.Close();
        }

        public  void QuitBrowser()
        {
            objDriver.Quit();
        }

    }

}





