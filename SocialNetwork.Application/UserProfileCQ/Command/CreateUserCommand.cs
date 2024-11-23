using MediatR;
using SocialNetwork.Application.Response;
using SocialNetwork.Application.UserProfileCQ.DTO;
using SocialNetwork.Domain.Models.UserProfileDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.UserProfileCQ.Command
{
    public record CreateUserCommand(BasicInfoDTO BasicInfoReq) : IRequest<OperationResult<UserProfile>>;
    
}
