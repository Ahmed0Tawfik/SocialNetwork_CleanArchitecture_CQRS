using MediatR;
using SocialNetwork.Application.Response;
using SocialNetwork.Application.UserIdentityCQ.DTO;
using SocialNetwork.Domain.Models.UserIdentityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.UserIdentityCQ.Command
{
    public record UserRegisterationCommand(UserRegisterationRequestDTO UserDTO) : IRequest<OperationResult<AuthResult>>;
   
}
