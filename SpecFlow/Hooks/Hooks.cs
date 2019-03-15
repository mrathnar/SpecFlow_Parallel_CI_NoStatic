        using BoDi;
using Library;
using Library.Utilites;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlow.Hooks
{
    [Binding]
    public sealed class Hooks
    {

       
      
         public UIBrowser _browser;
        FeatureContext _featureContext;
        public ScenarioContext _scenarioContext;

       // private readonly IObjectContainer _objectContainer;
        //public Hooks(IObjectContainer objectContainer, UIBrowser browser)
        public Hooks( UIBrowser browser, FeatureContext featureContext,ScenarioContext scenarioContext)
        {
           // _objectContainer = objectContainer;
            _browser = browser;
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;


        }
        [BeforeTestRun]
        public static void SetUpBeforeTestRun()
        {
          
            Utility.GetProjectPath();
            Utility.CreateFolder(Utility.ProjectPath + ConfigurationManager.AppSettings.Get("reportPath"));
            Utility.CreateFolder(Utility.ProjectPath + ConfigurationManager.AppSettings.Get("screenShotPath"));
            Reporter.InItReporter();

        }
        [AfterTestRun]
        public static void CleanUpAfterTestRun()
        {

            Console.WriteLine("after test run");
           
        }

        //[BeforeFeature]
        //public static void SetupBeforeFeature(Hooks hooks)
        //{
            
        //    Console.WriteLine("before feature");
        //    //Reporter.GetFeatureName();
        //    // Reporter.TestName(Reporter.GetFeatureName());
        //    string featureName = FeatureContext.Current.FeatureInfo.Title;
        //    hooks.FeatureName = featureName;
        //}


        [BeforeScenario]
        public void SetupBeforeScenario(Hooks hooks)
        {
           
           
            Reporter.TestName(_featureContext.FeatureInfo.Title + " : " + _scenarioContext.ScenarioInfo.Title);

            //ChromeOptions options = new ChromeOptions();
            //ChromeDriverService chrService = ChromeDriverService.CreateDefaultService("C:\\Drivers");
            //_browser.objDriver = new ChromeDriver(chrService, options);





        }


        [AfterStep]
        public void CleanupAfterStep()
        {
            Reporter.FlushReport();
            

        }

        [AfterScenario]
        public void CleanupAfterScenario()
        {
           //// Reporter.FlushReport();
           // Thread.Sleep(2000);
           // _browser.QuitBrowser();

       
        }


    }
}
