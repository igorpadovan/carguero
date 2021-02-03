using Carguero.Domain.Services;
using Carguero.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _userService.listRegisteredUsers();
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
