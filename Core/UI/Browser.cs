using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;

namespace Core.UI
{
    public class Browser
    {
        
        private static Browser currentInstance;
        public static Browser Instance => currentInstance ??= new Browser();
        private static IWebDriver driver;
        public Browser()
        {
            driver = SetUpDriver("Chrome");
        }
        public IWebDriver SetUpDriver(string type) => type switch
        {
            "Chrome" => new ChromeDriver(),
            "Firefox" => new FirefoxDriver(),
            _ => new ChromeDriver(),
        };
        public IWebDriver SetUpRemoteDriver(string browserType)
        {
            var url = "http://10.22.147.107:4444";
            switch (browserType)
            {
                case "Chrome":
                    var chromeOptions = new ChromeOptions();
                    //chromeOptions.AddArguments("headless");
                    return new RemoteWebDriver(new Uri(url), chromeOptions.ToCapabilities());
                case "Firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments("headless");
                    return new RemoteWebDriver(new Uri(url), firefoxOptions.ToCapabilities());
                default: goto case "Chrome";
            }
        }
        public IWebDriver GetDriver() => driver;
        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void ReloadPage()
        {
            driver.Navigate().Refresh();
        }
        public void Quit()
        {
            driver.Quit();
            driver = null;
            currentInstance = null;
        }
        public void SwitchToNextTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(4000);
        }
        public string GetUrl()
        {
            return driver.Url;
        }
    }
}