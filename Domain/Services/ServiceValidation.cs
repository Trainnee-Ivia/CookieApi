using Domain.Interfaces;
using Domain.Objetos;
using System.Linq;

namespace Domain.Services
{
    public class ServiceValidation
    {

        public static Produto Exists(int produtoId, IRepositoryProduto produtos)
        {
            Produto p = produtos.ObterPorId(produtoId);
            if (p != null)
                return p;
            return null;
        }

        public static PontoDeVenda Exists(int pontoDeVendaId, string userId, IRepositoryPontoDeVenda pontosDeVenda)
        {
            PontoDeVenda p = pontosDeVenda.ObterTodos(pdv => pdv.UserId == userId && pdv.Id == pontoDeVendaId).FirstOrDefault();
            if (p != null)
                return p;
            return null;
        }

        public static Lote Exists(int loteId, IRepositoryLote lotes)
        {
            Lote l = lotes.ObterPorId(loteId);
            if( l != null)
                return l;
            return null;
        }

        public static Pedido Exists(int pedidoId, string userId, IRepositoryPedido pedidos)
        {
            Pedido p = pedidos.ObterTodosComTudo(pd => pd.PontoDeVenda.UserId == userId && pd.Id == pedidoId).FirstOrDefault();
            if (p != null)
                return p;
            return null;
        }

        
    }
}
