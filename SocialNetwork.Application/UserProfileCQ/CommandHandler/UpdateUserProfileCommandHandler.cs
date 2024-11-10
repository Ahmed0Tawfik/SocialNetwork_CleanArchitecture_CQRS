using MediatR;
using SocialNetwork.Application.Enums;
using SocialNetwork.Application.Response;
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
    internal class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, OperationResult<UserProfile>>
    {
        private readonly IBaseRepository<UserProfile> _baseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserProfileCommandHandler(IBaseRepository<UserProfile> baseRepository, IUnitOfWork unitOfWork)
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<UserProfile>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();    

            try
            {
                var userProfile = await _baseRepository.GetByIdAsync(request.UserProfileId);

                if (userProfile is null)
                {
                    result.IsError = true;
                    var error = new Error { Code = ErrorCode.NotFound, Message = $"User Profile with ID: {request.UserProfileId} was not found!" };
                    result.Errors.Add(error);
                    return result;
                }

                var basicInfo = BasicInfo.Create(request.BasicInfoReq.FirstName, request.BasicInfoReq.LastName, request.BasicInfoReq.PhoneNumber,
                    request.BasicInfoReq.Location, request.BasicInfoReq.DateOfBirth, request.BasicInfoReq.Bio, request.BasicInfoReq.ProfilePicture, request.BasicInfoReq.CoverPicture);


                userProfile.UpdateBasicInfo(basicInfo);
                _unitOfWork.Complete();

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
