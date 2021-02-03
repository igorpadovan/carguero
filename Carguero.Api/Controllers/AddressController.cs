﻿using Carguero.Domain.Services;
using Carguero.Entities;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<Address>> Post([FromBody]Address address)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);            
            
            
                await _addressService.RegisterAddress(address);
                return address;
        }
    }
}
