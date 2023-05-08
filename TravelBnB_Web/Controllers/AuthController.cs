﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                //assegniamo i role
                identity.AddClaim(new Claim(ClaimTypes.Name, res.User.Username));
                identity.AddClaim(new Claim(ClaimTypes.Role, res.User.Role));
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

    }
}
