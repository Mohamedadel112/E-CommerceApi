using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record LoginDTO
    {
        public string Password { get; init; }
        public string Email { get; init; }
    }
}
