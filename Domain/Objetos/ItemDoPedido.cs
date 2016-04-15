using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Objetos
{
    public class ItemDoPedido
    {


        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitarioDoProduto { get; set; }

        public int ProdutoId { get; set; }
        public int PedidoId { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual List<HistoricoDeRetiradaDoLote> HistoricoDeRetiradaDosLotes { get; set; }
        

        private ItemDoPedido()
        {
            HistoricoDeRetiradaDosLotes = new List<HistoricoDeRetiradaDoLote>();
        }

        public ItemDoPedido(Produto produto, int quantidade)
        {
            Quantidade = quantidade;
            PrecoUnitarioDoProduto = produto.Preco;
            Produto = produto;
            ProdutoId = produto.Id;
            HistoricoDeRetiradaDosLotes = new List<HistoricoDeRetiradaDoLote>();
        }
    }
}
