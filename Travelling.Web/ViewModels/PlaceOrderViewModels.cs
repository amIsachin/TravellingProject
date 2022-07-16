using System.Collections.Generic;
using Travelling.Business;

namespace Travelling.Web.ViewModels
{
    //public class PlaceOrderViewModel
    //{
    //    public int BoodingID { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string UserName { get; set; }
    //    public string Email { get; set; }

    //    public int DestinationPlaceID { get; set; }
    //    public string DestinationName { get; set; }
    //    public string DestinationDescription { get; set; }
    //    public decimal? DestinationPrice { get; set; }
    //    public string DestinationImageURL { get; set; }
    //    public City City { get; set; }
    //}

    public class ShowOrderPage
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public decimal? Price { get; set; }   
    }
}