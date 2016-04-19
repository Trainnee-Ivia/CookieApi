using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRest.ViewModels
{
    public class ItemDoPedidoViewModelRecebimento
    {
        
        [Required(ErrorMessage = "quantidade deve ser informada.")]
        [Range(1,9999, ErrorMessage ="Quantidade do item ivalida.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage ="produtoId deve ser informado.")]
        public int ProdutoId { get; set; }
        
    }
}