using SocialNetwork.Domain.Models.UserProfileDomain;
using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Application.UserProfileCQ.Query;
using SocialNetwork.Domain.Interfaces;
using AutoMapper;

namespace SocialNetwork.Application.UserProfileCQ.QueryHandler
{
    internal class GetAllUserProfileQueryHandler : IRequestHandler<GetAllUserProfileQuery, IEnumerable<UserProfile>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<UserProfile> _baserepository;

        public GetAllUserProfileQueryHandler(IUnitOfWork unitOfWork, IBaseRepository<UserProfile> baserepository)
        {
            _unitOfWork = unitOfWork;
            _baserepository = baserepository;
        }
        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfileQuery request, CancellationToken cancellationToken)
        {
            return await _baserepository.GetAllAsync();
        }
    }
}
