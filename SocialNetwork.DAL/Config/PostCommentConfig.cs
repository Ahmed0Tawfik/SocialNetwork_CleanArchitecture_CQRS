using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Models.PostDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Config
{
    internal class PostCommentConfig : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PostComment> builder)
        {
            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.Content).IsRequired();
            builder.Property(pc => pc.DateCreated).IsRequired();
        }
    }
}
