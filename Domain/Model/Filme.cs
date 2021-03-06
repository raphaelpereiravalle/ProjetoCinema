using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace ProjetoCinema.Domain.Model
{
    public class DadosFilme
    {
        public DadosFilme(bool erro, string msg, IEnumerable<Filme> resultado)
        {
            Erro = erro;
            Msg = msg;
            Resultado = resultado;
        }

        public bool Erro { get; set; }
        public string Msg { get; set; }
        public IEnumerable<Filme> Resultado { get; set; }
    }

    public class Filme
    {
        public string IdFilme { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public IFormFile Arquivo { get; set; }

        public string Imagem { get; set; }

        public string Caminho { get; set; }

        public string Duracao { get; set; }

        public DateTime DataRegistro { get; set; }

        public bool Ativo { get; set; }

        public string IdUsuario { get; set; }
    }
}
