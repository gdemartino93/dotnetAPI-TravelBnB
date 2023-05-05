using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBnB_Web.Models
{
    public class ApartmentNumberCreateDTO
    {
        [Required(ErrorMessage = "Il numero della camera è obbligatorio")]
        public int AptNo { get; set; }
        public string SpecialDetails { get; set; }
        [Required(ErrorMessage ="Seleziona un appartamento")]
        public int ApartmentId { get; set; }



    }
}
  