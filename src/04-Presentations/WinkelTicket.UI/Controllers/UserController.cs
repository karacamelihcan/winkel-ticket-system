using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WinkelTicket.UI.Models;

namespace WinkelTicket.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
          return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel request)
        {
          return View();
        }
    }
}