using System.Collections.Generic;
using Travelling.Business;

namespace Travelling.Web.ViewModels
{
    public class CountryViewModel
    {
        public string  SearchTerm { get; set; }
        public int PageNo { get; set; }
        public int LastPage { get; set; }
        //public int HasLastPage { get; set; }

        public List<Country> AvailableCountry { get; set; }
    }
}