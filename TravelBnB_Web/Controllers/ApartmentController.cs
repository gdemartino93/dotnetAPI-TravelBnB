using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelBnB_Web.Models;
using TravelBnB_Web.Services;
using TravelBnB_Web.Services.IServices;

namespace TravelBnB_Web.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _service;
        private readonly IMapper _mapper;

        public ApartmentController(IMapper mapper,IApartmentService service)
        {
            _mapper = mapper;
            _service = service;
        }
        public async Task<IActionResult> IndexApartment()
        {
            List<ApartmentDTO> listApt = new List<ApartmentDTO>();
            var response = await _service.GetAllAsync<APIResponse>();
            if(listApt is not null && response.IsSuccess)
            {
                listApt = JsonConvert.DeserializeObject<List<ApartmentDTO>>(Convert.ToString(response.Result));
            }
            return View(listApt);
        }
    }
}
