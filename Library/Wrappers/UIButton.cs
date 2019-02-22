using System;
using System.Threading;

namespace Library
{
   public class UIButton
    {

        public static void Click(string btnButton)
        {
            try
            {
                
                Selenium.GetObject(btnButton).Click();
                Reporter.Report("Pass","click operation done on button");
                Thread.Sleep(2000);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }
        }


        public static string GetCaption(string btnButton)
        {
            string btnCaption = null;
            try
            {

               btnCaption= Selenium.GetObject(btnButton).GetAttribute("Value");
                Reporter.Report("Pass", "Button"+ "\"" + btnCaption + "\"" + "existed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }
            return btnCaption;
        }
    }
}
