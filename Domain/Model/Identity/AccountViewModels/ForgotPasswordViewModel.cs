using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoCinema.Domain.Model.Identity.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
