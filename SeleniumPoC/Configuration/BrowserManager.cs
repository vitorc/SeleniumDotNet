using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SeleniumPoC.Configuration
{
    public class BrowserManager
    {
        private IWebDriver driver;

        public static void OpenUrl(String url, IWebDriver webdriver)
        {
            webdriver.Manage().Window.Maximize();
            webdriver.Navigate().GoToUrl(url);
        }

        public static void CloseURL(IWebDriver webdriver)
        {
            webdriver.Quit();
        }

        public static void ImplicitWait(int seconds, IWebDriver webdriver)
        {
            webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
            
        }
    }
}
