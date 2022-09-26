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
        public string FullName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Avatar { get; set; }
        
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}