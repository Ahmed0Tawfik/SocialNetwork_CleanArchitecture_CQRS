using SocialNetwork.Domain.Models.UserProfileDomain;

namespace SocialNetwork.Domain.Models.PostDomain
{
    public class Post : BaseEntity
    {
        
        private Post()
        {
            Comments = new List<PostComment>();
            Actions = new List<PostAction>();
        }
        public Guid UserProfileId { get; private set; }
        public string? Content { get; private set; }
        public DateTime DateCreated { get; private set; }
        public ICollection<PostComment> Comments { get; private set; } 
        public ICollection<PostAction> Actions { get; private set; }

        //Factory Method
        public static Post Create(Guid userProfileId, string content = "")
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            return new Post
            {
                UserProfileId = userProfileId,
                Content = content,
                DateCreated = DateTime.UtcNow
            };
        }


        public void UpdatePostContent(string content)
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            Content = content;
        }

        public void AddComment(PostComment comment)
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            Comments.Add(comment);
        }

        public void RemoveComment(PostComment comment) 
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            Comments.Remove(comment);
        }

        public void AddAction(PostAction action)
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            Actions.Add(action);
        }

        public void RemoveAction(PostAction action)
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            Actions.Remove(action);
        }
    }
}
