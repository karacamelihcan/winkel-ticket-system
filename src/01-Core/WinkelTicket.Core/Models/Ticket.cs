using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinkelTicket.Enumeration.Enums;

namespace WinkelTicket.Core.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;    
        public bool isTimeLimited { get; set; }
        public DateTime EndDate { get; set; }
        public EnumTicketStatus TicketStatus { get; set; } = EnumTicketStatus.Todo;
        public User Creator { get; set; } 
        public EnumTicketPriority Priority { get; set; } = EnumTicketPriority.Medium;
        public List<TicketComment> Comments { get; set; }
        public List<User> Assignees { get; set; }
    }
}