using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Objetos;

namespace Domain.Tests.Fakes
{
    public class RepositoryPontoDeVendaFake : IRepositoryPontoDeVenda
    {
        private List<PontoDeVenda> _pontosDeVenda;

        public RepositoryPontoDeVendaFake()
        {
            _pontosDeVenda = new List<PontoDeVenda>();
            var enderecoPonto = new Endereco("Rua Beija Flor", 101, "A", "04953656377");
            var pontoDeVenda = new PontoDeVenda(1, "85999999999", "Ponto1", "Michel", enderecoPonto);
            _pontosDeVenda.Add(pontoDeVenda);
        }
        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(PontoDeVenda Entity)
        {
            throw new NotImplementedException();
        }

        public void Inserir(PontoDeVenda Entity)
        {
            _pontosDeVenda.Add(Entity);
        }

        public PontoDeVenda ObterPorId(int? id)
        {
            return _pontosDeVenda.Find(p => p.Id == id);
        }

        public IEnumerable<PontoDeVenda> ObterTodos()
        {
            return _pontosDeVenda;
        }

        public IEnumerable<PontoDeVenda> ObterTodos(Func<PontoDeVenda, bool> predicate)
        {
            return _pontosDeVenda.Where(predicate);
        }
    }
}
