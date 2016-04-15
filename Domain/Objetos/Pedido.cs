using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Objetos
{
    public class Pedido
    {
        
        public int Id { get; set; }
        public DateTime DataDoPedido { get; set; }

        public int PontoDeVendaId { get; set; }

        public virtual PontoDeVenda PontoDeVenda { get; set; }
        public virtual List<ItemDoPedido> ItensDoPedido { get; private set; }

        private Pedido() { }

        public Pedido(DateTime dataDoPedido, PontoDeVenda pontoDeVenda)
        {
           
            DataDoPedido = dataDoPedido;
            PontoDeVenda = pontoDeVenda;
            PontoDeVendaId = pontoDeVenda.Id;
            ItensDoPedido = new List<ItemDoPedido>();
        }
        
        public void AdiconarItemAoPedido(ItemDoPedido item)
        {
            
            ItensDoPedido.Add(item);
        }
    }
}
