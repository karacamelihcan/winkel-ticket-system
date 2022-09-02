using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WinkelTicket.Contract.Request.UserRequests;
using WinkelTicket.Core.Models;

namespace WinkelTicket.Database.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user,password);
            return result;
        }

        public async Task<User> FindUserByEmailAsync(string Email)
        {
            var result = await _userManager.FindByEmailAsync(Email);
            return result;
        }
        public async Task<User> FindUserByIdAsync(string userId)
        {
            var result = await _userManager.FindByIdAsync(userId);
            return result;
        }

        public async Task<bool> IsLockedOutAsync(User user)
        {
            var result = await _userManager.IsLockedOutAsync(user);
            return true;
        }

        public async Task<bool> IsEmailConfirmedAsync(User user)
        {
            var result = await _userManager.IsEmailConfirmedAsync(user);
            return true;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<SignInResult> PasswordSignInAsync(PasswordSignInRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.user,request.password,request.isPersistent,false);
            return result;
        }

        public async Task<IdentityResult> ResetAccessFailedCountAsync(User user)
        {
            var result = await _userManager.ResetAccessFailedCountAsync(user);
            return result;
        }

        public async Task<IdentityResult> AccessFailedAsync(User user)
        {
            var result = await _userManager.AccessFailedAsync(user);
            return result;
        }

        public async Task<int> GetAccessFailedCountAsync(User user)
        {
            var result = await _userManager.GetAccessFailedCountAsync(user);
            return result;
        }

        public async Task<IdentityResult> SetLockoutEndDateAsync(User user)
        {
            var result = await _userManager.SetLockoutEndDateAsync(user ,DateTimeOffset.Now.AddMinutes(20));
            return result;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            var result = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return result;
        }

        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            var result = await _userManager.GeneratePasswordResetTokenAsync(user);
            return result;
        }

        public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword)
        {
            var result = await _userManager.ResetPasswordAsync(user,token,newPassword);
            return result;
        }

        public async Task<IdentityResult> UpdateSecurityStampAsync(User user)
        {
            var result = await _userManager.UpdateSecurityStampAsync(user);
            return result;
        }

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            var result = await _userManager.ConfirmEmailAsync(user,token);
            return result;
        }

        public async Task<bool> CheckPasswordAsync(User user, string oldPassword)
        {
            var result = await _userManager.CheckPasswordAsync(user,oldPassword);
            return result;
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            var result = await _userManager.ChangePasswordAsync(user,oldPassword,newPassword);
            return result;
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result;
        }

        public async Task SignInAsync(User user, bool isPersistent)
        {
            await _signInManager.SignInAsync(user,isPersistent);
        }

        public async Task<IdentityResult> DeleteUserAsync(User user)
        {
            var result = await _userManager.DeleteAsync(user);
            return result;
        }
    }
}