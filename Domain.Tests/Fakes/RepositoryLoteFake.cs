using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Objetos;

namespace Domain.Tests.Fakes
{
    public class RepositoryLoteFake : IRepositoryLote
    {
        private List<Lote> _lotes;

        public RepositoryLoteFake()
        {
            _lotes = new List<Lote>();
            var produto = new Produto(1, "Tradicional", 15, 3.23m);
            var lote = new Lote(1, DateTime.Now, DateTime.Now.AddDays(produto.DiasValidos), 10, 10, 3.4m, produto);
            _lotes.Add(lote);
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Lote Entity)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Lote Entity)
        {
            _lotes.Add(Entity);
        }

        public IEnumerable<Lote> ObterLotesDisponiveisParaRetirada(int diasValidos, Produto produto)
        {
            return _lotes.Where(l => l.DataDeValidade >= DateTime.Now.AddDays(diasValidos) && l.ProdutoId == produto.Id);
        }

        public Lote ObterPorId(int? id)
        {
            return _lotes.Find(l => l.Id == id);
        }

        public IEnumerable<Lote> ObterTodos()
        {
            return _lotes;
        }

        public IEnumerable<Lote> ObterTodos(Func<Lote, bool> predicate)
        {
            return _lotes.Where(predicate);
        }
    }
}
