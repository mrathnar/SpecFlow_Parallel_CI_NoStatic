using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;
using OpenQA.Selenium;

namespace PageObjects

{
    // added comment for info page
   public class InformationPage//:Selenium
    {
         private By txtUserName1=  By.Id("username");  
        private  string txtUserName = "Id=username";//findelement.by.id("username")
        private string txtPassword = "Name=password";
        private string txtEmailId   = "Name=email";
        private string txtLocation = "Id=location";
        private string btnLogin = "XPath=//input[@value='Login']";
        private string txtMsg = "Name=Input2";
        private string btnSubmit = "XPath=//input[@value='Submit']";
        private string btnOk = "XPath=//input[@value='OK']";

      
        public  void EnterUserInfo(IWebDriver objDriver, string uname,string pwd,string email,string loc)
        {
          
            UITextFiled.EnterText(objDriver, txtUserName, uname);
            UITextFiled.EnterText(objDriver, txtPassword, pwd);
            UITextFiled.EnterText(objDriver, txtEmailId, email);
            UITextFiled.EnterText(objDriver, txtLocation, loc);
        }

        public  void ClickOnLoginButton(IWebDriver objDriver)
        {
            UIButton.Click(objDriver, btnLogin);
            Thread.Sleep(3000);
        }

        public  string GetLoginValidationMessage(IWebDriver objDriver)
        {
            string actMsg = UITextFiled.GetText(objDriver, txtMsg);
            return actMsg;
            
        }


        public  string IsLoginExist(IWebDriver objDriver)
        {
            string actMsg = UIButton.GetCaption(objDriver, btnLogin);
            return actMsg;

        }


        public  string IsSubmitExist(IWebDriver objDriver)
        {
            string actMsg = UIButton.GetCaption(objDriver, btnSubmit);
            MessageBox.Show("Just Verifying button names, No action on applcation");

            return actMsg;
        }


        public  string IsOKExist(IWebDriver objDriver)
        {
            string actMsg = UIButton.GetCaption(objDriver, btnOk);
            return actMsg;

        }

      



    }
}
