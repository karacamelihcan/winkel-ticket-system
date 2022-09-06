using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WinkelTicket.Contract.Request.UserRequests;
using WinkelTicket.Contract.Response;
using WinkelTicket.Core.Dtos;
using WinkelTicket.Core.Models;
using WinkelTicket.Database.Repositories.UserRepositories;
using WinkelTicket.Database.UnitOfWorks;

namespace WinkelTicket.Services.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ServiceResponse<IdentityResult>> Add(AddUserRequest request)
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    var user = new User(){
                        Name = request.Name,
                        Surname = request.Surname,
                        Email = request.Email,
                        UserName = request.Email,
                    };
                    var addUserResult = await _userRepository.AddUserAsync(user,request.Password);
                    if(addUserResult.Succeeded){
                        await _unitOfWork.CommitAsync();
                        await transaction.CommitAsync();
                        return ServiceResponse<IdentityResult>.Success();
                    }
                    else{
                        var errors = addUserResult.Errors.Select(err => err.Description).ToList();
                        return ServiceResponse<IdentityResult>.Fail(new ErrorResponse(errors));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    await transaction.RollbackAsync();
                    return ServiceResponse<IdentityResult>.Fail(ex.Message);
                }
            }
        }

        public async Task<ServiceResponse<List<UserDto>>> GetAll()
        {
            try
            {
                var userList = await _userRepository.GetAll();
                if(!userList.Any()){
                    var errMsg = "Kayıtlı herhangi bir kullanıcı bulunmamaktadır";
                    return ServiceResponse<List<UserDto>>.Fail(errMsg);
                }
                else{
                    var result = new List<UserDto>();
                    foreach (var user in userList)
                    {
                        result.Add(
                            new UserDto(){
                                Id = user.Id,
                                Name = user.Name,
                                Surname = user.Surname,
                                Email = user.Email
                            }
                        );
                    }
                    return ServiceResponse<List<UserDto>>.Success(result);
                }
            }
            catch (System.Exception ex)
            {
               _logger.LogError(ex.Message);
                return ServiceResponse<List<UserDto>>.Fail(ex.Message);
            }
        }

        public async Task<ServiceResponse<SignInResult>> PasswordSignInAsync(LogInRequest request)
        {
            try
            {
                var user = await _userRepository.FindUserByEmailAsync(request.Email);
                if(user == null){
                    return ServiceResponse<SignInResult>.Fail("Geçersiz email veya şifre");
                }
                if(await _userRepository.IsLockedOutAsync(user)){
                    return ServiceResponse<SignInResult>.Fail("Hesabınız geçici süreliğine askıya alınmıştır. Daha sonra tekrar deneyin.");
                }
                await _userRepository.SignOutAsync();
                var result = await _userRepository.PasswordSignInAsync(new PasswordSignInRequest(){
                    user = user,
                    password = request.Password,
                    isPersistent = request.isPersistent
                });

                if(result.Succeeded){
                    await _userRepository.ResetAccessFailedCountAsync(user);
                    return ServiceResponse<SignInResult>.Success(result);
                }
                else
                {
                    await _userRepository.AccessFailedAsync(user);

                    var failCount= await _userRepository.GetAccessFailedCountAsync(user);
                    if(failCount == 3){
                        await _userRepository.SetLockoutEndDateAsync(user);
                        return ServiceResponse<SignInResult>.Fail("3 defa başarısız giriş sonrası hesabınız geçici süre askıya alınmıştır.");
                    }
                    else{
                        return ServiceResponse<SignInResult>.Fail("Geçersiz email veya şifre");
                    }
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return ServiceResponse<SignInResult>.Fail(ex.Message);
            }
        }

        public async Task<ServiceResponse<EmptyModel>> SignOutAsync()
        {
            try
            {
                await _userRepository.SignOutAsync();
                return ServiceResponse<EmptyModel>.Success();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return ServiceResponse<EmptyModel>.Fail(ex.Message);
            }
        }
    }
}