using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PropertyFinderAutomation.Extensions
{
    public static class DriverExtensions
    {
        public static bool WaitForJStoLoad(this IWebDriver driver)
        {
            var isDocumentReady = ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");
            return isDocumentReady;
        }

        public static void SwitchToDefaultContent(this IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }

        public static void WaitAndSwitchToFrame(this IWebDriver driver, int timeOutInSecond, By FrameLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSecond));
            WaitForJStoLoad(driver);
            driver = wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt((FrameLocator)));
        }

        public static string ExecuteScriptUsingJs(this IWebDriver driver, string script)
        {
            var x = ((IJavaScriptExecutor)driver).ExecuteScript(script);
            return x.ToString();
        }

        public static void WaitForAjax(this IWebDriver driver, int timeOutInSecond)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSecond));
            wait.Until(d =>
            {
                var javaScriptExecutor = d as IJavaScriptExecutor;
                return javaScriptExecutor != null && (bool)javaScriptExecutor.ExecuteScript("return jQuery.active == 0");
            });
        }

        public static IWebElement InspectElement(this IWebDriver driver, By elementLocator)
        {
            IWebElement element = driver.FindElement(elementLocator);
            return element;
        }

        public static IReadOnlyCollection<IWebElement> InspectElements(this IWebDriver driver, By elementLocator)
        {
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(elementLocator);
            return elements;
        }
        public static void CloseBrowser(this IWebDriver driver)
        {
            driver.Quit();
            driver = null;
        }

        public static IWebElement ScrollToElement(this IWebDriver driver, By elementLocator, int timeOutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            // presence in DOM
            wait.Until(ExpectedConditions.ElementExists(elementLocator));
            IWebElement element = driver.FindElement(elementLocator);
            // scrolling
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element;
        }

        public static IWebElement ScrollToElement(this IWebDriver driver, IWebElement e)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            // scrolling
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", e);
            return e;
        }



        public static void SwitchToAnotherWindowHandle(this IWebDriver driver, string winHandleBefore)
        {
            // Switch to new window opened
            foreach (string winHandle in driver.WindowHandles)
            {
                if (!winHandle.Equals(winHandleBefore))
                    driver.SwitchTo().Window(winHandle);
            }
        }

        public static void MaximizeBrowser(this IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }
    }
}
