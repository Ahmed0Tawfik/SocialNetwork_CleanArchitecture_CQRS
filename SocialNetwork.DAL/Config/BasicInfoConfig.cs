using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Models.UserProfileDomain;


namespace SocialNetwork.DAL.Config
{
    internal class BasicInfoConfig : IEntityTypeConfiguration<BasicInfo>
    {
        public void Configure(EntityTypeBuilder<BasicInfo> builder)
        {
            builder.HasNoKey();
           
        }
    }
}
