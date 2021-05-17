using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCinema.Domain.Token.Model
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ValidForMinutes { get; set; }        
    }
}
