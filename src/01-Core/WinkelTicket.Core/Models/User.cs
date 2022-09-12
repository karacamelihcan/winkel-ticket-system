using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WinkelTicket.Core.Models 
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        
        public List<Ticket> Tickets { get; set; }
    }
}