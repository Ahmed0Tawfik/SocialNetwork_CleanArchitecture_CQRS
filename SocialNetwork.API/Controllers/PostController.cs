using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.API.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class PostController : ControllerBase
    {

        [HttpGet(ApiRoutes.Post.GetById)]
        public IActionResult GetPostById(int id)
        {
            return Ok($"Post with id {id}");
        }
    }
}
