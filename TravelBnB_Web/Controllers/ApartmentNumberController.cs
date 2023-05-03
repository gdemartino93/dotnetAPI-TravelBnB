using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelBnB_Web.Models;
using TravelBnB_Web.Services.IServices;

namespace TravelBnB_Web.Controllers
{
    public class ApartmentNumberController : Controller
    {
        private readonly IApartmentNumberService _service;
        private readonly IMapper _mapper;
        public ApartmentNumberController(IApartmentNumberService service,IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        
        public async Task<IActionResult> IndexApartmentNumber()
        {
            List<ApartmentNumberDTO> aptNoList = new List<ApartmentNumberDTO>();
            var response = await _service.GetAllAsync<APIResponse>();
            if(aptNoList is not null && response.IsSuccess)
            {
                aptNoList = JsonConvert.DeserializeObject<List<ApartmentNumberDTO>>(Convert.ToString(response.Result));
            }
            return View(aptNoList);
        }
    }
}
