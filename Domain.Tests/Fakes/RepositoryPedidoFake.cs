using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Objetos;

namespace Domain.Tests.Fakes
{
    public class RepositoryPedidoFake : IRepositoryPedido
    {
        private List<Pedido> _pedidos;

        public RepositoryPedidoFake()
        {
            _pedidos = new List<Pedido>();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Pedido Entity)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Pedido Entity)
        {
            _pedidos.Add(Entity);
        }

        public Pedido ObterPorId(int? id)
        {
            return _pedidos.Find(p => p.Id == id);
        }

        public IEnumerable<Pedido> ObterTodos()
        {
            return _pedidos;
        }

        public IEnumerable<Pedido> ObterTodos(Func<Pedido, bool> predicate)
        {
            return _pedidos.Where(predicate);
        }
    }
}
