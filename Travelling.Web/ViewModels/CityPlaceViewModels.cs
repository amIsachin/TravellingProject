using System.Collections.Generic;
using Travelling.Business;

namespace Travelling.Web.ViewModels
{
    public class CityPlaceViewModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string ImageURL { get; set; }

        public int cityID { get; set; }
        public List<City> City { get; set; }
    }

}

