using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.UserProfileCQ.DTO;

namespace SocialNetwork.API.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet(ApiRoutes.UserProfile.GetById)]
        public async Task<IActionResult> GetUserProfileById(int id)
        {
            return await Task.FromResult(Ok($"User profile with id {id}"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody]UserProfileCreateDTO profileReq)
        {

            return await Task.FromResult(Ok());
        }
    }
}
