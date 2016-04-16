using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRest.ViewModels
{
    public class LoteViewModelRecebimento
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="dataDeFabricacao deve ser informada.")]
        public DateTime DataDeFabricacao { get; set; }

        [Required(ErrorMessage ="quantidadeFabricada deve ser informada.")]
        [Range(1, 9999,ErrorMessage = "quantidadeFabricada invalida.")]
        public int QuantidadeFabricada { get; set; }

        [Required(ErrorMessage = "quantidadeEmEstoque deve ser informada.")]
        [Range(1, 9999, ErrorMessage = "quantidadeEmEstoque invalida.")]
        public int QuantidadeEmEstoque { get; set; }

        [Required(ErrorMessage = "custoUnitarioDeFabricao deve ser informado.")]
        [Range(1, 9999, ErrorMessage = "custoUnitarioDeFabricacao invalida.")]
        public decimal CustoUnitarioDeFabricacao { get; set; }
        
        [Required(ErrorMessage = "ProdutoId deve ser informado.")]
        public int ProdutoId { get; set; }

    }
}