using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCinema.Domain.Model
{
    public class Home
    {
        public int totalFilmes { get; set; }

        public double mediaValorIngresso { get; set; }
    }
}
