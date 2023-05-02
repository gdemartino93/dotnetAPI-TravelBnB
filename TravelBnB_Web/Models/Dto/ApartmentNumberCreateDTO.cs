using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBnB_Web.Models
{
    public class ApartmentNumberCreateDTO
    {
        [Required]
        public int AptNo { get; set; }
        public string SpecialDetails { get; set; }
        [Required]
        public int ApartmentId { get; set; }



    }
}
  