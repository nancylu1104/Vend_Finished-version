using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Pages;
using Vend_Testing.Global;

namespace Vend_Testing.Pages
{
    class WebregisterPage:BasePage
    {
        #region Elementds
        [FindsBy(How = How.XPath,Using = "/html[1]/body[1]/div[1]/nv-topnav[1]/div[1]/nv-user-item[1]/vd-nav-item[1]/a[1]/div[1]")]
        private IWebElement LoginName { get; set; }
               
        [FindsBy(How = How.XPath,Using = "//div[contains(text(),'Products')]")]
        private IWebElement LinkProducts { get; set; }

        [FindsBy(How = How.XPath,Using = "//vd-header[@class=\'pro-register-info-register-name vd-header vd-header--section\']")]
        private IWebElement TextMainRegister { get; set; }
        #endregion


        #region Methods
        public void VerifyLoginName()
        {
            //确保TextMainRegister可用
            if (!(TextMainRegister.Displayed && TextMainRegister.Enabled))
            {
                Thread.Sleep(200);
            }
            //等待
                Driver.WaitForElementExist(
                    By.XPath("//vd-header[@class=\'pro-register-info-register-name vd-header vd-header--section\']"), 10);
            Driver.WaitForElementExist(
                By.XPath("/html[1]/body[1]/div[1]/nv-topnav[1]/div[1]/nv-user-item[1]/vd-nav-item[1]/a[1]/div[1]"), 10);
            string loginName = LoginName.Text;
            //将页面中的名字和登陆名字进行对比
            StringAssert.AreEqualIgnoringCase(Base.UserName,loginName,"Login Name Is Wrong!");
        }
        
        //Nav to Product Page
        public ProductPage NavToProductPage()
        {
            //导航到ProductPage
            Driver.driver.Navigate().GoToUrl(Base.ProductPage);
            return new ProductPage();
        }
        //Go to Product Page, 
        //Error: stale element reference: element is not attached to the page document
        public ProductPage ClickProductPage()
        {
            Driver.WaitForElementExist(
                By.XPath("//div[contains(text(),'Products')]"), 10);
           try
           {
              var LinkProductsNew=Driver.driver.FindElement(By.XPath("//div[contains(text(),'Products')]"));
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver.driver;
                executor.ExecuteAsyncScript("arguments[0].click();", LinkProductsNew);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //等待url栏中出现product
            while (!Driver.driver.Url.Contains("product"))
            {
                Thread.Sleep(200);
            }
            return new ProductPage();
        }
        #endregion
    }
}
