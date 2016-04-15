using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Objetos
{
    public class Lote
    {
        
        public int Id { get; set; }
        public DateTime DataDeFabricacao { get; set; }
        public DateTime DataDeValidade { get; set; }
        public int QuantidadeFabricada { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public decimal CustoUnitarioDeFabricacao { get; set; }

        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        private Lote() { }

        public Lote(DateTime dataDeFabricacao, DateTime dataDeValidade,
                    int quantidadeFabricada, int quantidadeEmEstoque,
                    decimal custoUnitarioDeFabricacao, Produto produto)
        {

            DataDeFabricacao = dataDeFabricacao;
            DataDeValidade = dataDeValidade;
            QuantidadeFabricada = quantidadeFabricada;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            CustoUnitarioDeFabricacao = custoUnitarioDeFabricacao;
            Produto = produto;
            ProdutoId = produto.Id;

        }
    }
}
