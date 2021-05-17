using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCinema.Domain.Model.Identity.ManageViewModels
{
    public class TwoFactorAuthenticationViewModel
    {
        public bool HasAuthenticator { get; set; }

        public int RecoveryCodesLeft { get; set; }

        public bool Is2faEnabled { get; set; }
    }
}
