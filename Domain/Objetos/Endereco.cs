using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Objetos
{
    public class Endereco
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        
        private Endereco() { }

        public Endereco(string logradouro, int numero, string complemento, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            CEP = cep;
        }

    }
}
