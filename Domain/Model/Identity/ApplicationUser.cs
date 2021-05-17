using Microsoft.AspNetCore.Identity;
using System;

namespace ProjetoCinema.Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool UsuarioAtivo { get; set; }
    }
}