using Library;
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

        private string lnkLink = "TagName=a";

        UILink objLink = new UILink();

        public  void VerifyLinkCount(IWebDriver objDriver)
        {

            
            objLink.GetLinkCount(objDriver, lnkLink);

        }

      

    }
}
