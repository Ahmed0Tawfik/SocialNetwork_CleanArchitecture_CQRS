using AutoMapper.Configuration.Annotations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SocialNetwork.Application.Enums;
using SocialNetwork.Application.Response;
using SocialNetwork.Application.Services;
using SocialNetwork.Application.UserIdentityCQ.Command;
using SocialNetwork.Domain.Models.UserIdentityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.UserIdentityCQ.CommandHandler
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, OperationResult<AuthResult>>
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly JWTConfig _jwtConfig;

        public UserLoginCommandHandler(UserManager<UserIdentity> userManager, IOptions<JWTConfig> jwtConfig)
        {
            _userManager = userManager;
            _jwtConfig = jwtConfig.Value;
        }

        public async Task<OperationResult<AuthResult>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<AuthResult>();

            var exisiting_user = await _userManager.FindByEmailAsync(request.Request.Email);

            if (exisiting_user == null)
            {
                result.IsError = true;
                result.Errors.Add(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = "User not found"
                });
                return result;
            }

            var is_valid_password = await _userManager.CheckPasswordAsync(exisiting_user, request.Request.Password);

            if (!is_valid_password)
            {
                result.IsError = true;
                result.Errors.Add(new Error
                {
                    Code = ErrorCode.InvalidData,
                    Message = "Invalid email or password"
                });
                return result;
            }

            var token = JWTGenerator.GenerateJwtToken(exisiting_user, _jwtConfig);

            result.Payload = new AuthResult
            {
                Token = token
            };

            return result;
            
        
        }
    }
}
