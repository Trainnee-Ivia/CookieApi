using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Objetos;

namespace Domain.Tests.Fakes
{
    public class RepositoryProdutoFake : IRepositoryProduto
    {
        private List<Produto> _produtos;

        public RepositoryProdutoFake()
        {
            _produtos = new List<Produto>();
            var produto = new Produto(1, "Tradicional", 15, 3.20m);
            _produtos.Add(produto);
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Produto Entity)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Produto Entity)
        {
            _produtos.Add(Entity);
        }

        public Produto ObterPorId(int? id)
        {
            return _produtos.Find(p => p.Id == id);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _produtos;
        }

        public IEnumerable<Produto> ObterTodos(Func<Produto, bool> predicate)
        {
            return _produtos.Where(predicate);
        }
    }
}
