using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRest.ViewModels
{
    public class LoteViewModelEnvio
    {
        public int Id { get; set; }
        
        public DateTime DataDeFabricacao { get; set; }
        
        public DateTime DataDeValidade { get; set; }

        public int QuantidadeFabricada { get; set; }

        public int QuantidadeEmEstoque { get; set; }

        public decimal CustoUnitarioDeFabricacao { get; set; }
        
        public int ProdutoId { private get; set; }

        public List<object> Links
        {
            get
            {
                return new List<object>()
                {
                    new { rel="self", href="/api/lotes/" + Id},
                    new { rel= "all", href="api/lotes"},
                    new { rel="produto", href="/api/produtos/" +  ProdutoId}
                };
            }
        }

    }
}