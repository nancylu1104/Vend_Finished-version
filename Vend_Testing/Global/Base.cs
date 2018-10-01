using System;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Vend_Testing.Config;

namespace Vend_Testing.Global
{
    public class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(Vend_Resource.Browser);
        public static string Url = Vend_Resource.Url;
        public static string UserName = Vend_Resource.UserName;
        public static string Password = Vend_Resource.Password;
        public static string ProductPage = Vend_Resource.ProductPage;
        public static string RestClientGet = Vend_Resource.RestClientGet;
        public static string Authorization = Vend_Resource.Authorization;
        public static string Promotion = Vend_Resource.Promotion;
        public static string RestClientPatch = Vend_Resource.RestClientPatch;


        #region setup and tear down

        [SetUp]
        public void Inititalize()
        {
            switch (Browser)
            {
                case 1:
                    Driver.driver = new FirefoxDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;
                case 2:
                    Driver.driver = new ChromeDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;
            }

            if (Vend_Resource.IsLogin == "true")
            {
                //go to the login page
                Driver.driver.Navigate().GoToUrl(Url);
            }
        }


        [TearDown]
        public void TearDown()
        {

            // 关闭浏览器      
            Driver.driver.Close();
        }

        #endregion
    }
}

#endregion