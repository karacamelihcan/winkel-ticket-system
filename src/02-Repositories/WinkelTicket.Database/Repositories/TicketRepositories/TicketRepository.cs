using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WinkelTicket.Core.Models;
using WinkelTicket.Database.Context;

namespace WinkelTicket.Database.Repositories.TicketRepositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly WinkelDbContext _context;

        public TicketRepository(WinkelDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Ticket entity)
        {
            await _context.Tickets.AddAsync(entity);
        }

        public void Delete(Ticket entity)
        {
            _context.Tickets.Remove(entity);
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            var result = await _context.Tickets.Include(ticket => ticket.Assignees)
                                               .Include(ticket => ticket.Comments)
                                               .Include(ticket => ticket.Creator)
                                               .OrderBy(ticket => ticket.StartDate)
                                               .ToListAsync();
            return result;
        }


        public async Task<Ticket> GetByIdAsync(Guid Id)
        {
            var result = await _context.Tickets.FirstOrDefaultAsync(ticket => ticket.Id == Id);
            return result;
        }

        public void Update(Ticket entity)
        {
            _context.Tickets.Update(entity);
        }

        public async Task<IQueryable<Ticket>> Where(Expression<Func<Ticket, bool>> expression)
        {
            var result = _context.Tickets.Where(expression);
            return result;
        }
    }
}