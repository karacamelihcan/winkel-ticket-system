using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WinkelTicket.Contract.Request.TicketRequests;
using WinkelTicket.Contract.Response;
using WinkelTicket.Core.Dtos;
using WinkelTicket.Core.Models;
using WinkelTicket.Database.Repositories.TicketRepositories;
using WinkelTicket.Database.Repositories.UserRepositories;
using WinkelTicket.Database.UnitOfWorks;

namespace WinkelTicket.Services.Services.TicketServices
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TicketService> _logger;
        private readonly IUserRepository _userRepository;

        public TicketService(ITicketRepository ticketRepository, IUnitOfWork unitOfWork, ILogger<TicketService> logger, IUserRepository userRepository)
        {
            _ticketRepository = ticketRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse<TicketDto>> Add(AddTicketRequest request)
        {
           using (var transaction = await _unitOfWork.BeginTransactionAsync())
           {
                try
                {
                    var ticket = new Ticket(){
                        Title = request.Title,
                        isTimeLimited = request.isTimeLimited == "False" ? false : true,
                        ExpectedEndDate = request.isTimeLimited == "True" ? request.EndDate: (DateOnly?) null,
                        Priority = request.Priority,
                        Description = request.Description
                    };
                    ticket.Creator = await _userRepository.FindUserByIdAsync(request.CreatorId); 

                    foreach (var userId in request.Assignees)
                    {
                        var user = await _userRepository.FindUserByIdAsync(userId);
                        ticket.Assignees.Add(user);
                        user.Tickets.Add(ticket);
                    }


                    await _ticketRepository.AddAsync(ticket);
                    foreach (var user in ticket.Assignees)
                    {
                        await _userRepository.UpdateUserAsync(user);
                    }
                    await _unitOfWork.CommitAsync();
                    await transaction.CommitAsync();

                    return ServiceResponse<TicketDto>.Success();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    await transaction.RollbackAsync();
                    return ServiceResponse<TicketDto>.Fail(ex.Message);
                }
           }
        }
    }
}