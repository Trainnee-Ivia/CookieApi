using Domain.Interfaces;
using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServicePontoDeVenda : IServiceCRUD<PontoDeVenda>
    {
        private IUnitOfWork _uow;
        public ServicePontoDeVenda(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public void Atualizar(PontoDeVenda entity)
        {
            var pdv = _uow.PontoDeVendaRepository.ObterPorId(entity.Id);
            pdv.Nome = entity.Nome;
            pdv.NomeDoContato = entity.NomeDoContato;
            pdv.Telefone = entity.Telefone;
            pdv.Endereco = entity.Endereco;

            _uow.SalvarAlteracoes();
        }

        public IEnumerable<PontoDeVenda> Buscar()
        {
            return _uow.PontoDeVendaRepository.ObterTodos();
        }

        public IEnumerable<PontoDeVenda> Buscar(Func<PontoDeVenda, bool> predicate)
        {
            return _uow.PontoDeVendaRepository.ObterTodos(predicate);
        }

        public void Cadastrar(PontoDeVenda entity)
        {
            _uow.PontoDeVendaRepository.Inserir(entity);
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(PontoDeVenda entity)
        {
            throw new NotImplementedException();
        }
    }
}
