using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCinema.Domain.Model.Identity.AccountViewModels
{
    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
    }
}
