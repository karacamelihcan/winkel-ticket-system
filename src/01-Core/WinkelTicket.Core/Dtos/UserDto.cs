using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinkelTicket.Core.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}