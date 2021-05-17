using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SYN.Identity.Services
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
