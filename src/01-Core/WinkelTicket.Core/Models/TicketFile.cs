using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinkelTicket.Core.Models
{
    public class TicketFile
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}