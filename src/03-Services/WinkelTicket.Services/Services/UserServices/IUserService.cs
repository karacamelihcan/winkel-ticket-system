using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WinkelTicket.Contract.Request.UserRequests;
using WinkelTicket.Contract.Response;
using WinkelTicket.Core.Dtos;

namespace WinkelTicket.Services.Services.UserServices
{
    public interface IUserService
    {
        Task<ServiceResponse<IdentityResult>> Add(AddUserRequest request);
        Task<ServiceResponse<List<UserDto>>> GetAll();
        Task<ServiceResponse<SignInResult>> PasswordSignInAsync(LogInRequest request);
        Task<ServiceResponse<EmptyModel>> SignOutAsync();


    }
}