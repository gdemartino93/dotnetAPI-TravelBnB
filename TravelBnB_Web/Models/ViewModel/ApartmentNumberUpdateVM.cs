using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelBnB_Web.Models.ViewModel
{
    public class ApartmentNumberUpdateVM
    {
        public ApartmentNumberUpdateDTO ApartmentNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Apartments { get; set; }
        public ApartmentNumberUpdateVM()
        {
            ApartmentNumber = new ApartmentNumberUpdateDTO();
        }
    }
}
