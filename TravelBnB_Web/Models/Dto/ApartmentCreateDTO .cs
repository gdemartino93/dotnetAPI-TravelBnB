using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBnB_Web.Models
{
    public class ApartmentCreateDTO
    {
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [MaxLength(30)]
        public string Name { get; set; }
        public string? Details { get; set; }
        [Required(ErrorMessage = "Il prezzo è obbligatorio")]
        public double? Rate { get; set; }
        public int? Mq2 { get; set; }
        public int? Occupancy { get; set; }
        public string? ImageUrl { get; set; }
        public string? Amenity { get; set; }

    }
}
  