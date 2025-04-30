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
        public Task<UserDTO> GetUserByEmail(string email);
        public Task<bool> CheckIfEmailExist(string email);
        public Task<AddressDTO> UpdateAddress(AddressDTO address, string email);
        public Task<AddressDTO> GetAddressByEmail(string email);
    }
}
