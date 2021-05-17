using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCinema.Domain.Model
{
    public class Notificacao
    {
        public Notificacao(bool erro, string msg, string resultado)
        {
            Erro = erro;
            Msg = msg;
            Resultado = resultado;
        }

        public bool Erro { get; set; }
        public string Msg { get; set; }
        public string Resultado { get; set; }
    }
}
