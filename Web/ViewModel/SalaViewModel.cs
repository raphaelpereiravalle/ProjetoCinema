using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCinema.Web.ViewModel
{
    public class DadosSalaViewModel
    {
        public DadosSalaViewModel(bool erro, string msg, IEnumerable<SalaViewModel> resultado)
        {
            Erro = erro;
            Msg = msg;
            Resultado = resultado;
        }

        public bool Erro { get; set; }
        public string Msg { get; set; }
        public IEnumerable<SalaViewModel> Resultado { get; set; }
    }

    public class SalaViewModel
    {
        [Key]
        [StringLength(450)]
        public string IdSala { get; set; }
        
        [Display(Name = "Nome")]
        [StringLength(150)]
        public string Nome { get; set; }
        
        [Display(Name = "Quantidade de assento")]
        public int QuantidadeAssento { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataRegistro { get; set; }
        
        public bool Ativo { get; set; }

        [StringLength(450)]
        public string IdUsuario { get; set; }
    }
}
