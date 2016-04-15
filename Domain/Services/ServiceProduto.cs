using Domain.Interfaces;
using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceProduto : IServiceCRUD<Produto>
    {

        private IUnitOfWork _uow;

        public ServiceProduto(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public void Atualizar(Produto entity)
        {
            var produto = _uow.ProdutoRepository.ObterPorId(entity.Id);
            produto.Nome = entity.Nome;
            produto.DiasValidos = entity.DiasValidos;
            produto.Preco = entity.Preco;

            _uow.SalvarAlteracoes();
        }

        public IEnumerable<Produto> Buscar()
        {
            return _uow.ProdutoRepository.ObterTodos();
        }

        public IEnumerable<Produto> Buscar(Func<Produto, bool> predicate)
        {
            return _uow.ProdutoRepository.ObterTodos(predicate);
        }

        public void Cadastrar(Produto entity)
        {
            _uow.ProdutoRepository.Inserir(entity);
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Produto entity)
        {
            throw new NotImplementedException();
        }

    }
}
