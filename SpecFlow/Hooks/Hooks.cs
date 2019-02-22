using Library;
using Library.Utilites;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlow
{
    [Binding]
    public sealed class Hooks
    {

        // public string featurename;
        #region hooks methods

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
            Reporter.FlushReport();
        }
        [BeforeFeature]
        public static  void SetupBeforeFeature()
        {
            Console.WriteLine("before feature");
             Reporter.GetFeatureName();
           // Reporter.TestName(Reporter.GetFeatureName());
        }
      
        [AfterStep]
        public void GetSteps()
        {
          //  Reporter.GetStepName();
        }
        [BeforeScenario]
        public void SetupBeforeScenario()
        {
            Reporter.GetScenarioName();
            Reporter.TestName(Reporter.FeatureName + " : " + Reporter.ScenarioName);
            //    break;
            ScenarioContext.Current["url"] = ConfigurationManager.AppSettings.Get("appURL");
            UIBrowser.Launch(ScenarioContext.Current["url"].ToString());
        }

        [AfterScenario]
        public void CleanupAfterScenario()
        {
            UIBrowser.QuitBrowser();
        }
        #endregion







    }
}
