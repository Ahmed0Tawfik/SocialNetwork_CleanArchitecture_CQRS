namespace SocialNetwork.Domain.Models.UserProfileDomain
{
    public class UserProfile : BaseEntity
    {
        private UserProfile()
        {
        }
        public string IdentityId { get; private set; }
        public BasicInfo BasicInfo { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime LastSeen { get; private set; }

        //Factory Method
        public static UserProfile Create(string identityId, BasicInfo basicInfo)
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            return new UserProfile
            {
                IdentityId = identityId,
                BasicInfo = basicInfo,
                DateCreated = DateTime.UtcNow,
                LastSeen = DateTime.UtcNow
            };
        }

        public void UpdateBasicInfo(BasicInfo basicInfo)
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            BasicInfo = basicInfo;
        }
    }
}
