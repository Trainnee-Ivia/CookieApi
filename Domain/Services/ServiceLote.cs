using Domain.Interfaces;
using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceLote : IServiceCRUD<Lote>
    {

        private IUnitOfWork _uow;

        public ServiceLote(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public void Atualizar(Lote entity)
        {
            var lote = _uow.LoteRepository.ObterPorId(entity.Id);
            lote.DataDeFabricacao = entity.DataDeFabricacao;
            lote.DataDeValidade = entity.DataDeValidade;
            lote.CustoUnitarioDeFabricacao = entity.CustoUnitarioDeFabricacao;
            lote.QuantidadeEmEstoque = entity.QuantidadeEmEstoque;
            lote.QuantidadeFabricada = entity.QuantidadeFabricada;

            _uow.SalvarAlteracoes();
        }

        public IEnumerable<Lote> Buscar()
        {
            return _uow.LoteRepository.ObterTodos();
        }

        public IEnumerable<Lote> Buscar(Func<Lote, bool> predicate)
        {
            return _uow.LoteRepository.ObterTodos(predicate);
        }

        public void Cadastrar(Lote entity)
        {
            _uow.LoteRepository.Inserir(entity);
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Lote entity)
        {
            throw new NotImplementedException();
        }
    }
}
