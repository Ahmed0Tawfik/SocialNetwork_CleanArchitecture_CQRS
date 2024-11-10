using AutoMapper;
using SocialNetwork.Application.UserProfileCQ.Command;
using SocialNetwork.Application.UserProfileCQ.DTO;
using SocialNetwork.Domain.Models.UserProfileDomain;

namespace SocialNetwork.API.MappingProfiles
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping() 
        { 
            CreateMap<UserProfileCreateDTO, CreateUserCommand>();
            CreateMap<UserProfile, UserProfileCreateDTO>()
                .ForMember(dest => dest.UserProfileID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BasicInfoReq, opt => opt.MapFrom(src => src.BasicInfo))
                .ReverseMap();
            CreateMap<BasicInfoDTO, BasicInfo>().ReverseMap();
        }
    }
}
