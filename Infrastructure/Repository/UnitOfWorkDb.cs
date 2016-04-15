using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Objetos;

namespace Infrastructure.Repository
{
    public class UnitOfWorkDb : IUnitOfWork
    {
        private bool _disposed;
        private readonly CookieDbContext _context;

        public IRepositoryProduto ProdutoRepository { get { return new RepositoryProdutoDb(_context); } }

        public IRepositoryPontoDeVenda PontoDeVendaRepository { get { return new RepositoryPontoDeVendaDb(_context); } }

        public IRepositoryLote LoteRepository { get { return new RepositoryLoteDb(_context);  } }

        public IRepositoryPedido PedidoRepository { get { return new RepositoryPedidoDb(_context); } }

        public UnitOfWorkDb(CookieDbContext context)
        {
            _context = context;            
        }

        public void SalvarAlteracoes()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
