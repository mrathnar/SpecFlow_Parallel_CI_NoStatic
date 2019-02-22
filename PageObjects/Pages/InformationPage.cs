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
   public class InformationPage//:Selenium
    {
        //public static IWebElement objElement; we can use if we want directly create normal element and pass it
        
        public static string txtUserName = "Id=username";
        public static string txtPassword = "Name=password";
        public static string txtEmailId   = "Name=email";
        public static string txtLocation = "Id=location";
        public static string btnLogin = "XPath=//input[@value='Login']";
        public static string txtMsg = "Name=Input2";
        public static string btnSubmit = "XPath=//input[@value='Submit']";
        public static string btnOk = "XPath=//input[@value='OK']";

        public static void EnterUserInfo(string uname,string pwd,string email,string loc)
        {
       
                UITextFiled.EnterText(txtUserName, uname);
                UITextFiled.EnterText(txtPassword, pwd);
                UITextFiled.EnterText(txtEmailId, email);
                UITextFiled.EnterText(txtLocation, loc);
        }

        public static void ClickOnLoginButton()
        {   
           UIButton.Click(btnLogin);
            Thread.Sleep(3000);

        }

        public static string GetLoginValidationMessage()
        {
            string actMsg = UITextFiled.GetText(txtMsg);
            return actMsg;

        }


        public static string IsLoginExist()
        {
            string actMsg = UIButton.GetCaption(btnLogin);
            return actMsg;

        }


        public static string IsSubmitExist()
        {
            string actMsg = UIButton.GetCaption(btnSubmit);
            MessageBox.Show("Just Verifying button names, No action on applcation");

            return actMsg;
            


        }


        public static string IsOKExist()
        {
            string actMsg = UIButton.GetCaption(btnOk);
            return actMsg;

        }




    }
}
