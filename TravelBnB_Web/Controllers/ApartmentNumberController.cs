using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TravelBnB_Web.Models;
using TravelBnB_Web.Models.ViewModel;
using TravelBnB_Web.Services.IServices;

namespace TravelBnB_Web.Controllers
{
    public class ApartmentNumberController : Controller
    {
        private readonly IApartmentNumberService _serviceAptNo;
        private readonly IMapper _mapper;
        private readonly IApartmentService _serviceApt;
        public ApartmentNumberController(IApartmentNumberService service, IMapper mapper, IApartmentService serviceApt)
        {
            _mapper = mapper;
            _serviceAptNo = service;
            _serviceApt = serviceApt;
        }

        public async Task<IActionResult> IndexApartmentNumber()
        {
            List<ApartmentNumberDTO> aptNoList = new List<ApartmentNumberDTO>();
            var response = await _serviceAptNo.GetAllAsync<APIResponse>();
            if (aptNoList is not null && response.IsSuccess)
            {
                aptNoList = JsonConvert.DeserializeObject<List<ApartmentNumberDTO>>(Convert.ToString(response.Result));
            }
            return View(aptNoList);
        }
        public async Task<IActionResult> CreateApartmentNumber()
        {
            //usiamo il viewmodel per ottenre gli appartamenti per popolare il menu dropdown
            ViewModel aptList = new();

            var response = await _serviceApt.GetAllAsync<APIResponse>();
            if (response.IsSuccess && response is not null)
            {
                aptList.Apartments = JsonConvert.DeserializeObject<List<ApartmentDTO>>(Convert.ToString(response.Result)).Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()

                });

            }
            return View(aptList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateApartmentNumber(ViewModel model)
        {

            if (ModelState.IsValid)
            {
                var response = await _serviceAptNo.CreateAsync<APIResponse>(model.ApartmentNumberCreateDTO);
                if (response.IsSuccess && response is not null)
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("Errore", response.ErrorMessages.FirstOrDefault());
                    }
                    else
                    {
                        return RedirectToAction(nameof(IndexApartmentNumber));
                    }
                }
            }

            var res = await _serviceApt.GetAllAsync<APIResponse>();
            if (res.IsSuccess && res is not null)
            {
                model.Apartments = JsonConvert.DeserializeObject<List<ApartmentDTO>>(Convert.ToString(res.Result)).Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                });
            }

            return View(model);

            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> UpdateApartmentNumber()
            //{
            //    ViewModel aptList = new();
            //    var response = await _serviceApt.GetAllAsync<APIResponse>();
            //    if(response is not null && response.IsSuccess)
            //    {
            //        aptList = JsonConvert.DeserializeObject<List<ApartmentNumberDTO>>(response.Result).Select( a => new SelectListItem
            //        {
            //            Text = a.
            //        })
            //    }
            //}
        }
    }
}
