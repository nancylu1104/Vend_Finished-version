using System;
using System.Threading;
using NUnit.Framework;
using Vend_Testing.Global;
using Vend_Testing.Pages;

namespace Vend_Testing.Test
{
    class TestCases
    {
        [TestFixture]
        [Category("API And WEB Testing - (promotion.add_edit)")]
        class Vend : Base
        {
            [Test, Description("Nunit-Check Base Status, Change Permission, Patch,Check Changing!")]
            public void GetAndCheckApiAndWebStatus()
            {
                //首先获取API的状态，并且保存
                APIPermissions.GetAPIPermissonsStatus();
                //进行登陆操作
                Login();
                Thread.Sleep(1000);
                //导航到webregisterPage
                WebregisterPage webregisterPage =new WebregisterPage();
                //导航到productPage
                ProductPage productPage = webregisterPage.NavToProductPage();
                //导航到promotionsPage
                PromotionsPage promotionsPage = productPage.ClickPromotion();
                //获取promotionsPage的状态
                promotionsPage.GetWebPromotionStatus();
                Console.WriteLine("API Promotion: "+JsonBodyAndProperties.APIPromotionTag);
                Console.WriteLine("Web Promotion: "+JsonBodyAndProperties.WebPromotionTag);
                //将页面状态和API状态进行验证
                Assert.AreEqual(JsonBodyAndProperties.APIPromotionTag, JsonBodyAndProperties.WebPromotionTag, "API promotion status is: " + JsonBodyAndProperties.APIPromotionTag + " and WEB promotion status is: " + JsonBodyAndProperties.WebPromotionTag);
                //patch 与base api状态相反的码，例如 0-1 或者 1-0, 并且验证patch response status
                APIPermissions.PatchAndGetAPIStatus();
                Console.WriteLine("PATH CODE: "+JsonBodyAndProperties.PatchCode);
                //将页面进行刷新
                Driver.driver.Navigate().Refresh();
                //重新获取页面状态
                promotionsPage.GetWebPromotionStatus();

                Console.WriteLine("API Promotion: " + JsonBodyAndProperties.PatchResponseTag);
                Console.WriteLine("Web Promotion: " + JsonBodyAndProperties.WebPromotionTag);
                //验证状态
                Assert.AreEqual(JsonBodyAndProperties.PatchResponseTag,JsonBodyAndProperties.WebPromotionTag,"API promotion status after patch is: "+JsonBodyAndProperties.PatchResponseTag+ "and WEB promotion status is: "+JsonBodyAndProperties.WebPromotionTag);
            }

            private void Login()
            {
                SigninPage signinPage = new SigninPage();
                WebregisterPage webregisterPage = signinPage.Login();
                webregisterPage.VerifyLoginName();
            }
        }
    }
}