using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiciesApstraction;
using Shared;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Servicies
{
    public class AuthenticationService(UserManager<User> userManager,IOptions<JwtOptions> options ) : IAuthenticationService
    {
        private readonly UserManager<User> _user =userManager;

        public async Task<UserDTO> Login(LoginDTO logindto)
        {
            var user =await _user.FindByEmailAsync(logindto.Email);
            if (user is null) throw new UserUnAuthorizeException();
            var result = await _user.CheckPasswordAsync(user, logindto.Password);
            if(!result) throw new UserUnAuthorizeException();
            return new UserDTO(user.DisplayName, logindto.Email, await CreateToken(user));
        }

        public async Task<UserDTO> Register(RegisterDTO registerdto)
        {
            var user = new User()
            {
                DisplayName = registerdto.DisplayName,
                Email = registerdto.Email,
                UserName = registerdto.Username,
                PhoneNumber = registerdto.Phonenumber
            };
            var result = await _user.CreateAsync(user, registerdto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e=>e.Description).ToList();
                throw new ValidationException(errors);

            }
            return new UserDTO(user.DisplayName , registerdto.Email,await CreateToken(user));
        }

        private async Task<string> CreateToken(User user)
        {
            var jwtOptions = options.Value;
            var claims = new List<Claim>() 
            {
                new Claim(ClaimTypes.Name ,user.DisplayName ),
                new Claim(ClaimTypes.Email ,user.Email )
            };
            var roles = await _user.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));
            var SigningCreds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken(issuer: jwtOptions.Issuer, audience: jwtOptions.Audience, claims: claims,expires: DateTime.UtcNow.AddDays(jwtOptions.ExpirationDate), signingCredentials: SigningCreds);
            return new JwtSecurityTokenHandler().WriteToken(Token);

        }
    }
}
