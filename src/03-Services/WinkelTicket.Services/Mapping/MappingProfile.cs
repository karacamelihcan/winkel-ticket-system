using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WinkelTicket.Core.Dtos;
using WinkelTicket.Core.Models;
using WinkelTicket.Database.Repositories.UserRepositories;


namespace WinkelTicket.Services.Mapping
{

    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<UserRoles, UserRoleDto>().ReverseMap();
            CreateMap<User,UserDto>()
                        .ForMember(user => user.Role , conf => conf.MapFrom(user => user.RoleName)).ReverseMap();   

        }

    }

}