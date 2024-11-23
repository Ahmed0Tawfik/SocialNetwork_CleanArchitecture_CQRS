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
            CreateMap<UserProfileCreateResponseDTO, CreateUserCommand>();
            CreateMap<UserProfileCreateRequestDTO, CreateUserCommand>();
            CreateMap<UserProfile, UserProfileCreateResponseDTO>()
                .ForMember(dest => dest.UserProfileID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BasicInfoReq, opt => opt.MapFrom(src => src.BasicInfo))
                .ReverseMap();
            CreateMap<BasicInfoDTO, BasicInfo>().ReverseMap();

            CreateMap<UserProfileUpdateDTO, UpdateUserProfileCommand>();
        }
    }
}
