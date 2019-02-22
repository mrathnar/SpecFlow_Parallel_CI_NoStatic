using Library.Wrappers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Pages
{
  

    public class LinkCheckPage
    {
             public static string lnkLink = "TagName=a";


        public static void VerifyLinkCount()
        {

            UILink.GetLinkCount(lnkLink);

        }


    }
}
