using ApiRest.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Objetos;
using Domain.Services;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRest.Controllers
{
    [RoutePrefix("api/produtos")]
    public class ProdutosController : ApiController
    {
        private IRepositoryProduto _repositoryProdutos;

        public ProdutosController(IRepositoryProduto produtos)
        {
            _repositoryProdutos = produtos;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllProdutos()
        {
            var produtos = new List<object>();
            foreach(var produto in _repositoryProdutos.ObterTodos())
                produtos.Add(Mapper.Map<Produto, ProdutoViewModel>(produto));

            var response = Request.CreateResponse(HttpStatusCode.Accepted, produtos);

            return response;            
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetById([FromUri]int id)
        {
            if (!ServiceValidation.Exists(id, _repositoryProdutos))
                Request.CreateResponse(HttpStatusCode.NotFound);

            var produto = Mapper.Map<Produto, ProdutoViewModel>(_repositoryProdutos.ObterPorId(id));
            var response = Request.CreateResponse(HttpStatusCode.Accepted, produto);

            return response;
        }


        [HttpPost]
        [Route("")]
        public HttpResponseMessage PostProduto([FromBody] ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) {
                var errors = ModelState.Select(m => string.Join(",", m.Value.Errors.Select(e => e.ErrorMessage)));
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Errors = errors });
            }
            var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);

            _repositoryProdutos.Inserir(produto);
            ((RepositoryProdutoDb)_repositoryProdutos).CookieDbContext.SaveChanges();

            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri("/api/produtos/" + produto.Id);

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
