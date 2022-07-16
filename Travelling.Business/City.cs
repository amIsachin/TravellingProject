using System.ComponentModel.DataAnnotations;

namespace Travelling.Business
{
    public class City : BaseEntity
    {
        [Required(ErrorMessage = "Country is required")]
        public virtual Country Country { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public string ImageURL { get; set; }
        //public List<Place> Places { get; set; }
    }
}
