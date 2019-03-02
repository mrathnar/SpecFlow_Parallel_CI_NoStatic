//using BoDi;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TechTalk.SpecFlow;

//namespace SpecFlow.Hooks
//{
//    [Binding]
//    class Hooks2
//    {
//        private readonly IObjectContainer _objectContainer;
//        private IWebDriver _driver;
//        // public UIBrowser _browser;


//        public Hooks2(IObjectContainer objContainer)
//        {
//            _objectContainer = objContainer;

//        }

//        [BeforeScenario]
//        public void SetupBeforeScenario()
//        {

//            // ChromeOptions options = new ChromeOptions();
//            // ChromeDriverService chrService = ChromeDriverService.CreateDefaultService("C:\\Drivers");
//            _driver = new ChromeDriver("C:\\Drivers");
//            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);

//        }

//        [AfterScenario]
//        public void CleanupAfterScenario()
//        {
//            // UIBrowser.QuitBrowser();
//            // _browser.QuitBrowser();
//            _driver.Quit();
//        }




//    }
//    }
