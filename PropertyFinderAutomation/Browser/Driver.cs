using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using PropertyFinderAutomation.Extensions;

namespace PropertyFinderAutomation.Browser
{
    public class Driver
    {
        public const string Firefox = "Firefox";
        public const string Chrome = "Chrome";
        public const string IE = "IE";
        public static IWebDriver WebDriver;

        public static IWebDriver GetBrowser(string browserName)
        {
            //WebDriver = null;

            switch (browserName)
            {
                case Driver.Firefox:

                    if (WebDriver == null)
                    {
                        WebDriver = new FirefoxDriver();
                    }
                    break;

                case Driver.IE:

                    if (WebDriver == null)
                    {
                        DesiredCapabilities caps = DesiredCapabilities.InternetExplorer();
                        var options = new InternetExplorerOptions
                        {
                            IgnoreZoomLevel = true,
                            IntroduceInstabilityByIgnoringProtectedModeSettings = true,

                        };

                        options.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true);
                        WebDriver = new InternetExplorerDriver(options)
                        {
                            Url = "https://www.propertyfinder.ae/"
                        };

                    }
                    break;

                case Driver.Chrome:

                    if (WebDriver == null)
                    {
                        WebDriver = new ChromeDriver(@"C:\Users\asus\Downloads");
                        WebDriver.Url = "https://www.propertyfinder.ae/";
                        WebDriver.Manage().Window.Maximize();
                    }
                    break;
            }
            return WebDriver;
        }

        public static void CloseBrowser()
        {
            WebDriver.Quit();
        }
    }
}
