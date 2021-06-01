using System;
using System.Collections.Generic;

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
        public string IdSala { get; set; }
        
        public string Nome { get; set; }
        
        public int QuantidadeAssento { get; set; }
       
        public DateTime DataRegistro { get; set; }
        
        public bool Ativo { get; set; }

        public string IdUsuario { get; set; }
    }
}
