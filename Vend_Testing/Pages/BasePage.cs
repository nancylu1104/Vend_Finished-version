using OpenQA.Selenium.Support.PageObjects;
using Vend_Testing.Global;

namespace Pages
{
    public class BasePage
    {

        public BasePage()
        {
            //Initialize pagefactory
            PageFactory.InitElements(Driver.driver, this);
            //等待
            Driver.wait(10);
        }
    }
}