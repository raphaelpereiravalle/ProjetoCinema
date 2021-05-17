using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCinema.Domain.Model.Identity.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }
        public string Nome { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string StatusMessage { get; set; }
    }
}
