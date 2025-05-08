using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiciesApstraction;
using Shared.DTOs;
using System.Security.Claims;

using Shared.ErrorsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class AuthenticationController(IServicesManager servicesManager) : ApiController
    {

        [HttpPost("login")]

        public async Task<ActionResult<UserDTO>>Login(LoginDTO logindto)
        {
            var result = await servicesManager.AuthenticationService.Login(logindto);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerdto)
        {
            var result = await servicesManager.AuthenticationService.Register(registerdto);
            return Ok(result);
        }


        [HttpGet("ExistEmail")]
        public async Task<ActionResult<bool>>checkIsEmailFound(string email)
        {
            return Ok(await servicesManager.AuthenticationService.CheckIfEmailExist(email));
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetUser() 
        {
            var email = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var result = await servicesManager.AuthenticationService.GetUserByEmail(email);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Address")]

        public async Task<ActionResult<AddressDTO>> GetAddress()
        {
            var email = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var result = await servicesManager.AuthenticationService.GetAddressByEmail(email);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("Address")]
        public async Task<ActionResult<AddressDTO>>UpdateAddress(AddressDTO addressDTO)
        {
            var email = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var result = await servicesManager.AuthenticationService.UpdateAddress(addressDTO,email);
            return Ok(result);
        }









    }
}
