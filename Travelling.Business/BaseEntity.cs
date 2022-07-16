using System.ComponentModel.DataAnnotations;

namespace Travelling.Business
{
    public class BaseEntity
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(1), MaxLength(100)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Minimun length should be 1 and maximum length is 100")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinLength(1), MaxLength(500)]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Minimun length should be 1 and maximum length is 500")]
        public string Description { get; set; }
    }
}
