using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinkelTicket.Enumeration.Enums;

namespace WinkelTicket.Core.Dtos
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public string MyProperty { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;    
        public bool isTimeLimited { get; set; }
        public DateOnly? EndDate { get; set; }
        public EnumTicketStatus TicketStatus { get; set; } = EnumTicketStatus.Todo;
        public UserDto Creator { get; set; } 
        public EnumTicketPriority Priority { get; set; } = EnumTicketPriority.Medium;
        public ICollection<UserDto> Assignees { get; set; } = new List<UserDto>();

    }
}