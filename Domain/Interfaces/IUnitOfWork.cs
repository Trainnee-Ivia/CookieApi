using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryProduto ProdutoRepository { get; }
        IRepositoryPontoDeVenda PontoDeVendaRepository { get; }
        IRepositoryLote LoteRepository { get; }
        IRepositoryPedido PedidoRepository { get; }

        void SalvarAlteracoes();
    }
}
