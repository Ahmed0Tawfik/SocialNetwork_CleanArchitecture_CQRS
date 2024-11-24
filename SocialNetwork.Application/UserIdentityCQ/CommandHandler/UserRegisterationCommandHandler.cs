using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Application.Enums;
using SocialNetwork.Application.Response;
using SocialNetwork.Application.Services;
using SocialNetwork.Application.UserIdentityCQ.Command;
using SocialNetwork.Domain.Models.UserIdentityDomain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace SocialNetwork.Application.UserIdentityCQ.CommandHandler
{
    public class UserRegisterationCommandHandler : IRequestHandler<UserRegisterationCommand, OperationResult<AuthResult>>
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly JWTConfig _jwtConfig;
        private readonly IMapper _mapper;

        public UserRegisterationCommandHandler(IMapper mapper, UserManager<UserIdentity> userManager, IOptions<JWTConfig> jwtConfig)
        {
            _userManager = userManager;
            _jwtConfig = jwtConfig.Value;
            _mapper = mapper;
        }

        public async Task<OperationResult<AuthResult>> Handle(UserRegisterationCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<AuthResult>();

            if(request.UserDTO == null)
            {
                result.IsError = true;
                result.Errors.Add(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = "User data is missing"
                });
                return result;
            }

            
            var user_exist = await _userManager.FindByEmailAsync(request.UserDTO.Email);

            if(user_exist != null)
            {
                result.IsError = true;
                result.Errors.Add(new Error
                {
                    Code = ErrorCode.Conflict,
                    Message = "User already exist"
                });
                return result;
            }

            var new_user = _mapper.Map<UserIdentity>(request.UserDTO);
            
            var is_created = await _userManager.CreateAsync(new_user, request.UserDTO.Password);

            if(is_created.Succeeded)
            {
                var token = JWTGenerator.GenerateJwtToken(new_user, _jwtConfig);

                result.Payload = new AuthResult
                {
                    Token = token
                };
                return result;
            }
            else
            {
                result.IsError = true;
                foreach(var error in is_created.Errors)
                {
                    result.Errors.Add(new Error
                    {
                        Code = ErrorCode.ValidationFailed,
                        Message = error.Description
                    });

                }
                return result;
            }

        }

        
    }
}
