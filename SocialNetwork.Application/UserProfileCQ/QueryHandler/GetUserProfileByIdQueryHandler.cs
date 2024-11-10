using MediatR;
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
    internal class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfile>
    {
        private readonly IBaseRepository<UserProfile> _baseRepository;

        public GetUserProfileByIdQueryHandler(IBaseRepository<UserProfile> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<UserProfile> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            return await _baseRepository.GetByIdAsync(request.UserProfileId);
        }
    }
}
