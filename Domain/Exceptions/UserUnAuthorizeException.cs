﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class UserUnAuthorizeException(string msg = "Invalid Email Or Password "):Exception(msg)
    {
    }
}
