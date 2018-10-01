using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Pages;
using Vend_Testing.Global;

namespace Vend_Testing.Pages
{
    public class PromotionsPage:BasePage
    {
        #region Elements
        [FindsBy(How = How.XPath,Using = "//div[@class=\'vd-expandable\']")]
        private IWebElement PromotionLocation { get; set; }
        #endregion

        #region Methods
        //获取promotion页面的promotion状态
        public void GetWebPromotionStatus()
        {
            Driver.WaitForElementExist(
                By.XPath("//div[@class=\'vd-expandable\']"), 10);
            Thread.Sleep(200);
            var lists = PromotionLocation.FindElements(By.TagName("button"));
            //检查web测试的标志位，默认为0
            JsonBodyAndProperties.WebPromotionTag = lists.Count-1;
        }
        #endregion
    }
}