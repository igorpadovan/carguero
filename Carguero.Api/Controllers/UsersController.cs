using Carguero.Domain.Services;
using Carguero.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
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
            return Ok(await _userService.ListRegisteredUsers());
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<User>> Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);      
            
            await _userService.RegisterUser(user);
            if (user.Id == 0)
                return BadRequest();
            return Ok();            
        }

        [HttpGet("search")]
        public async Task<ActionResult<User>> Search([FromQuery]string username)
        {
            var user = _userService.GetByUsername(username);
            return Ok(user);
        }
    }
}
