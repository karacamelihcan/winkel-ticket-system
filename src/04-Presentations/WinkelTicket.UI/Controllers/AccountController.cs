using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WinkelTicket.Contract.Request.UserRequests;
using WinkelTicket.Services.Services.UserServices;

namespace WinkelTicket.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;

        public AccountController(ILogger<AccountController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult LogIn(string ReturnUrl)
        {
            if(User.Identity.IsAuthenticated){
                return RedirectToAction("Index","Home");
            }
            TempData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInRequest request){
            if(!ModelState.IsValid){
                ViewBag.IsSuccessfull = false;
                var errors = ModelState.Values.SelectMany(err => err.Errors)
                                              .Select(err => err.ErrorMessage)
                                              .ToList();
                ViewBag.Errors = errors;     
                return View(request);                         
            }
            var result = await _userService.PasswordSignInAsync(request);
            if(!result.IsSuccessfull){
                ViewBag.IsSuccessfull = false;
                ViewBag.Errors = result.Error.Errors.ToList();
                return View(request);
            }
            else{
                if(TempData["ReturnUrl"] != null){
                        return Redirect(TempData["ReturnUrl"].ToString());
                }
                return RedirectToAction("Index","Home");
            }
        }

        public async Task<IActionResult> LogOut()
        {
          await _userService.SignOutAsync();  
          return RedirectToAction("LogIn","Account");
        }

    }
}