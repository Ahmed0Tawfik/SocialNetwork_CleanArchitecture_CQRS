namespace SocialNetwork.API
{
    public class ApiRoutes
    {
        public const string BaseRoute = "api/[controller]";

        public class Post
        {
            public const string GetById = "{id}";
           
        }

        public class UserProfile
        {
            public const string IdRoute = "{id}";
        }
    }
}
