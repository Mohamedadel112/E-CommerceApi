using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record UserDTO(string DiaplayName , string Email, string Token)
    {
    }
}
