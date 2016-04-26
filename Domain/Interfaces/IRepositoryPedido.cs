using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryPedido: IRepository<Pedido>
    {
        

        IEnumerable<Pedido> ObterTodosPedidosDoUsuario(string userId);
        IEnumerable<Pedido> ObterTodosComTudo(Func<Pedido, bool> predicate);
    }
}
