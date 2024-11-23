using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.UserProfileCQ.Command;
using SocialNetwork.Application.UserProfileCQ.DTO;
using SocialNetwork.Application.UserProfileCQ.Query;
using SocialNetwork.Application.Enums;

namespace SocialNetwork.API.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserProfileController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }



        [HttpGet(ApiRoutes.UserProfile.IdRoute)]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var query = new GetUserProfileByIdQuery(Guid.Parse(id));
           
            
            var result = await _mediator.Send(query);

            if (result.IsError)
            {
                if (result.Errors.Any(x => x.Code == ErrorCode.NotFound))
                {
                    return NotFound(result.Errors.FirstOrDefault(e => e.Code == ErrorCode.NotFound).Message);
                }

                if (result.Errors.Any(x => x.Code == ErrorCode.ServerError))
                {
                    return NotFound(result.Errors.FirstOrDefault(e => e.Code == ErrorCode.ServerError).Message);
                }
            }

            var profile = _mapper.Map<UserProfileCreateResponseDTO>(result.Payload);

            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreateRequestDTO profileReq)
        {
            var command = _mapper.Map<CreateUserCommand>(profileReq);
            var result = await _mediator.Send(command);

            if (result.IsError)
            {
                if (result.Errors.Any(x => x.Code == ErrorCode.NotFound))
                {
                    return NotFound(result.Errors.FirstOrDefault(e => e.Code == ErrorCode.NotFound).Message);
                }

                if (result.Errors.Any(x => x.Code == ErrorCode.ServerError))
                {
                    return NotFound(result.Errors.FirstOrDefault(e => e.Code == ErrorCode.ServerError).Message);
                }
            }

            var response = _mapper.Map<UserProfileCreateResponseDTO>(result.Payload);

            return CreatedAtAction(nameof(GetUserProfileById),new {id = response.UserProfileID.ToString()},response);


        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserProfiles()
        {
            var query = new GetAllUserProfileQuery();
            var response = await _mediator.Send(query);

            var profiles = _mapper.Map<IEnumerable<UserProfileCreateResponseDTO>>(response);  
            
            return Ok(profiles);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUserProfile(Guid id, [FromBody] BasicInfoDTO profileReq)
        {
            var command = new UpdateUserProfileCommand(id, profileReq);

            var result = await _mediator.Send(command);


            if(result.IsError)
            {
                if(result.Errors.Any(x => x.Code == ErrorCode.NotFound))
                {
                    return NotFound(result.Errors.FirstOrDefault(e => e.Code == ErrorCode.NotFound).Message);
                }

                if (result.Errors.Any(x => x.Code == ErrorCode.ServerError))
                {
                    return NotFound(result.Errors.FirstOrDefault(e => e.Code == ErrorCode.ServerError).Message);
                }
            }

            var response = _mapper.Map<UserProfileCreateResponseDTO>(result.Payload);

            return Ok(response);
        }

       
    }
}
