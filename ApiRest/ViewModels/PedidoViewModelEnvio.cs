using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRest.ViewModels
{
    public class PedidoViewModelEnvio
    {
        public int Id { get; set; }

        public DateTime DataDoPedido { get; set; }

        public int PontoDeVendaId { get; set; }

        public List<object> _Links
        {
            get {
                return new List<object>() {
                    new { rel = "self", href = "/pedidos/" + Id },
                    new { rel = "ponto", href = "/pontos/" + PontoDeVendaId},
                    new { rel = "itens", href = "/pedidos/" + Id + "/itens" }
                };
            }
            
        }

        
    }
}