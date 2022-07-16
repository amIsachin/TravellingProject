using System.ComponentModel.DataAnnotations;

namespace Travelling.Business
{
    public class PlaceOrder
    {
        [Key]
        public int BoodingID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public int DestinationPlaceID { get; set; }
        public string DestinationName { get; set; }
        public string DestinationDescription { get; set; }
        public decimal? DestinationPrice { get; set; }
        public string DestinationImageURL { get; set; }
        public virtual City City { get; set; }
    } 
}