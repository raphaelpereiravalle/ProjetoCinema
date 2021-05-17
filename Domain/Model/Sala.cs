using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCinema.Domain.Model
{
    public class DadosSala
    {
        public DadosSala(bool erro, string msg, IEnumerable<Sala> resultado)
        {
            Erro = erro;
            Msg = msg;
            Resultado = resultado;
        }

        public bool Erro { get; set; }
        public string Msg { get; set; }
        public IEnumerable<Sala> Resultado { get; set; }
    }

    public class Sala
    {
        [Key]
        [StringLength(450)]
        public string IdSala { get; set; }
        
        [Display(Name = "Nome")]
        [StringLength(150)]
        public string Nome { get; set; }
        
        [Display(Name = "Quantidade de assento")]
        public int QuantidadeAssento { get; set; }
       
        public DateTime DataRegistro { get; set; }
        
        public bool Ativo { get; set; }

        [StringLength(450)]
        public string IdUsuario { get; set; }
    }
}
