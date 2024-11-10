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
    internal class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UserProfile>
    {
        private readonly IBaseRepository<UserProfile> _baseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserProfileCommandHandler(IBaseRepository<UserProfile> baseRepository, IUnitOfWork unitOfWork)
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserProfile> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _baseRepository.GetByIdAsync(request.UserProfileId);

            var basicInfo = BasicInfo.Create(request.BasicInfoReq.FirstName, request.BasicInfoReq.LastName, request.BasicInfoReq.PhoneNumber,
                request.BasicInfoReq.Location, request.BasicInfoReq.DateOfBirth, request.BasicInfoReq.Bio, request.BasicInfoReq.ProfilePicture, request.BasicInfoReq.CoverPicture);


            userProfile.UpdateBasicInfo(basicInfo);
            _unitOfWork.Complete();

            return userProfile;
        }
    }
}
