using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRest.ViewModels
{
    public class ItemDoPedidoViewModelRecebimento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "quantidade deve ser informada.")]
        [Range(1,9999, ErrorMessage ="Quantidade do item ivalida.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "precoUnitatioDoProduto deve ser informado.")]
        [Range(0.01, 9999, ErrorMessage = "Preço unitario do produto do item ivalida")]
        public decimal PrecoUnitarioDoProduto { get; set; }

        [Required(ErrorMessage ="produtoId deve ser informado.")]
        public int ProdutoId { get; set; }
        
    }
}