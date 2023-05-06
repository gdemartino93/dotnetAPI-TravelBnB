using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelBnB_Web.Models.ViewModel
{
    public class ApartmentNumberDeleteVM
    {
        public ApartmentNumberDTO ApartmentNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Apartments { get; set; }
    }
}
