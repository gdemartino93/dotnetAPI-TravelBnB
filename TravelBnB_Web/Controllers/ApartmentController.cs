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
        public async Task<IActionResult> CreateApartment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateApartment(ApartmentCreateDTO apartmentCreateDTO)
        {
            if(ModelState.IsValid)
            {
                var response = await _service.CreateAsync<APIResponse>(apartmentCreateDTO);
                if(response.IsSuccess && response is not null)
                {
                    return RedirectToAction(nameof(IndexApartment));
                }
            }
            return View(apartmentCreateDTO);
        }
        public async Task<IActionResult> DeleteApartment(int id)
        {
            var response = await _service.GetAsync<APIResponse>(id);

            if (response is not null && response.IsSuccess)
            {
                ApartmentDTO model = JsonConvert.DeserializeObject<ApartmentDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> DeleteApartment(ApartmentDTO model)
        {
            var response = await _service.DeleteAsync<APIResponse>(model.Id);
            if(response.IsSuccess && response is not null)
            {
                return RedirectToAction(nameof(IndexApartment));
            }

            return View(model);
        }
    }
}
