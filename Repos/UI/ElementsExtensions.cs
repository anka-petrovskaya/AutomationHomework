using Core.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Repos.UI.Pages;
using System;
using System.Collections.Generic;

namespace Repos.UI
{
    public static class ElementsExtensions
    {
        public static void Click(this By locator)
        {
            BasePage.WaitForElement(locator).Click();
        }
        public static void SendKeys(this By locator, string text)
        {
            BasePage.WaitForElement(locator).SendKeys(text);
        }
        public static bool IsVisible(this By locator, int secs = 7)
        {
            try
            {
                return BasePage.WaitForElement(locator, secs).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool IsInvisible(this By locator, int secs = 7)
        {
            try
            {
                return !BasePage.WaitForElement(locator, secs).Displayed;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public static string GetText(this By locator)
        {
            return BasePage.WaitForElement(locator).Text;
        }
        public static string GetAttribute(this By locator, string name)
        {
            return BasePage.WaitForElement(locator).GetAttribute(name);
        }
        public static void HoverMouseOver(this By locator)
        {
            Actions action = new Actions(Browser.Instance.GetDriver());
            action.MoveToElement(BasePage.WaitForElement(locator)).Perform();
        }
        public static void DragAndDrop(this By from, By to)
        {
            var start = BasePage.WaitForElement(from);
            var end = BasePage.WaitForElement(to);
            var builder = new Actions(Browser.Instance.GetDriver());
            var dragAndDrop = builder.ClickAndHold(start)
                .Pause(TimeSpan.FromSeconds(5))
                .MoveToElement(end, 100, 100)
                .Pause(TimeSpan.FromSeconds(5))
                .Release(end).Build();
            dragAndDrop.Perform();
        }
        public static void ExecuteJsScript(this By locator, string scriptLine)
        {
            var js = (IJavaScriptExecutor)Browser.Instance.GetDriver();
            js.ExecuteScript(scriptLine, BasePage.WaitForElement(locator));
        }
        public static IList<IWebElement> GetListElements(this By locator)
        {
            return BasePage.WaitForElements(locator);
        }
        public static void DoubleClick(this By from)
        {
            var start = BasePage.WaitForElement(from);
            var builder = new Actions(Browser.Instance.GetDriver());
            builder.DoubleClick(start).Build().Perform();
        }
    }
}