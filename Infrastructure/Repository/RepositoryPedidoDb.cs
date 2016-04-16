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

        public Pedido ObterPorIdComItens(int id)
        {
            return CookieDbContext.Pedidos.Include("ItensDoPedido").Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
