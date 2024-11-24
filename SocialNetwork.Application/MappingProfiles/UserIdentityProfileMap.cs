using AutoMapper;
using Microsoft.Data.SqlClient;
using SocialNetwork.Application.UserIdentityCQ.DTO;
using SocialNetwork.Application.UserProfileCQ.Command;
using SocialNetwork.Application.UserProfileCQ.DTO;
using SocialNetwork.Domain.Models.UserIdentityDomain;
using SocialNetwork.Domain.Models.UserProfileDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.MappingProfiles
{
    internal class UserIdentityProfileMap : Profile
    {
        public UserIdentityProfileMap()
        {
            CreateMap<UserIdentity, UserRegisterationRequestDTO>()
                .ForMember(ui => ui.Email, dto => dto.MapFrom(src => src.UserName))
                .ForMember(ui => ui.Email, dto => dto.MapFrom(src => src.Email))
                .ReverseMap();
        }
    }
}
