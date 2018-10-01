using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Vend_Testing.Global
{
    class Driver
    {
        //Initialise the browser
        public static IWebDriver driver { get; set; }

        #region WaitforElement 

        public static void wait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
        }

        public static IWebElement WaitForElementExist(By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
//            return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
            return (wait.Until(ExpectedConditions.ElementExists(by)));
        }

        public static IWebElement WaitForElementClickable(By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            //            return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
            return (wait.Until(ExpectedConditions.ElementToBeClickable(by)));
        }

        #endregion
    }
}