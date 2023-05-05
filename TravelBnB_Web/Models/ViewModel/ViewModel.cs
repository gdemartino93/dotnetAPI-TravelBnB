using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelBnB_Web.Models.ViewModel
{
    public class ViewModel
    {
        public ApartmentNumberCreateDTO ApartmentNumberCreateDTO { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Apartments { get; set; }

        public ViewModel()
        {
            ApartmentNumberCreateDTO = new ApartmentNumberCreateDTO();
        }
    }
}
