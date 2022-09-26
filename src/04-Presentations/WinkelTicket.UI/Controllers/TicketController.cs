using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WinkelTicket.Contract.Request.TicketRequests;
using WinkelTicket.Enumeration.Enums;
using WinkelTicket.Services.Services.TicketServices;
using WinkelTicket.Services.Services.UserServices;

namespace WinkelTicket.UI.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        private readonly IUserService _userService;
        private readonly ITicketService _ticketService;

        public TicketController(ILogger<TicketController> logger, IUserService userService, ITicketService ticketService)
        {
            _logger = logger;
            _userService = userService;
            _ticketService = ticketService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {
            await InitializeViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTicketRequest request)
        {
            if(!ModelState.IsValid){
                ViewBag.IsSuccessfull = false;
                var errors = ModelState.Values.SelectMany(err => err.Errors)
                                                .Select(err => err.ErrorMessage)
                                                .ToList();
                ViewBag.Errors = errors;     
                
            }
            else{
                request.CreatorId = User.Claims.FirstOrDefault(clm => clm.Type == ClaimTypes.NameIdentifier).Value;
                var result = await _ticketService.Add(request);
            }
            
            await InitializeViewBag();
            return View();
        }







        private async Task InitializeViewBag(){
            ViewBag.isTimeLimitedValues = new SelectList(new List<SelectListItem>{
                new SelectListItem{
                    Value = Boolean.FalseString,
                    Text = "Hayır",
                    Selected = true,
                },
                new SelectListItem{
                    Value = Boolean.TrueString,
                    Text = "Evet",
                },
            },"Value","Text");

            ViewBag.Priority= new SelectList(new List<SelectListItem>{
                new SelectListItem{
                    Value = EnumTicketPriority.Low.ToString(),
                    Text = "Düşük",
                },
                new SelectListItem{
                    Value = EnumTicketPriority.Medium.ToString(),
                    Text = "Orta",
                },
                new SelectListItem{
                    Value = EnumTicketPriority.High.ToString(),
                    Text = "Yüksek",
                },
            },"Value","Text");

            var userList = await _userService.GetUserForTicketAssign();

            ViewBag.UserList = new SelectList(userList.Data,"Id","Name");
        }
    }
}