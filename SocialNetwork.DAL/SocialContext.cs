using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.DAL.Config;
using SocialNetwork.Domain.Models.PostDomain;
using SocialNetwork.Domain.Models.UserIdentityDomain;
using SocialNetwork.Domain.Models.UserProfileDomain;


namespace SocialNetwork.DAL
{
    public class SocialContext : IdentityDbContext
    {
        public SocialContext(DbContextOptions<SocialContext> options) : base(options)
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserProfileConfig());
            builder.ApplyConfiguration(new PostCommentConfig());
            builder.ApplyConfiguration(new PostActionConfig());



            base.OnModelCreating(builder);

        }
    }
}
