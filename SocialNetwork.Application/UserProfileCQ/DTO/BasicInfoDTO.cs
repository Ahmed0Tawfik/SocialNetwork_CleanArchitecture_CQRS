using SocialNetwork.Domain.Models.UserProfileDomain;

namespace SocialNetwork.Application.UserProfileCQ.DTO
{
    public class BasicInfoDTO
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string PhoneNumber { get;  set; }
        public string? Bio { get;  set; }
        public string? ProfilePicture { get;  set; }
        public string? CoverPicture { get;  set; }
        public Location? Location { get;  set; }
        public DateTime DateOfBirth { get; set; }
    }
}
