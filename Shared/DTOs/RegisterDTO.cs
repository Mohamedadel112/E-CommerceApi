using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public  class RegisterDTO
    {
        [Required(ErrorMessage ="The Email Is Required")]
        [EmailAddress]
        public string Email { get; init; }
        [Required(ErrorMessage = "The UserName Is Required")]
        public string Username { get; init; }
        public string DisplayName { get; init; }
        public string? Phonenumber { get; init; }
        [Required(ErrorMessage = "The Password Is Required")]
        public string Password { get; init; }
    }
}
