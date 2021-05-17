using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCinema.Domain.Model
{
    public class JsonModel
    {
        public List<object> results;

        public object result;
        public List<Erro> Erros { get; set; }
        public bool success { get; set; }
        public List<string> Msgs { get; set; }
        public string message { get; set; }
    }

    public class Erro
    {
        public string key { get; set; }
        public List<string> Value { get; set; }
    }
}
