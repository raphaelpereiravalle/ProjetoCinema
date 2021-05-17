using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCinema.Domain.Model.Identity.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
