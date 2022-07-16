using System.ComponentModel.DataAnnotations;

namespace Travelling.Business
{
    public class Country : BaseEntity
    {
        [Required(ErrorMessage = "Image is required")]
        public string ImageURL { get; set; }
        //--> public List<City> Cities { get; set; }
    }
}
