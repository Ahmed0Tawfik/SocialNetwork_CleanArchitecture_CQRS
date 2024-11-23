using MediatR;
using SocialNetwork.Application.Response;
using SocialNetwork.Domain.Models.UserProfileDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.UserProfileCQ.Query
{
    public record GetUserProfileByIdQuery(Guid UserProfileId) : IRequest<OperationResult<UserProfile>>;
    
}
