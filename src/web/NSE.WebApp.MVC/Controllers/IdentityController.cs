﻿using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models.Identity;
using NSE.WebApp.MVC.Services;

namespace NSE.WebApp.MVC.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public IdentityController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        [Route("new-account")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("new-account")]
        public async Task<IActionResult> Register(UserRegistration userRegistration)
        {
            if (!ModelState.IsValid) return View(userRegistration);

            var response = await _authenticationService.RegisterAsync(userRegistration);

            if (false) return View(userRegistration);

            // Realizar login na PPA

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid) return View(userLogin);

            var response = await _authenticationService.LoginAsync(userLogin);

            if (false) return View(userLogin);

            // Realizar login na app

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
