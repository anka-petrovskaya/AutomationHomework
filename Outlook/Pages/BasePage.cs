using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using SeleniumExtras.WaitHelpers;

namespace Outlook.Pages
{
    public abstract class BasePage
    {
        public static IWebElement WaitForElement(By locator, int secs = 20)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Instance.GetDriver(), TimeSpan.FromSeconds(secs));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return Browser.Instance.GetDriver().FindElement(locator);
        }
        public static IList<IWebElement> WaitForElements(By locator, int secs = 20)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Instance.GetDriver(), TimeSpan.FromSeconds(secs));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return Browser.Instance.GetDriver().FindElements(locator);
        }
    }
}