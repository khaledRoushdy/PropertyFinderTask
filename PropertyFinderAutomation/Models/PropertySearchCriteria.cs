using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyFinderAutomation.Models
{
    public class PropertySearchCriteria
    {
        public string RentOrBuy { get; set; }
        public string PropertyType { get; set; }
        public string PropertyName { get; set; }
        public string PropertyPeriod { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
        public string MinBed { get; set; }
        public string MaxBed { get; set; }
        public string MinArea { get; set; }
        public string MaxArea { get; set; }
        public string Furnishing { get; set; }
        public string Keywords { get; set; }
    }
}
