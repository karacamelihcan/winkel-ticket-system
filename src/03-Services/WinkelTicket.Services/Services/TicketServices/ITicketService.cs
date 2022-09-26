using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinkelTicket.Contract.Request.TicketRequests;
using WinkelTicket.Contract.Response;
using WinkelTicket.Core.Dtos;

namespace WinkelTicket.Services.Services.TicketServices
{
    public interface ITicketService
    {
        Task<ServiceResponse<TicketDto>> Add(AddTicketRequest request);
    }
}