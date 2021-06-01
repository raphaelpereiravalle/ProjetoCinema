
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCinema.Web.ViewModel
{
    public class DadosSessaoViewModel
    {
        public DadosSessaoViewModel(bool erro, string msg, IEnumerable<SessaoViewModel> resultado)
        {
            Erro = erro;
            Msg = msg;
            Resultado = resultado;
        }

        public bool Erro { get; set; }
        public string Msg { get; set; }
        public IEnumerable<SessaoViewModel> Resultado { get; set; }
    }

    public class SessaoViewModel
    {
        [Key]
        [StringLength(450)]
        public string IdSessao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data sessão")]
        public DateTime? DataSessao { get; set; }

        [Display(Name = "Horário de inicio")]
        public string HoraInicioSessao { get; set; }

        [Display(Name = "Horário final")]
        public string HoraFimSessao { get; set; }

        [Display(Name = "Valor do ingresso")]
        public double? ValorIngresso { get; set; }

        [Display(Name = "Tipo de animação")]
        public string TipoAnimacao { get; set; }

        [Display(Name = "Tipo áudio")]
        public string TipoAudio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataRegistro { get; set; }

        public bool Ativo { get; set; }

        [StringLength(450)]
        public string IdUsuario { get; set; }

        [Display(Name = "Filme")]
        [StringLength(450)]
        public string IdFilme { get; set; }

        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Display(Name = "Sala")]
        [StringLength(450)]
        public string IdSala { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}
