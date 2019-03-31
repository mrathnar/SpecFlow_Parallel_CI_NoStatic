using OpenQA.Selenium;
using System;
using System.Threading;

namespace Library
{
   public  class UIButton
    {
        //button
        // Selenium selenium = new Selenium();
        public  static void Click(IWebDriver objDr,string btnButton)
        {
            try
            {
                
                Selenium.GetObject(objDr,btnButton).Click();
                Reporter.Report("Pass","click operation done on button");
                Thread.Sleep(2000);
            }
            catch(Exception e)
            {
                Reporter.Report("Fail", "click operation could not performed on button", objDr);
            }
        }


        public static string GetCaption(IWebDriver objDr,string btnButton)
        {
            string btnCaption = null;
            try
            {

               btnCaption= Selenium.GetObject(objDr,btnButton).GetAttribute("Value");
               Reporter.Report("Pass", "Button"+ "\"" + btnCaption + "\"" + "existed");
            }
            catch (Exception e)
            {
                Reporter.Report("Fail", "button not found", objDr);
                Console.WriteLine("Exception : " + e.Message);
            }
            return btnCaption;
        }
    }
}
