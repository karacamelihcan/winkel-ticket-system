using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WinkelTicket.Contract.Request.UserRequests;
using WinkelTicket.Services.Services.UserServices;
using WinkelTicket.UI.Models;

namespace WinkelTicket.UI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _userService.GetAll();
            if(!result.IsSuccessfull){
                ViewBag.IsSuccessfull = false;
                ViewBag.Errors = result.Error.Errors.ToList();
                return View();
            }
            else{
                ViewBag.IsSuccessfull = true;
            }
            return View(result.Data);
        }
        public IActionResult Add()
        {
          return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserRequest request)
        {
            if(!ModelState.IsValid){
                ViewBag.IsSuccessfull = false;
                var errors = ModelState.Values.SelectMany(err => err.Errors)
                                              .Select(err => err.ErrorMessage)
                                              .ToList();
                ViewBag.Errors = errors;     
                return View(request);                         
            }
            var result = await _userService.Add(request);
            if(!result.IsSuccessfull){
                ViewBag.IsSuccessfull = false;
                ViewBag.Errors = result.Error.Errors.ToList();
                return View(request);
            }
            else{
                ViewBag.IsSuccessfull = true;
                ViewBag.Message = "Kullanıcı başarıyla eklenmiştir.";
            }

          return View();
        }
    }
}