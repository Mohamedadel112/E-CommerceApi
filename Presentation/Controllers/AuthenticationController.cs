using Microsoft.AspNetCore.Mvc;
using ServiciesApstraction;
using Shared.DTOs;
using Shared.ErrorsModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
