using ApiRest.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Objetos;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ApiRest.Controllers
{
    [RoutePrefix("api/produtos")]
    public class ProdutosController : ApiController
    {
		private IUnitOfWork _uow;
		public ProdutosController(IUnitOfWork uow)
        {
			_uow = uow;
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Ponto, Admin")]
        public HttpResponseMessage GetAllProdutos()
        {
            var produtos = new List<object>();
            foreach(var produto in _uow.ProdutoRepository.ObterTodos())
                produtos.Add(Mapper.Map<Produto, ProdutoViewModel>(produto));

            var response = Request.CreateResponse(HttpStatusCode.Accepted, produtos);
           
            return response;            
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Ponto, Admin")]
        public HttpResponseMessage GetById([FromUri]int id)
        {
            Produto produto = ServiceValidation.Exists(id, _uow.ProdutoRepository);
            if (produto == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            var produtoView = Mapper.Map<Produto, ProdutoViewModel>(produto);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, produtoView);

            return response;
        }


        [HttpPost]
        [Route("")]
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage PostProduto([FromBody] ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) {
                var errors = ModelState.Select(m => string.Join(",", m.Value.Errors.Select(e => e.ErrorMessage)));
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Errors = errors });
            }
            var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);

			_uow.ProdutoRepository.Inserir(produto);
			_uow.SalvarAlteracoes();

            var response = Request.CreateResponse(HttpStatusCode.Created);
			response.Headers.Location = new Uri(HttpContext.Current.Request.Url.AbsoluteUri + '/' + produto.Id);

			return response;
        }

        //[HttpPut]
        //[Route("{id}")]
        //public HttpResponseMessage UpdateProduto([FromUri] int id ,[FromBody] ProdutoViewModel produtoViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Select(m => string.Join(",", m.Value.Errors.Select(e => e.ErrorMessage)));
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, new { Errors = errors });
        //    }

        //    var produtoUpdate = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);

        //    var produto = _repositoryProdutos.ObterPorId(produtoUpdate.Id);

        //    produto.Nome = produtoUpdate.Nome;
        //    produto.Preco = produtoUpdate.Preco;
        //    produto.DiasValidos = produtoUpdate.DiasValidos;

        //    ((RepositoryProdutoDb)_repositoryProdutos).CookieDbContext.SaveChanges();

        //    var response = Request.CreateResponse(HttpStatusCode.OK, produto);
        //    return response;
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //public HttpResponseMessage DeleteProduto([FromUri] int id)
        //{
            
        //    _repositoryProdutos.Excluir(id);

        //    ((RepositoryProdutoDb)_repositoryProdutos).CookieDbContext.SaveChanges();

        //    var response = Request.CreateResponse(HttpStatusCode.OK);
        //    return response;
        //}
    }
}
