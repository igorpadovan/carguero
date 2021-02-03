using Carguero.Domain.Services;
using Carguero.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Carguero.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<User>> Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);            
            
            
                await _userService.RegisterUser(user);
                return user;
            
            
            
        }
    }
}
