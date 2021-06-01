using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCinema.Web.ViewModel
{
    public class DadosFilmeViewModel
    {
        public DadosFilmeViewModel(bool erro, string msg, IEnumerable<FilmeViewModel> resultado)
        {
            Erro = erro;
            Msg = msg;
            Resultado = resultado;
        }

        public bool Erro { get; set; }
        public string Msg { get; set; }
        public IEnumerable<FilmeViewModel> Resultado { get; set; }
    }

    public class FilmeViewModel
    {
        [Key]
        [StringLength(450)]
        public string IdFilme { get; set; }

        [Display(Name = "Titulo")]
        [StringLength(150)]
        public string Titulo { get; set; }

        [StringLength(800)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public IFormFile Arquivo { get; set; }

        [Display(Name = "Imagem")]
        public string Imagem { get; set; }

        public string Caminho { get; set; }

        [Display(Name = "Duração")]
        public string Duracao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataRegistro { get; set; }

        public bool Ativo { get; set; }

        [StringLength(450)]
        public string IdUsuario { get; set; }
    }
}