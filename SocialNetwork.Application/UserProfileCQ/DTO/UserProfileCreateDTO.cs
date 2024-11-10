using System.Data;

namespace SocialNetwork.Application.UserProfileCQ.DTO
{
    public class UserProfileCreateDTO
    {
        public BasicInfoDTO BasicInfoReq { get; set; }
        public Guid? UserProfileID { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastSeen { get; set; }
    }
}
