using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelBnB_Web.Models;
using TravelBnB_Web.Models.Dto;
using TravelBnB_Web.Services.IServices;

namespace TravelBnB_Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly string SessionToken = "JwtToken";
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
        public async Task<IActionResult> Register(RegisterRequestDTO model)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestDTO model)
        {
            APIResponse response = await _authService.LoginAsync<APIResponse>(model);
            if(response is not null && response.IsSuccess)
            {
                LoginResponseDTO res = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(response.Result));
                HttpContext.Session.SetString(SessionToken, res.Token);
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
