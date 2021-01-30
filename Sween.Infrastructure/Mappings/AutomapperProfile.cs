using AutoMapper;
using Sween.Core.DTOs;
using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Security, SecurityDTO>();
            CreateMap<SecurityDTO, Security>();
        }
    }
}
