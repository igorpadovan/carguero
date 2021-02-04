using Carguero.Domain.Services;
using Carguero.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Carguero.Controllers
{
    [ApiController]
    [Route("/addresses")]
    public class AddressController : ControllerBase
    {
        private IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Address>> Post([FromBody] Address address)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _addressService.RegisterAddress(address);

            if (address.Id == 0)
                return BadRequest("Not possible to register address, verify your data.");

            return Ok(HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Address>> Put([FromBody] Address address)
        {
            var updated = await _addressService.UpdateAddress(address);
            if (!updated)
                return BadRequest(HttpStatusCode.UnprocessableEntity);
            return Ok(HttpStatusCode.NoContent);
        }

        [HttpGet("search/{username}")]
        public async Task<ActionResult<Address>> Search(string username)
        {
            var address = _addressService.GetAddressesByUsername(username);
            return Ok(address);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> Delete(int id)
        {
            var address = _addressService.Delete(id);            
            return Ok();
        }



    }
}
