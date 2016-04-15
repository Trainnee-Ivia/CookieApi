using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Objetos
{
    public class PontoDeVenda
    {
        
        public int Id { get; set; }
        public string Telefone { get; set; }
        public string Nome { get; set; }
        public string NomeDoContato { get; set; }
        public Endereco Endereco { get; set; }

        public virtual List<Pedido> Pedidos { get; set; } 

        private PontoDeVenda()
        {
            
        }

        public PontoDeVenda(string telefone, string nome, string nomeDoContato, Endereco endereco)
        {
            Telefone = telefone;
            Nome = nome;
            NomeDoContato = nomeDoContato;
            Endereco = endereco;
            Pedidos = new List<Pedido>();
        }

        
    }
}
