using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Models.UserProfileDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Config
{
    internal class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(up => up.Id);
            builder.Property(up => up.Id).ValueGeneratedOnAdd();

            builder.OwnsOne(up => up.BasicInfo, bi =>
            {
                bi.OwnsOne(bi => bi.Location);
                bi.Property(bi => bi.FirstName).IsRequired().HasMaxLength(50);
                bi.Property(bi => bi.LastName).IsRequired().HasMaxLength(50);
                bi.Property(bi => bi.DateOfBirth).IsRequired();


                
            });

            
            
        }
    }
}
