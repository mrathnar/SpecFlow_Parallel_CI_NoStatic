using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Wrappers
{
   public class UILink
    {
        public static void GetLinkCount(string lnkLink)
        {
            try
            {
                IList<IWebElement> lnkCollection = Selenium.GetObjects(lnkLink);
                Reporter.Report("Pass", "No.of links on page are : " + lnkCollection.Count);
            }
                catch(Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }

        }
    }
}
