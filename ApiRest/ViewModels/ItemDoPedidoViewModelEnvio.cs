using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRest.ViewModels
{
    public class ItemDoPedidoViewModelEnvio
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public decimal PrecoUnitarioDoProduto { get; set; }

        public int ProdutoId { private get; set; }
        public int PedidoId { private get; set; }

        public List<object> _Links
        {
            get
            {
                return new List<object>() {
                    new { rel = "self", href = "/api/pedidos/"+ PedidoId + "/itens/" + Id },
                    new { rel = "pedido", href = "/api/pedidos/"+ PedidoId},
                    new { rel = "produto", href="/api/produtos/"+ ProdutoId}
                };
            }

        }
    }
}