using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRest.ViewModels
{
    public class PedidoViewModelRecebimento
    {
        
        [Required(ErrorMessage ="Data do Pedido ivalido.")]
        public DateTime DataDoPedido { get; set; }

        [Required(ErrorMessage ="pontoDeVendaId deve ser informado.")]
        public int PontoDeVendaId { get; set; }

        [Required(ErrorMessage = "itensDoPedido")]
        List<ItemDoPedidoViewModelRecebimento> ItensDoPedido { get; set; }

        

        
    }
}