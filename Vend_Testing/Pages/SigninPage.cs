using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Pages;
using Vend_Testing.Global;

namespace Vend_Testing.Pages
{
    class SigninPage : BasePage
    {
        #region Elements

        [FindsBy(How = How.XPath, Using = "//input[@id=\'signin_username\']"),]
        private IWebElement InputUsername { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id=\'signin_password\']")]
        private IWebElement InputPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@value=\'1\']")]
        private IWebElement BtnSignIn { get; set; }

        #endregion

        #region Methods

        private void FillUserName()
        {
            Driver.WaitForElementExist(By.XPath("//input[@id=\'signin_username\']"), 10);
            InputUsername.Clear();
            InputUsername.SendKeys(Base.UserName);
        }

        private void FillPassword()
        {
            Driver.WaitForElementExist(By.XPath("//input[@id=\'signin_password\']"), 10);
            InputPassword.Clear();
            InputPassword.SendKeys(Base.Password);
        }

        private void ClickSignIn()
        {
            Driver.WaitForElementClickable(By.XPath("//button[@value=\'1\']"), 10);
            BtnSignIn.Submit();

        }

        public WebregisterPage Login()
        {
            FillUserName();
            FillPassword();
            ClickSignIn();
            //used to make sure that the page go to the webregister
            while (!Driver.driver.Url.Contains("webregister"))
            {
                Driver.driver.Navigate().Refresh();
                Thread.Sleep(500);
            }
            return new WebregisterPage();
        }
        #endregion
    }
}