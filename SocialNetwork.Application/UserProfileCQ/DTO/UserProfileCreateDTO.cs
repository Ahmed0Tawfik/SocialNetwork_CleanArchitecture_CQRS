namespace SocialNetwork.Application.UserProfileCQ.DTO
{
    public record UserProfileCreateDTO
    {
        public BasicInfoDTO BasicInfo { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
