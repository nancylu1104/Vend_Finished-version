using System;
using System.Drawing.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Pages;
using Vend_Testing.Global;

namespace Vend_Testing.Pages
{
    public class ProductPage:BasePage
    {
        #region Elements
        [FindsBy(How = How.XPath, Using = "//div[contains(text(),\'Promotions\')]")]
        private IWebElement LinkPromotion { get; set; }
        #endregion

        #region Methods
        //点击promotion按钮
        public PromotionsPage ClickPromotion()
        {
            Driver.WaitForElementExist(By.XPath("//div[contains(text(),\'Promotions\')]"), 10);
            LinkPromotion.Click();
            while (!Driver.driver.Url.Contains("promotions"))
            {
                Thread.Sleep(200);
            }
            return new PromotionsPage();
        }
        #endregion
    }
}