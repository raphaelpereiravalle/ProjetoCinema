using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCinema.Domain.Token.Model
{
    public class Token
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }        
    }
}
