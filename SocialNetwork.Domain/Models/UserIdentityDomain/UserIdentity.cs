using Microsoft.AspNetCore.Identity;
using SocialNetwork.Domain.Models.UserProfileDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Models.UserIdentityDomain
{
    public class UserIdentity : IdentityUser
    {
        public UserProfile UserProfile { get; set; }
    }
}
