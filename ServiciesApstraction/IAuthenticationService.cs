using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciesApstraction
{
    public interface IAuthenticationService
    {
        public Task<UserDTO> Login(LoginDTO logindto);
        public Task<UserDTO> Register(RegisterDTO registerdto);
    }
}
