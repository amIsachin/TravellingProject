using System.ComponentModel.DataAnnotations;

namespace Travelling.Business
{
    public class Place : BaseEntity
    {
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "City is Mendatory")]
        public virtual City City { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public string ImageURL { get; set; }
    }
}
