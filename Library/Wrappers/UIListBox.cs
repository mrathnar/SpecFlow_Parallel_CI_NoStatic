using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library
{
   public class UIListBox
    {
       static  bool  blnFlag=true;
   //Selenium selenium = new Selenium();

        public  static bool isDisplayed(IWebDriver objDr,string objList)
        {
            try
            {

              bool b= Selenium.GetObject(objDr,objList).Displayed;// if false it doesn't return fasle, throws exception
                Reporter.Report("Pass", "ListBox Existed");
                return true;
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
                Reporter.Report("Fail", "ListBox not Existed", objDr);
                return false;
            }
        }
        public static void VeriryListItems(IWebDriver objDr,string objList, IList<string> expCountries)
        {
            try
            {
                IList<IWebElement> actCountries = Selenium.GetObject(objDr,objList).FindElements(By.TagName("option"));

                for (int index = 0; index <= expCountries.Count - 1; index++)
                {
                    if (actCountries[index].Text == expCountries[index])
                    {
                        blnFlag = true;
                    }
                    else
                    {
                        blnFlag = false;
                        break;
                    }

                }

                if (blnFlag)
                {
                    Reporter.Report("Pass", "Countries are matched");
                }
                else
                {
                    Reporter.Report("Fail", "Countries are not matched", objDr);
                }


                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }
        }

    }
}
