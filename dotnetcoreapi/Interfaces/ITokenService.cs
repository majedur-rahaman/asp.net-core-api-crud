using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcoreapi.Models;

namespace dotnetcoreapi.Interfaces
{
    public interface ITokenService
    {
        string createToken(AppUser user);
    }
}