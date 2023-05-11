using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
               return RedirectToAction("Index","Home");

            }
            return RedirectToAction("Index", "Auth");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRegisterVM model)
        {

            APIResponse response = await _authService.LoginAsync<APIResponse>(model.Login);
            if(response is not null && response.IsSuccess)
            {
                
                LoginResponseDTO res = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(response.Result));
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(res.Token);

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                //assegniamo i role
                identity.AddClaim(new Claim(ClaimTypes.Name, jwt.Claims.FirstOrDefault(u => u.Type == "unique_name").Value));
                identity.AddClaim(new Claim(ClaimTypes.Role, jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

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
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString(StaticData.SessionToken, "");//cancelliamo il token
            return RedirectToAction("Index", "Home");
        }

    }
}
