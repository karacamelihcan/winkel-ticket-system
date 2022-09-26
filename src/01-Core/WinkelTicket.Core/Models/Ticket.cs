using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinkelTicket.Enumeration.Enums;

namespace WinkelTicket.Core.Models
{
    public class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;    
        public bool isTimeLimited { get; set; }
        public DateOnly? ExpectedEndDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public EnumTicketStatus TicketStatus { get; set; } = EnumTicketStatus.Todo;
        public User Creator { get; set; } 
        public EnumTicketPriority Priority { get; set; } = EnumTicketPriority.Medium;
        public ICollection<TicketComment> Comments { get; set; } = new List<TicketComment>();
        public ICollection<User> Assignees { get; set; } = new List<User>();
    }
}