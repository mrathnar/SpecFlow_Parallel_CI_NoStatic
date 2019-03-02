//using BoDi;
//using Library;
//using Library.Utilites;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Text;
//using TechTalk.SpecFlow;

//namespace SpecFlow
//{
//    [Binding]
//    public sealed class Hooks1
//    {

//        private readonly IObjectContainer _objectContainer;
//        private IWebDriver _driver;
//       // public UIBrowser _browser;


//        public Hooks(IObjectContainer objContainer)
//        {
//            _objectContainer = objContainer;

//        }
//        public string featurename;
//        #region hooks methods

//        [BeforeTestRun]
//        public static void SetUpBeforeTestRun()
//        {
//            Utility.GetProjectPath();
//            Utility.CreateFolder(Utility.ProjectPath + ConfigurationManager.AppSettings.Get("reportPath"));
//            Utility.CreateFolder(Utility.ProjectPath + ConfigurationManager.AppSettings.Get("screenShotPath"));
//            Reporter.InItReporter();

//        }
//        [AfterTestRun]
//        public static void CleanUpAfterTestRun()
//        {
//            Console.WriteLine("after test run");
//            Reporter.FlushReport();
//        }
//        [BeforeFeature]
//        public static void SetupBeforeFeature()
//        {
//            //  Reporter objReport = new Reporter();
//            Console.WriteLine("before feature");
//            Reporter.GetFeatureName();
//            // Reporter.TestName(Reporter.GetFeatureName());
//        }

//        [AfterStep]
//        public void GetSteps()
//        {
//            //  Reporter.GetStepName();

//        }
//        [BeforeScenario]
//        public void SetupBeforeScenario()
//        {

//           // ChromeOptions options = new ChromeOptions();
//           // ChromeDriverService chrService = ChromeDriverService.CreateDefaultService("C:\\Drivers");
//            _driver = new ChromeDriver("C:\\Drivers");
//            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);



//           // _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(500);
//           // _driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(500);
//          //  _driver.Manage().Window.Maximize();


//            // Reporter objReport = new Reporter();
//            Reporter.GetScenarioName();
//            Reporter.TestName(Reporter.FeatureName + " : " + Reporter.ScenarioName);
//           // _browser.IntiateBrowserDriver();
//            //    break;
//            // ScenarioContext.Current["url"] = ConfigurationManager.AppSettings.Get("appURL");
//            // UIBrowser.Launch(ScenarioContext.Current["url"].ToString());

//            // _browser.Navigate(ScenarioContext.Current["url"].ToString());

//        }

//        [AfterScenario]
//        public void CleanupAfterScenario()
//        {
//            // UIBrowser.QuitBrowser();
//            // _browser.QuitBrowser();
//            _driver.Quit();
//        }
//        #endregion







//    }
//}
