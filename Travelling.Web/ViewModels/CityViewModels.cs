using System.Collections.Generic;
using Travelling.Business;

namespace Travelling.Web.ViewModels
{
    public class CityViewModels
    {
    }

    public class CitySearchViewModel
    {
        public int PageNo { get; set; }
        public string SearchTerm { get; set; }
        public List<City> City { get; set; }

        public Pager Pager { get; set; }
    }

    public class CityViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        //public int DropDownID { get; set; }

        public int countryID { get; set; }
        public List<Country> Country { get; set; }
    }

    public class CityCountryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public int countryID { get; set; }
    }
}