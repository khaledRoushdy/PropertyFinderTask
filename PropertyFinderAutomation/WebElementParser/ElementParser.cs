using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using Newtonsoft.Json;

namespace PropertyFinderAutomation.WebElementParser
{
    public class ElementParser
    {
        public Dictionary<string, By> Elements { set; get; }

        public ElementParser(string fileName)
        {
            Elements = new Dictionary<string, By>();
            var webElements = DeserializeWebElements(fileName);
            AddElementsToDictionary(webElements);
        }

        public By GetElementByName(string name)
        {
            return Elements[name];
        }

        private void AddElementsToDictionary(IEnumerable<WebElement> webElementsItems)
        {
            foreach (var element in webElementsItems)
            {
                var locator = LocatorFactory.CreateLocator(element);
                Elements.Add(element.Name, locator);
            }
        }

        private static IEnumerable<WebElement> DeserializeWebElements(string fileName)
        {
            var directory = AppDomain.CurrentDomain.RelativeSearchPath ??
                            AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(directory, "ObjectRepository", fileName);
            var file = File.ReadAllText(filePath);
            var elements = JsonConvert.DeserializeObject<List<WebElement>>(file);
            return elements;
        }

    }
}

