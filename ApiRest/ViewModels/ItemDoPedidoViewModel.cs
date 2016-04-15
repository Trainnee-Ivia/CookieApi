using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRest.ViewModels
{
    public class ItemDoPedidoViewModel
    {
        public int Id { get; set; }
        [Required()]
        public int Quantidade { get; set; }
        public decimal PrecoUnitarioDoProduto { get; set; }

        public int ProdutoId { private get; set; }
        public int PedidoId { private get; set; }

        public List<object> Links
        {
            get
            {
                return new List<object>() {
                    new { rel = "self", href = "/pedidos/"+ PedidoId +"/itens/" + Id },
                    new { rel = "pedido", href = "/pedidos/"+ PedidoId}
                };
            }

        }
    }
}