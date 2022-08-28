using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinkelTicket.Core.Models;

namespace WinkelTicket.Contract.Request.UserRequests
{
    public class PasswordSignInRequest
    {
        public User user { get; set; }
        public string password { get; set; }
        public bool isPersistent { get; set; }
    }
}