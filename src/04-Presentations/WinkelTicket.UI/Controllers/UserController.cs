using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WinkelTicket.Contract.Request.UserRequests;
using WinkelTicket.Services.Services.UserServices;
using WinkelTicket.UI.Models;

namespace WinkelTicket.UI.Controllers
{
    [Authorize(Policy = "AdminOnlyPolicy")]
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
        public async Task<IActionResult> Add()
        {
            var roles = await _userService.GetRoles();  
            var roleList = new SelectList(roles.Data,"Id","Name");
            ViewBag.Roles = roleList;
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
            }
            var result = await _userService.Add(request);
            if(!result.IsSuccessfull){
                ViewBag.IsSuccessfull = false;
                ViewBag.Errors = result.Error.Errors.ToList();
            }
            else{
                ViewBag.IsSuccessfull = true;
                ViewBag.Message = "Kullan??c?? ba??ar??yla eklenmi??tir.";
            }
            var roles = await _userService.GetRoles();  
            var roleList = new SelectList(roles.Data,"Id","Name");
            ViewBag.Roles = roleList;
            
            return View(request);
        }

        public async Task<IActionResult> Edit(string userId)
        {
            var result = await _userService.GetUserByIdAsync(userId);
            if(result.IsSuccessfull){
                var viewData = new UpdateUserRequest(){
                    Id = result.Data.Id,
                    Name = result.Data.Name,
                    Surname = result.Data.Surname,
                    Email = result.Data.Email
                };
                var roles = await _userService.GetRoles();  
                var roleList = new SelectList(roles.Data,"Id","Name");
                TempData["UserRole"] = result.Data.Role;
                foreach (var role in roleList)
                {
                    if(role.Text == result.Data.Role){
                        role.Selected = true;
                    }
                }
                ViewBag.Roles = roleList;
                return View(viewData);
            }
            else{
                return RedirectToAction("Error","Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserRequest request)
        {   
            if(!ModelState.IsValid){
                ViewBag.IsSuccessfull = false;
                var errors = ModelState.Values.SelectMany(err => err.Errors)
                                                .Select(err => err.ErrorMessage)
                                                .ToList();
                ViewBag.Errors = errors;     
                return View(request);                         
            }
            var result = await _userService.UpdateUserAsync(request);
            if(!result.IsSuccessfull){
                ViewBag.IsSuccessfull = false;
                ViewBag.Errors = result.Error.Errors.ToList();
                return View(request);
            }
            else{
                ViewBag.IsSuccessfull = true;
                ViewBag.Message = "Kullan??c?? ba??ar??yla g??ncellenmi??tir";
            }
            var roles = await _userService.GetRoles();  
            var roleList = new SelectList(roles.Data,"Id","Name");
            foreach (var role in roleList)
                {
                    if(role.Text == TempData["UserRole"].ToString()){
                        role.Selected = true;
                    }
                }

            ViewBag.Roles = roleList;
          return View(request);
        }
    }
}