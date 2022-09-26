using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WinkelTicket.Contract.Request.UserRequests;
using WinkelTicket.Core.Models;

namespace WinkelTicket.Database.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task<User> FindUserByEmailAsync(string Email);
        Task<User> FindUserByIdAsync(string userId);
        Task<bool> IsLockedOutAsync(User user);
        Task<bool> IsEmailConfirmedAsync(User user);
        Task SignOutAsync();
        Task<SignInResult> PasswordSignInAsync(PasswordSignInRequest request);
        Task<IdentityResult> ResetAccessFailedCountAsync(User user);
        Task<IdentityResult> AccessFailedAsync(User user);
        Task<int> GetAccessFailedCountAsync(User user);
        Task<IdentityResult> SetLockoutEndDateAsync(User user);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
        Task<string> GeneratePasswordResetTokenAsync(User user);
        Task<IdentityResult> ResetPasswordAsync(User user,string token, string newPassword);
        Task<IdentityResult> UpdateSecurityStampAsync(User user);
        Task<IdentityResult> ConfirmEmailAsync(User user,string token);
        Task<bool> CheckPasswordAsync(User user,string oldPassword);
        Task<IdentityResult> ChangePasswordAsync(User user,string oldPassword, string newPassword);
        Task<IdentityResult> UpdateUserAsync(User user);
        Task SignInAsync(User user, bool isPersistent);
        Task<IdentityResult> DeleteUserAsync(User user);
        Task<IEnumerable<User>> GetAll();
        Task<IEnumerable<UserRoles>> GetRoles();
        Task<string> GetUserRoles(User user);
        Task<UserRoles> GetRoleByRoleId(string Id);
        Task<IdentityResult> AddToRoleAsync(User user, string RoleName);
        Task<IdentityResult> RemoveFromRoleAsync(User user,string RoleName);
        Task<List<User>> GetUserForTicketAssign();
    }
}