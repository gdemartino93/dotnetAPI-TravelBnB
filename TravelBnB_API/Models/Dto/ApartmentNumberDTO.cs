using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBnB_API.Models.Dto
{
    public class ApartmentNumberDTO
    {
        [Required]
        public int AptNo { get; set; }
        public string SpecialDetails { get; set; }

    }
}
  