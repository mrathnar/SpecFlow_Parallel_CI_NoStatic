using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

using System.Collections.Concurrent;
using OpenQA.Selenium.Support.UI;
// added comment in util
//added second comme
// added three
namespace Library
{
    public  class Selenium
    {
        // static ConcurrentDictionary<TestInstance, IWebDriver> InstanceMap = new ConcurrentDictionary<TestInstance, IWebDriver>();
        //  public static IWebDriver WebDriver = null;
        public static  By by;
        public static  IWebElement PageObject;
        public static  IList<IWebElement> PageObjectCollection;
        public static string parentWIndow = null;
       // UIBrowser browser = new UIBrowser();
        public  static  IWebElement GetObject(IWebDriver objDriver, string props)
        {
            try
            {

//dev
                string[] objProp = props.Split(new[] { "=" }, 2, StringSplitOptions.None);//2 means devides into two strings based on first occurance of =
                Console.WriteLine("hif");                                                                 // XPath =//input[@value='OK']

                Type ClassName = typeof(By);//
                MethodInfo MethodName = ClassName.GetMethod(objProp[0]);
                By objProperty = (By)MethodName.Invoke(by, new object[] { objProp[1] });
                //objDriver.FindElement(by.XPath("//input[@value='OK']")

                Type objType = objDriver.GetType();
                MethodInfo objMethod = objType.GetMethod("FindElement");
                if (WaitForObject(objDriver, objProperty))
                {
                    PageObject = (IWebElement)objMethod.Invoke(objDriver, new object[] { objProperty });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return PageObject;
           
        }

        public  static IList<IWebElement> GetObjects(IWebDriver objDriver, string props)
        {
            try
            {
                string[] objProp = props.Split(new[] { "=" }, 2, StringSplitOptions.None);

                Type ClassName = typeof(By);
                MethodInfo MethodName = ClassName.GetMethod(objProp[0]);
                By objProperty = (By)MethodName.Invoke(by, new object[] { objProp[1] });
                // BrowserDriver browserDriver = new BrowserDriver();
                Type objType = objDriver.GetType();
                MethodInfo objMethod = objType.GetMethod("FindElements");
                if (WaitForObject(objDriver, objProperty))
                {
                    PageObjectCollection = (IList<IWebElement>)objMethod.Invoke(objDriver, new object[] { objProperty });
                }
               }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Message);
            }
            return PageObjectCollection;
           
        }
            



        public  static bool  WaitForObject(IWebDriver objD,By objElement)
        {
             try
             {
            WebDriverWait wait = new WebDriverWait(objD, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(objElement));
                //IWebElement element = wait.Until(driver => BrowserDriver.objDriver.FindElement(By.Id("kk")));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message+"object not found");
                return false;
            }
        }

        public static bool WaitForObject1(IWebDriver objD, By objElement)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(objD, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(objElement));
                //IWebElement element = wait.Until(driver => BrowserDriver.objDriver.FindElement(By.Id("kk")));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "object not found");
                return false;
            }
        }
    }
        }
    
