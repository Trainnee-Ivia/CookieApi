using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Objetos
{
    public class HistoricoDeRetiradaDoLote
    {

        public int Id { get; set; }
        public int QuantidadeRetirada { get; set; }

        public int LoteId { get; set; }
        public int ItemDoPedidoId { get; set; }

        public virtual Lote Lote { get; set; }
        public virtual ItemDoPedido ItemDoPedido { get; set; }

        private HistoricoDeRetiradaDoLote() { }

        public HistoricoDeRetiradaDoLote(Lote lote, ItemDoPedido itemDoPedido, int quantidadeRetirada)
        {
            QuantidadeRetirada = quantidadeRetirada;
            Lote = lote;
            LoteId = lote.Id;
            ItemDoPedido = itemDoPedido;
            ItemDoPedidoId = itemDoPedido.Id;
        }
    }
}
