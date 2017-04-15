using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PropertyFinderAutomation.Extensions;
using PropertyFinderAutomation.Models;
using PropertyFinderAutomation.WebElementParser;

namespace PropertyFinderAutomation.Pages
{
    public class HomePage
    {
        private readonly ElementParser _parser = new ElementParser("HomePage.json");


        private IWebElement BuyOrRentSelector()
        {
            By buyOrRentSelectorLocator = _parser.GetElementByName("Buy Or Rent Selector");
            var buyOrRentElement = Browser.Driver.WebDriver.InspectElement(buyOrRentSelectorLocator);
            return buyOrRentElement; 
        }

        private IReadOnlyCollection<IWebElement> BuyOrRent()
        {
            By buyOrRentLocator = _parser.GetElementByName("Buy Or Rent");
            var buyOrRentElement = Browser.Driver.WebDriver.InspectElements(buyOrRentLocator);
            return buyOrRentElement;
        }

        private IWebElement PropertyName()
        {
            By propertyNameLocator = _parser.GetElementByName("Property Name");
            IWebElement propertyName = Browser.Driver.WebDriver.InspectElement(propertyNameLocator);
            return propertyName;
        }

        private IWebElement PropertyTypeSelector()
        {
            By propertyLocator = _parser.GetElementByName("Property Type Selector");
            var propertyTpe = Browser.Driver.WebDriver.InspectElement(propertyLocator);
            return propertyTpe;
        }

        private IReadOnlyCollection<IWebElement> PropertyType()
        {
            By propertyLocator = _parser.GetElementByName("Property Type");
            var propertyTpe = Browser.Driver.WebDriver.InspectElements(propertyLocator);
            return propertyTpe;
        }

        private IWebElement PropertyPeriodSelector()
        {
            By propertyLocator = _parser.GetElementByName("Property Period Selector");
            var propertyTpePeriod = Browser.Driver.WebDriver.InspectElement(propertyLocator);
            return propertyTpePeriod;
        }

        private IReadOnlyCollection<IWebElement> PropertyPeriod()
        {
            By propertyPeriodLocator = _parser.GetElementByName("Property Period");
            var propertyPeriod = Browser.Driver.WebDriver.InspectElements(propertyPeriodLocator);
            return propertyPeriod;
        }

        private IWebElement MinPriceSelector()
        {
            By minPriceLocator = _parser.GetElementByName("Min Price Selector");
            var minPriceSelector = Browser.Driver.WebDriver.InspectElement(minPriceLocator);
            return minPriceSelector;
        }

        private IReadOnlyCollection<IWebElement> MinPrice()
        {
            By minPriceLocator = _parser.GetElementByName("Min Price");
            var minPrice = Browser.Driver.WebDriver.InspectElements(minPriceLocator);
            return minPrice;
        }

        private IWebElement MaxPriceSelector()
        {
            By maxPriceLocator = _parser.GetElementByName("Max Price Selector");
            var maxPriceSelector = Browser.Driver.WebDriver.InspectElement(maxPriceLocator);
            return maxPriceSelector;
        }

        private IReadOnlyCollection<IWebElement> MaxPrice()
        {
            By maxPriceLocator = _parser.GetElementByName("Max Price");
            var maxPrice = Browser.Driver.WebDriver.InspectElements(maxPriceLocator);
            return maxPrice;
        }

        private IWebElement MinBedSelector()
        {
            By minBedLocator = _parser.GetElementByName("Min Bed Selector");
            var minBedSelector = Browser.Driver.WebDriver.InspectElement(minBedLocator);
            return minBedSelector;
        }

        private IReadOnlyCollection<IWebElement> MinBed()
        {
            By minBedLocator = _parser.GetElementByName("Min Bed");
            var minBed = Browser.Driver.WebDriver.InspectElements(minBedLocator);
            return minBed;
        }

        private IWebElement MaxBedSelector()
        {
            By maxBedLocator = _parser.GetElementByName("Max Bed Selector");
            var maxBedSelector = Browser.Driver.WebDriver.InspectElement(maxBedLocator);
            return maxBedSelector;
        }

        private IReadOnlyCollection<IWebElement> MaxBed()
        {
            By maxBedLocator = _parser.GetElementByName("Max Bed");
            ElementExtensions.WaitForItToBeVisible(maxBedLocator,10);
            var maxBed = Browser.Driver.WebDriver.InspectElements(maxBedLocator);
            return maxBed;
        }

        private IWebElement MinAreaSelector()
        {
            By minAreaLocator = _parser.GetElementByName("Min Area Selector");
            var minAreaSelector = Browser.Driver.WebDriver.InspectElement(minAreaLocator);
            return minAreaSelector;
        }

        private IReadOnlyCollection<IWebElement> MinArea()
        {
            By minAreaLocator = _parser.GetElementByName("Min Area");
            var minArea = Browser.Driver.WebDriver.InspectElements(minAreaLocator);
            return minArea;
        }

        private IWebElement MaxAreaSelector()
        {
            By maxAreaLocator = _parser.GetElementByName("Max Area Selector");
            var maxAreaSelector = Browser.Driver.WebDriver.InspectElement(maxAreaLocator);
            return maxAreaSelector;
        }

        private IReadOnlyCollection<IWebElement> MaxArea()
        {
            By maxAreaLocator = _parser.GetElementByName("Max Area");
            var maxArea = Browser.Driver.WebDriver.InspectElements(maxAreaLocator);
            return maxArea;
        }

        private IWebElement FurnishingSelector()
        {
            By furnishingLocator = _parser.GetElementByName("Furnishing Selector");
            var furnishingSelector = Browser.Driver.WebDriver.InspectElement(furnishingLocator);
            return furnishingSelector;
        }

        private IReadOnlyCollection<IWebElement> Furnishing()
        {
            By furnishingLocator = _parser.GetElementByName("Furnishing");
            var furnishing = Browser.Driver.WebDriver.InspectElements(furnishingLocator);
            return furnishing;
        }

        private IWebElement Keywords()
        {
            By keywordsLocator = _parser.GetElementByName("Keywords");
            IWebElement keywords = Browser.Driver.WebDriver.InspectElement(keywordsLocator);
            return keywords;
        }

        private IWebElement Search()
        {
            By searchLocator = _parser.GetElementByName("Search");
            IWebElement search = Browser.Driver.WebDriver.InspectElement(searchLocator);
            return search;
        }

        private IReadOnlyCollection<IWebElement> SearchResults()
        {
            By searchResultsLocator = _parser.GetElementByName("Search Results");
            var searchResults = Browser.Driver.WebDriver.InspectElements(searchResultsLocator);
            return searchResults;
        }

        public void SelectSearch()
        {
            IWebElement searchElement = Search();
            searchElement.ClickOnIt("search");
        }

        public void FillPropertyCriteria(PropertySearchCriteria criteria)
        {
            if (!string.IsNullOrEmpty(criteria.RentOrBuy))
            {
                BuyOrRentSelector().ClickOnIt("Buy or Rent selector"); 
                IReadOnlyCollection<IWebElement> elements = BuyOrRent();
                Utilities.Utilities.SelectElementInList(elements,criteria.RentOrBuy);
            }

            if (!string.IsNullOrEmpty(criteria.PropertyName))
            {
                PropertyName().EnterText(criteria.PropertyName, "Property Name");
                PropertyName().SendKeys(Keys.Enter);
                
            }
            if (!string.IsNullOrEmpty(criteria.PropertyType))
            {
                PropertyTypeSelector().ClickOnIt("Property type selector");
                IReadOnlyCollection<IWebElement> elements = PropertyType();
                Utilities.Utilities.SelectElementInList(elements, criteria.PropertyType);
            }
            if (!string.IsNullOrEmpty(criteria.PropertyPeriod))
            {
                PropertyPeriodSelector().ClickOnIt("Property Period Selector");
                IReadOnlyCollection<IWebElement> elements = PropertyPeriod();
                Utilities.Utilities.SelectElementInList(elements, criteria.PropertyPeriod);
            }
            if (!string.IsNullOrEmpty(criteria.MinPrice))
            {
                MinPriceSelector().ClickOnIt("Min Price Selector");
                IReadOnlyCollection<IWebElement> elements = MinPrice();
                Utilities.Utilities.SelectElementInList(elements, criteria.MinPrice);
            }
            if (!string.IsNullOrEmpty(criteria.MaxPrice))
            {
                MaxPriceSelector().ClickOnIt("Max Price Selector");
                IReadOnlyCollection<IWebElement> elements = MaxPrice();
                Utilities.Utilities.SelectElementInList(elements, criteria.MaxPrice);
            }
            if (!string.IsNullOrEmpty(criteria.MinBed))
            {
                MinBedSelector().ClickOnIt("Min Bed Selector");
                IReadOnlyCollection<IWebElement> elements = MinBed();
                Utilities.Utilities.SelectElementInList(elements, criteria.MinBed);
            }
            if (!string.IsNullOrEmpty(criteria.MaxBed))
            {
                MaxBedSelector().ClickOnIt("Max Bed Selector");
                IReadOnlyCollection<IWebElement> elements = MaxBed();
                Utilities.Utilities.SelectElementInList(elements, criteria.MaxBed);
            }
            if (!string.IsNullOrEmpty(criteria.MinArea))
            {
                MinAreaSelector().ClickOnIt("Min Area Selector");
                IReadOnlyCollection<IWebElement> elements = MinArea();
                Utilities.Utilities.SelectElementInList(elements, criteria.MinArea);
            }
            if (!string.IsNullOrEmpty(criteria.MaxArea))
            {
                MaxAreaSelector().ClickOnIt("Max Area Selector");
                IReadOnlyCollection<IWebElement> elements = MaxArea();
                Utilities.Utilities.SelectElementInList(elements, criteria.MaxArea);
            }
            if (!string.IsNullOrEmpty(criteria.Furnishing))
            {
                FurnishingSelector().ClickOnIt("Furnishing Selector");
                IReadOnlyCollection<IWebElement> elements = Furnishing();
                Utilities.Utilities.SelectElementInList(elements, criteria.Furnishing);
            }
            if (!string.IsNullOrEmpty(criteria.Keywords))
            {
                Keywords().EnterText(criteria.Keywords, "Keywords");
            }

            SelectSearch();
        }


        public void SelectlastSearchResult()
        {
            var allSearchResults = SearchResults();
            Browser.Driver.WebDriver.ScrollToElement(allSearchResults.ElementAt(allSearchResults.Count - 1));
            allSearchResults.ElementAt(allSearchResults.Count-1).Click();
        }


     

    }
}
