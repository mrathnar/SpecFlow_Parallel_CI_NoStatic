using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using System;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;
//using System.Drawing;
using System.Drawing.Imaging;
using System.Configuration;
using Library.Utilites;

namespace Library
{
    public class Reporter
    {


        private static ExtentReports extentReport;
        private static ExtentTest extentTest;
        public static string FeatureName;
        public static string ScenarioName;
        public static string imgFile;

        public static void InItReporter()
        {
            extentReport = new ExtentReports();
            string reportPath = Utility.ProjectPath + ConfigurationManager.AppSettings.Get("reportPath");
            var htmlReporter = new ExtentHtmlReporter(reportPath + "AutomationReport.html");
            //var htmlReporter = new ExtentHtmlReporter("D:/SpecFlow/SpecFlowSol/SpecFlow/Report/ExtentReport.html");
            htmlReporter.Configuration().DocumentTitle = "Automation Report";
            htmlReporter.Configuration().Theme = Theme.Dark;
            //attach html repoter
            extentReport.AttachReporter(htmlReporter);

            // infor
            extentReport.AddSystemInfo("OS", "Windows 10");
            extentReport.AddSystemInfo("Browser", "Chrome");
            extentReport.AddSystemInfo("Host Name", "Rathna");
            extentReport.AddSystemInfo("Environment", "Windows");
            extentReport.AddSystemInfo("User Name", "Rthna M");
        }

        public static void TestName(String name)
        {
            try
            {
                extentTest = extentReport.CreateTest(name);
            }
            catch (Exception e)
            {
                Console.WriteLine("========" + e);
            }
        }

        public static void Report(String status, String msg, IWebDriver objDr = null)
        {
            // TestName("xx");

            if (status == "Pass")
            {
                extentTest.Log(Status.Pass, msg);
            }
            else if (status == "Fail")
            {
                extentTest.Log(Status.Fail, msg);// this is to print actual statement

                string screenShotPath = Utility.ProjectPath + ConfigurationManager.AppSettings.Get("screenShotPath"); ;
                // string imgPath = "D:/SpecFlow/SpecFlowSol/SpecFlow/ScreenShots/";
                imgFile = screenShotPath + "screenShot_" + DateTime.Now.ToString("yyyy_dd_MM_hh_mm_ss") + ".bmp";
                //BrowserDriver browserDriver = new BrowserDriver();
                Screenshot imgScreenShot = ((ITakesScreenshot)objDr).GetScreenshot();
                //imgScreenShot.SaveAsFile(imgFile+".jpg");
                imgScreenShot.SaveAsFile(imgFile, ScreenshotImageFormat.Jpeg);
                Thread.Sleep(2000);


                extentTest.Log(Status.Fail, extentTest.AddScreenCaptureFromPath(imgFile).ToString());

                //extentTest.Log(Status.Fail, msg);
            }

            else if (status == "Info")
            {
                extentTest.Log(Status.Info, msg);
            }

        }



        //public static void GetFeatureName()// try to devie tow methods as scenario and feature
        //{
        //    var featureName = FeatureContext.Current.FeatureInfo.Title;
        //    FeatureName = featureName;



        //}

        //public static void GetScenarioName()
        //{
        //    var ScenarioName = FeatureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        //    var scenarioName = ScenarioContext.Current.ScenarioInfo.Title;
        //    ScenarioName = scenarioName;
        //}



        public static void FlushReport()
        {
            // objReport.Close();
            // objExtentReport.EndTest(objTest);
            extentReport.Flush();



        }


    }
}
