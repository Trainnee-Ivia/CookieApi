using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRest.ViewModels
{
    public class LoteViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Data de fabricação invalida.")]
        [Timestamp]
        public DateTime DataDeFabricacao { get; set; }
        [Required(ErrorMessage = "Data de validação invalida.")]
        [Timestamp]
        public DateTime DataDeValidade { get; set; }

        [Required(ErrorMessage ="Quantidade de fabricação invalida.")]
        [Range(1, 9999,ErrorMessage = "Quantidade de fabricação invalida.")]
        public int QuantidadeFabricada { get; set; }

        [Required(ErrorMessage = "Quantidade de fabricação invalida.")]
        [Range(1, 9999, ErrorMessage = "Quantidade de fabricação invalida.")]
        public int QuantidadeEmEstoque { get; set; }

        [Required(ErrorMessage = "Custo unitario invalida.")]
        [Range(1, 9999, ErrorMessage = "Custo unitario invalida.")]
        public decimal CustoUnitarioDeFabricacao { get; set; }
        
        public int ProdutoId { private get; set; }

        public List<object> Links
        {
            get
            {
                return new List<object>()
                {
                    new { rel="self", href="/lotes/" + Id},
                    new { rel="produto", href="/produtos/" +  ProdutoId}
                };
            }
        }
    }
}