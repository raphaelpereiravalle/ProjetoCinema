using System;
using System.Collections.Generic;

namespace ProjetoCinema.Domain.Model
{
    public class DadosSessao
    {
        public DadosSessao(bool erro, string msg, IEnumerable<Sessao> resultado)
        {
            Erro = erro;
            Msg = msg;
            Resultado = resultado;
        }

        public bool Erro { get; set; }
        public string Msg { get; set; }
        public IEnumerable<Sessao> Resultado { get; set; }
    }

    public class Sessao
    {
        public string IdSessao { get; set; }

        public DateTime? DataSessao { get; set; }

        public string HoraInicioSessao { get; set; }

        public string HoraFimSessao { get; set; }

        public double? ValorIngresso { get; set; }

        public string TipoAnimacao { get; set; }

        public string TipoAudio { get; set; }

        public DateTime DataRegistro { get; set; }

        public bool Ativo { get; set; }

        public string IdUsuario { get; set; }

        public string IdFilme { get; set; }

        public string Titulo { get; set; }

        public string IdSala { get; set; }

        public string Nome { get; set; }
    }
}
