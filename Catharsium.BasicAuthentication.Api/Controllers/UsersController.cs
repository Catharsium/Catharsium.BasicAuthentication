using System.Threading.Tasks;
using Catharsium.BasicAuthentication.Api.Entities;
using Catharsium.BasicAuthentication.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catharsium.BasicAuthentication.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;


        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginCredentials credentials)
        {
            var user = await this.userService.Authenticate(credentials);

            if (user == null) {
                return this.Unauthorized(new {message = "Invalid login credentials"});
            }

            return this.Ok(user);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await this.userService.GetAll();
            return this.Ok(users);
        }
    }
}