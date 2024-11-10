

namespace SocialNetwork.Domain.Models.PostDomain
{
    public class PostAction : BaseEntity
    {
        private PostAction() { }
        public Guid PostId { get; private set; }
        public Guid UserProfileId { get; private set; }
        public PostActionType Type { get; private set; }

        //Factory Method

        public static PostAction Create(Guid postId, Guid userProfileId, PostActionType type)
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            return new PostAction
            {
                PostId = postId,
                UserProfileId = userProfileId,
                Type = type
            };
        }

        public void UpdateType(PostActionType type)
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            Type = type;
        }

        


    }
}
