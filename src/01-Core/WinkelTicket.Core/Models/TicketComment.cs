using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinkelTicket.Core.Models
{
    public class TicketComment
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public User Sender { get; set; }
        public ICollection<TicketFile> Files { get; set; } = new List<TicketFile>();
    }
}