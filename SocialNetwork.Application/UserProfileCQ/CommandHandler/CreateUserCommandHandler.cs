using MediatR;
using SocialNetwork.Application.UserProfileCQ.Command;
using SocialNetwork.Domain.Models.UserProfileDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.UserProfileCQ.CommandHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserProfile>
    {
        public CreateUserCommandHandler()
        {
            
        }
        public Task<UserProfile> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
