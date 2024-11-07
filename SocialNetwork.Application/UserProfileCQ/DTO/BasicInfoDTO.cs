using SocialNetwork.Domain.Models.UserProfileDomain;

namespace SocialNetwork.Application.UserProfileCQ.DTO
{
    public record BasicInfoDTO
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string? Bio { get; private set; }
        public string? ProfilePicture { get; private set; }
        public string? CoverPicture { get; private set; }
        public Location? Location { get; private set; }
        public DateTime DateOfBirth { get; private set; }
    }
}
