using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Models.UserIdentityDomain;
using SocialNetwork.Domain.Models.UserProfileDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Config
{
    public class UserIdentityConfig : IEntityTypeConfiguration<UserIdentity>
    {
        public void Configure(EntityTypeBuilder<UserIdentity> builder)
        {
            builder.HasKey(ui => ui.Id);
            builder.Property(ui => ui.Id).ValueGeneratedOnAdd();
            builder.Property(ui => ui.Email).IsRequired().HasMaxLength(50);
            builder.Property(ui => ui.PasswordHash).IsRequired().HasMaxLength(256);

            builder.HasOne(ui => ui.UserProfile)
             .WithOne(up => up.UserIdentity)
             .HasForeignKey<UserProfile>(up => up.IdentityId);
        }
    }
}
