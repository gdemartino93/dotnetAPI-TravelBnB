using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TravelBnB_Utility;
using TravelBnB_Web.Models;
using TravelBnB_Web.Services.IServices;

namespace TravelBnB_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IApartmentService _apartmentService;

        public HomeController(IApartmentService apartmentService,IMapper mapper)
        {
            _apartmentService = apartmentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ApartmentDTO> listApts = new List<ApartmentDTO>();
            var response = await _apartmentService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticData.SessionToken));
            if(response is not null && response.IsSuccess)
            {
                listApts = JsonConvert.DeserializeObject<List<ApartmentDTO>>(Convert.ToString(response.Result));
            }
            return View(listApts);
        }

    }
}