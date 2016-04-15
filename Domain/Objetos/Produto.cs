using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Objetos
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DiasValidos { get; set; }
        public decimal Preco { get; set; }

        private Produto()
        {

        }

        public Produto(string nome, int diasValidos, decimal preco)
        {
            Nome = nome;
            DiasValidos = diasValidos;
            Preco = preco;
        }
    }
}
