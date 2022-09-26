using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using WinkelTicket.Database.Repositories.UserRepositories;

namespace WinkelTicket.Services.Providers
{
    public class ClaimProvider : IClaimsTransformation
    {
        private readonly IUserRepository _userRepository;

        public ClaimProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if(principal != null && principal.Identity.IsAuthenticated){
                var identity = principal.Identity as ClaimsIdentity;
                var userId = identity.Claims.FirstOrDefault(clm => clm.Type == ClaimTypes.NameIdentifier).Value;
                var user = await _userRepository.FindUserByIdAsync(userId);
                if(user != null){
                    identity.AddClaim(new Claim(ClaimTypes.GivenName,user.Name +" "+user.Surname,ClaimValueTypes.String));
                    identity.AddClaim(new Claim(ClaimTypes.UserData,user.Avatar,ClaimValueTypes.String));
                }
            }

            return principal;
        }
    }
}