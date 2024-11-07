using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Models.PostDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Config
{
    internal class PostActionConfig : IEntityTypeConfiguration<PostAction>
    {
        public void Configure(EntityTypeBuilder<PostAction> builder)
        {
            builder.HasKey(p => p.Id);
            
        }
    }
}
