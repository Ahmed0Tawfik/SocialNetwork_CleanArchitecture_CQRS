using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Enums;
using SocialNetwork.Application.UserIdentityCQ.Command;
using SocialNetwork.Application.UserIdentityCQ.DTO;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest("User data is missing");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new UserLoginCommand(request);

            var result = await _mediator.Send(command);

            if (result == null)
            {
                return BadRequest("User login failed");
            }

            if (result.IsError)
            {
                return BadRequest(result.Errors);

            }

            return Ok(result.Payload);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterationRequestDTO request)
        {
            if(request == null)
            {
                return BadRequest("User data is missing");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new UserRegisterationCommand(request);

            var result = await _mediator.Send(command);

            if(result == null)
            {
                return BadRequest("User registration failed");
            }

            if (result.IsError)
            {
                return BadRequest(result.Errors);

            }


            return Ok(result.Payload);
        }
    }
}
