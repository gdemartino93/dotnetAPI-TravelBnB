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
            ApartmentNumberCreateVM aptList = new();

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
        public async Task<IActionResult> CreateApartmentNumber(ApartmentNumberCreateVM model)
        {

            if (ModelState.IsValid)
            {
                var response = await _serviceAptNo.CreateAsync<APIResponse>(model.ApartmentNumberCreateDTO);
                if (response.IsSuccess && response is not null)
                {

                    try
                    {
                        ModelState.AddModelError("Errore", response.ErrorMessages.FirstOrDefault());
                    }
                    catch (Exception)
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

        }

        public async Task<IActionResult> UpdateApartmentNumber(int aptNo)
        {
            //usiamo il viewmodel per ottenre gli appartamenti per popolare il menu dropdown
            ApartmentNumberUpdateVM aptList = new();
            var response = await _serviceAptNo.GetAsync<APIResponse>(aptNo);
            if(response is not null && response.IsSuccess)
            {
                ApartmentNumberDTO apartment = JsonConvert.DeserializeObject<ApartmentNumberDTO>(Convert.ToString(response.Result));
                aptList.ApartmentNumber = _mapper.Map<ApartmentNumberUpdateDTO>(apartment);
            }

            var res = await _serviceApt.GetAllAsync<APIResponse>();
            if (res.IsSuccess && res is not null)
            {
                aptList.Apartments = JsonConvert.DeserializeObject<List<ApartmentDTO>>(Convert.ToString(res.Result)).Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()

                });
                return View(aptList);

            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateApartment(ApartmentNumberUpdateVM apartment)
        {
            if(ModelState.IsValid)
            {
                var response = await _serviceAptNo.UpdateAsync<APIResponse>(apartment.ApartmentNumber);
                if(response is not null && response.IsSuccess )
                {
                    return RedirectToAction(nameof(IndexApartmentNumber));
                }
                else
                {
                    if(response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("Error", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }
            //per il dropdrown con la lista degli apt
            var res = await _serviceApt.GetAllAsync<APIResponse>();
            if(res is not null && res.IsSuccess )
            {
                apartment.Apartments = JsonConvert.DeserializeObject<List<ApartmentDTO>>(Convert.ToString(res.Result)).Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                });
            }
            return View(apartment);
        }

        public async Task<IActionResult> DeleteApartmentNumber(int aptNo)
        {
            ApartmentNumberDeleteVM aptVM = new(); // dichiariamo il model che andremo ad usare nella vista
            var response = await _serviceAptNo.GetAsync<APIResponse>(aptNo);
            if (response is not null && response.IsSuccess)
            {
                ApartmentNumberDTO apartment = JsonConvert.DeserializeObject<ApartmentNumberDTO>(Convert.ToString(response.Result));
                aptVM.ApartmentNumber = apartment;
            }
            response = await _serviceApt.GetAllAsync<APIResponse>();
            if(response is not null && response.IsSuccess)
            {
                //prendiamo la lista degli appartemnti e popoliamo il dropdown per la select
                aptVM.Apartments = JsonConvert.DeserializeObject<List<ApartmentDTO>>(Convert.ToString(response.Result)).Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                });
                return View(aptVM);
            }
            
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteApartment(ApartmentNumberDeleteVM apartment)
        {
            var response = await _serviceAptNo.DeleteAsync<APIResponse>(apartment.ApartmentNumber.AptNo);
            if( response is not null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexApartmentNumber));
            }
            return View(apartment);
        }
    }
}
