using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBnB_API.Models
{
    public class ApartmentNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AptNo { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
    }
}
