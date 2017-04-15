using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PropertyFinderAutomation.Extensions;
using PropertyFinderAutomation.WebElementParser;

namespace PropertyFinderAutomation.Pages
{
    public class PropertyPage
    {
        private readonly ElementParser _parser = new ElementParser("PropertyPage.json");


        private IWebElement BedRooms()
        {
            By bedRoomsLocator = _parser.GetElementByName("Bed Rooms");
            var bedRooms = Browser.Driver.WebDriver.InspectElement(bedRoomsLocator);
            return bedRooms;
        }

        public string GetBedRooms()
        {
            string bedRooms = BedRooms().Text;
            return bedRooms;
        }
    }
}
