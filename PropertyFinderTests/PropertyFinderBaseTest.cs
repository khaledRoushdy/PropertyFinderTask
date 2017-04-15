using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PropertyFinderAutomation.Browser;

namespace PropertyFinderTests
{
    public class PropertyFinderBaseTest
    {
        [SetUp]
        public void Setup()
        {
            Driver.GetBrowser("Chrome"); 
        }

        [TearDown]
        public void TearDown()
        {
            Driver.CloseBrowser();
        }
    }
}
