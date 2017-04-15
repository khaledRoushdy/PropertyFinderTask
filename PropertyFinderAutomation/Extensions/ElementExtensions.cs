using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PropertyFinderAutomation.Browser;

namespace PropertyFinderAutomation.Extensions
{
    public static class ElementExtensions
    {
        public static void EnterText(this IWebElement element, string text, string elementName)
        {
            element.Clear();
            for (int i = 0; i < text.Length; i++)
            {
                element.SendKeys(text[i].ToString());
            }
        }

        public static void ClickUsingJavaScriptExec(this IWebElement element)
        {
            ((IJavaScriptExecutor)Driver.WebDriver).ExecuteScript("arguments[0].click();", element);
        }

        public static bool IsDisplayed(this IWebElement element, string elementName)
        {
            bool result;
            try
            {
                result = element.Displayed;
                Console.WriteLine(elementName + @" is Displayed.");
            }
            catch (Exception)
            {
                result = false;
                Console.WriteLine(elementName + @" is not Displayed.");
            }
            return result;
        }

        public static void ClickOnIt(this IWebElement element, string elementName)
        {
            element.Click();
        }

        public static void ScrollToElement(this IWebElement element, string elementName)
        {
            ((IJavaScriptExecutor)Driver.WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void SelectByText(this IWebElement element, string text, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText(text);
        }

        public static void SelectByIndex(this IWebElement element, int index, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByIndex(index);
        }

        public static void SelectByValue(this IWebElement element, string text, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByValue(text);
        }

        public static string GetSelectedOption(this IWebElement element, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            string opt = oSelect.SelectedOption.Text;
            return opt;
        }

        public static void WaitForItToBeVisible(By element, int timeOutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(element));
        }

        public static void WaitForItToBeClickable(By element, int timeOutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void DoubleClickOnIt(this IWebElement element)
        {
            Actions action = new Actions(Driver.WebDriver);
            action.DoubleClick(element).Build().Perform();
        }

        public static string GetTextOfIt(this IWebElement element)
        {
            string elementText = "";
            if (element != null)
                elementText = element.Text;

            return elementText;
        }//end method GetTextOfElement
    }
}
