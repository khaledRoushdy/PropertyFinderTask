using NUnit.Framework;
using PropertyFinderAutomation.Models;
using PropertyFinderAutomation.Pages;
using PropertyFinderAutomation.Parser;
using PropertyFinderAutomation.Parser.ExcelColumns;

namespace PropertyFinderTests
{
    [TestFixture]
    public class SearchForApartmentsTests : PropertyFinderBaseTest
    {

        public PropertySearchCriteria GetPropertySearchCriteria(string methodName)
        {
            string rentOrBuy = TestCasesParser.GetValueOf(SearchForApartmentsColumns.RentOrBuy, methodName, GetType().Name);
            string propertyType = TestCasesParser.GetValueOf(SearchForApartmentsColumns.PropertyType, methodName, GetType().Name);
            string propertyName= TestCasesParser.GetValueOf(SearchForApartmentsColumns.PropertyName, methodName, GetType().Name);
            string propertyPeriod = TestCasesParser.GetValueOf(SearchForApartmentsColumns.PropertyPeriod, methodName, GetType().Name);
            string minPrice = TestCasesParser.GetValueOf(SearchForApartmentsColumns.MinPrice, methodName, GetType().Name);
            string maxPrice = TestCasesParser.GetValueOf(SearchForApartmentsColumns.MaxPrice, methodName, GetType().Name);
            string minArea = TestCasesParser.GetValueOf(SearchForApartmentsColumns.MinArea, methodName, GetType().Name);
            string maxArea = TestCasesParser.GetValueOf(SearchForApartmentsColumns.MaxArea, methodName, GetType().Name);
            string minBed = TestCasesParser.GetValueOf(SearchForApartmentsColumns.MinBed, methodName, GetType().Name);
            string maxBed = TestCasesParser.GetValueOf(SearchForApartmentsColumns.MaxBed, methodName, GetType().Name);
            string furnishing = TestCasesParser.GetValueOf(SearchForApartmentsColumns.Furnishing, methodName, GetType().Name);
            string keywords = TestCasesParser.GetValueOf(SearchForApartmentsColumns.Keywords, methodName, GetType().Name);

            PropertySearchCriteria criteria = new PropertySearchCriteria();
            criteria.RentOrBuy = rentOrBuy;
            criteria.PropertyType = propertyType;
            criteria.PropertyName = propertyName;
            criteria.PropertyPeriod = propertyPeriod;
            criteria.MinPrice = minPrice;
            criteria.MaxPrice = maxPrice;
            criteria.MinArea = minArea;
            criteria.MaxArea = maxArea;
            criteria.MinBed = minBed;
            criteria.MaxBed = maxBed;
            criteria.Furnishing = furnishing;
            criteria.Keywords = keywords;

            return criteria;
        }

        [Test]
        public void ShouldSearchForApartmentLeastExpensiveWithTwoBeds()
        {
            //Prepare the data
            PropertySearchCriteria criteria = GetPropertySearchCriteria(TestContext.CurrentContext.Test.MethodName);
            HomePage homePage = new HomePage();
            PropertyPage propertyPage = new PropertyPage();
            //actions
            homePage.FillPropertyCriteria(criteria);
            homePage.SelectlastSearchResult();
            string actualBedRooms= propertyPage.GetBedRooms();
            //verifications
            Assert.AreEqual("The bed rooms number is not correct",criteria.MinBed,actualBedRooms);
        }

    }
}
