using System.ComponentModel.DataAnnotations;

namespace TravelBnB_Web.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public int? Mq2 { get; set; }
        public int? Occupancy { get; set; }
        public string? ImageUrl { get; set; }
        public string? Amenity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
