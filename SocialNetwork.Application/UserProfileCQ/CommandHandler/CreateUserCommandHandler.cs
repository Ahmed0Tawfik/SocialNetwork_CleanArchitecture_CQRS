using AutoMapper;
using MediatR;
using SocialNetwork.Application.UserProfileCQ.Command;
using SocialNetwork.Domain.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<UserProfile> _baseRepository;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IBaseRepository<UserProfile> baseRepository)
        {
            _unitOfWork = unitOfWork;
            _baseRepository = baseRepository;
        }
        public async Task<UserProfile> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var basicInfo = BasicInfo.Create(request.BasicInfoReq.FirstName, request.BasicInfoReq.LastName, request.BasicInfoReq.PhoneNumber,
                request.BasicInfoReq.Location, request.BasicInfoReq.DateOfBirth, request.BasicInfoReq.Bio, request.BasicInfoReq.ProfilePicture, request.BasicInfoReq.CoverPicture);
        
            var userProfile = UserProfile.Create(Guid.NewGuid().ToString() ,basicInfo);
        
            await _baseRepository.AddAsync(userProfile);

            _unitOfWork.Complete();
        
            return userProfile;
        }
    }
}
