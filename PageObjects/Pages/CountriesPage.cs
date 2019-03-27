using Library;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PageObjects.Pages
{
   public class CountriesPage
    { 
        //Returns the list of countries, this is just hcnage
        private string lstCountries = "Name=conlist";
        public  IList<string> expCountries = new List<string>();
        public  void VerifyDisplayofCountriesListBox(IWebDriver objDriver)
        {
            UIListBox.isDisplayed(objDriver, lstCountries);

        }
        public  void VerifyCountryNames(IWebDriver objDriver)
        {

            UIListBox.VeriryListItems(objDriver, lstCountries, expCountries);
           MessageBox.Show("Just Verifying country names, No action on applcation");
            

        }
    }
}
