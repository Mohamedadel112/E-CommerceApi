using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class UserNotFound(string email): NotFoundException($"The Email {email} Not Found")
    {
    }
}
