using Library;
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
        //Returns the list of countries
        public static string lstCountries = "Name=conlist";
      //  public static string lstCountries = "Name=abc";
        public static IList<string> expCountries = new List<string>();




        public static void VerifyDisplayofCountriesListBox()
        {
            // Check the list of countries
            // Comment from Temp Branch
               UIListBox.isDisplayed(lstCountries);

        }
        public static void VerifyCountryNames()
        {

            UIListBox.VeriryListItems(lstCountries,expCountries);
            MessageBox.Show("Just Verifying country names, No action on applcation");
            

        }
    }
}
