using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelBnB_Utility;
using TravelBnB_Web.Models;
using TravelBnB_Web.Models.Dto;
using TravelBnB_Web.Models.ViewModel;
using TravelBnB_Web.Services.IServices;

namespace TravelBnB_Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginRegisterVM model)
        {
            APIResponse response = await _authService.RegisterAsync<APIResponse>(model.Register);
            if(response is not null && response.IsSuccess)
            {
                RegisterRequestDTO res = JsonConvert.DeserializeObject<RegisterRequestDTO>(Convert.ToString(response.Result));

            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRegisterVM model)
        {

            APIResponse response = await _authService.LoginAsync<APIResponse>(model.Login);
            if(response is not null && response.IsSuccess)
            {
                
                LoginResponseDTO res = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(response.Result));
                HttpContext.Session.SetString(StaticData.SessionToken, res.Token);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("error",response.ErrorMessages.FirstOrDefault());
                return View(model);
            }
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
