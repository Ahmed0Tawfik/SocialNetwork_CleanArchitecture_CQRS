

using SocialNetwork.Domain.Models.UserProfileDomain;

namespace SocialNetwork.Domain.Models.PostDomain
{
    public class PostComment
    {

        private PostComment() { }
        public Guid Id { get; private set; }
        public Guid PostId { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCreated { get; private set; }
        public Guid UserProfileId { get; private set; }
        public UserProfile UserProfile { get; private set; }

        //Factory Method
        public static PostComment Create(Guid postId, Guid userProfileId, string content)
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            return new PostComment
            {
                PostId = postId,
                UserProfileId = userProfileId,
                Content = content,
                DateCreated = DateTime.UtcNow
            };
        }
        

        public void UpdateCommentContent(string content)
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            Content = content;
        }
    }
}
