using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRest.ViewModels
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Data do Pedido ivalido.")]
        public DateTime DataDoPedido { get; set; }

        public int PontoDeVendaId { private get; set; }

        public List<object> Links
        {
            get {
                return new List<object>() {
                    new { rel = "self", href = "/pedidos/" + Id },
                    new { rel = "ponto", href = "/pontos/" + PontoDeVendaId},
                    new { rel = "itens", href = "/pedidos/itens" }
                };
            }
            
        }

        
    }
}