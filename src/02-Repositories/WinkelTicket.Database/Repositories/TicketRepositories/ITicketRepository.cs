using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WinkelTicket.Core.Models;

namespace WinkelTicket.Database.Repositories.TicketRepositories
{
    public interface ITicketRepository
    {
        Task<Ticket> GetByIdAsync(Guid Id);
        Task<IEnumerable<Ticket>> GetAll();
        Task<IQueryable<Ticket>> Where(Expression<Func<Ticket,bool>> expression);
        Task AddAsync(Ticket entity);
        void Update(Ticket entity);
        void Delete(Ticket entity);
    }
}