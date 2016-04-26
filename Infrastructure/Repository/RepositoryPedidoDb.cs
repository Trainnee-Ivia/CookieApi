using Domain.Interfaces;
using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryPedidoDb : Repository<Pedido>, IRepositoryPedido
    {

        public RepositoryPedidoDb(CookieDbContext context): base(context)
        {

        }

        public CookieDbContext CookieDbContext
        {
            get { return Context as CookieDbContext; }
        }

        public IEnumerable<Pedido> ObterTodosPedidosDoUsuario(string userId)
        {
            return CookieDbContext.Pedidos.Where(p => p.PontoDeVenda.UserId == userId).ToList();
        }

        public IEnumerable<Pedido> ObterTodosComTudo(Func<Pedido, bool> predicate)
        {
            return CookieDbContext.Pedidos.Include("PontoDeVenda").Include("ItensDoPedido").Where(predicate).ToList();
        }
    }
}
