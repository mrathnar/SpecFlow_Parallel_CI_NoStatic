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


namespace Library
{
   public class Selenium
    {
       // static ConcurrentDictionary<TestInstance, IWebDriver> InstanceMap = new ConcurrentDictionary<TestInstance, IWebDriver>();
      //  public static IWebDriver WebDriver = null;
        public static By by;
        public static IWebElement PageObject;
        public static IList<IWebElement> PageObjectCollection;
        public static string parentWIndow = null;
        public static IWebElement GetObject(string props)
        {

            //string txtUserName = "Id=ctl00_SPWebPartManager1_g_be0b090f_59b9_4c2b_95a6_7ba14fae62c2_ctl00_LoginControl_UserNameLabel";
            //string txtUserName = "Name=ctl00$SPWebPartManager1$g_be0b090f_59b9_4c2b_95a6_7ba14fae62c2$ctl00$LoginControl$txt_UserName";
            //string[] objProp = props.Split('=');P
            string[] objProp = props.Split(new[] { "=" }, 2, StringSplitOptions.None);

            Type ClassName = typeof(By);
            MethodInfo MethodName = ClassName.GetMethod(objProp[0]);
            By objProperty = (By)MethodName.Invoke(by, new object[] { objProp[1] });

            Type objType = BrowserDriver.objDriver.GetType();
            MethodInfo objMethod = objType.GetMethod("FindElement");

            PageObject = (IWebElement)objMethod.Invoke(BrowserDriver.objDriver, new object[] { objProperty });
           return PageObject;
        }

        public static IList<IWebElement> GetObjects(string props)
        {

            string[] objProp = props.Split(new[] { "=" }, 2, StringSplitOptions.None);

            Type ClassName = typeof(By);
            MethodInfo MethodName = ClassName.GetMethod(objProp[0]);
            By objProperty = (By)MethodName.Invoke(by, new object[] { objProp[1] });

            Type objType = BrowserDriver.objDriver.GetType();
            MethodInfo objMethod = objType.GetMethod("FindElements");
            PageObjectCollection = (IList<IWebElement>)objMethod.Invoke(BrowserDriver.objDriver, new object[] { objProperty });
            return PageObjectCollection;

        }
    }
}
