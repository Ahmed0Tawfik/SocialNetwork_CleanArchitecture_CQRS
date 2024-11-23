using MediatR;
using SocialNetwork.Application.Enums;
using SocialNetwork.Application.Response;
using SocialNetwork.Application.UserProfileCQ.Query;
using SocialNetwork.Domain.Interfaces;
using SocialNetwork.Domain.Models.UserProfileDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.UserProfileCQ.QueryHandler
{
    internal class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, OperationResult<UserProfile>>
    {
        private readonly IBaseRepository<UserProfile> _baseRepository;

        public GetUserProfileByIdQueryHandler(IBaseRepository<UserProfile> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<OperationResult<UserProfile>> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            try
            {
                var userProfile = await _baseRepository.GetByIdAsync(request.UserProfileId);

                if (userProfile == null)
                {
                    result.Errors.Add(new Error { Code = ErrorCode.NotFound, Message = "UserProfile Not Found !" });
                    return result;
                }

                result.Payload = userProfile;
            }
            catch (Exception ex)
            {
                result.IsError = true;
                var error = new Error { Code = ErrorCode.ServerError, Message = ex.Message };
                result.Errors.Add(error);
            }

            return result;
        }
    }
}
