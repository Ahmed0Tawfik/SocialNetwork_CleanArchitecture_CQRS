using AutoMapper;
using SocialNetwork.Application.UserProfileCQ.Command;
using SocialNetwork.Application.UserProfileCQ.DTO;
using SocialNetwork.Domain.Models.UserProfileDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.MappingProfiles
{
    internal class UserProfileMap : Profile
    {
        public UserProfileMap()
        {
            CreateMap<CreateUserCommand, BasicInfo>();
            CreateMap<CreateUserCommand, UserProfile>();
            CreateMap<CreateUserCommand, Location>();
            CreateMap<CreateUserCommand, UserProfileCreateResponseDTO>();
        }
    }
}
