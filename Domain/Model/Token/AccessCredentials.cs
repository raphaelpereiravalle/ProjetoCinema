using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCinema.Domain.Token.Model
{
    public class AccessCredentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public string GrantType { get; set; }
    }
}
