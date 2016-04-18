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
    [RoutePrefix("api/pontos")]
    public class PontosDeVendaController : ApiController
    {
        private IRepositoryPontoDeVenda _repositoryPontosDeVenda;

        public PontosDeVendaController(IRepositoryPontoDeVenda pontosDeVenda)
        {
            _repositoryPontosDeVenda = pontosDeVenda;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllPontoDeVendas()
        {
            var pontos = new List<object>();
            foreach (var pontoDeVenda in _repositoryPontosDeVenda.ObterTodos())
                pontos.Add(Mapper.Map<PontoDeVenda, PontoDeVendaViewModel>(pontoDeVenda));

            var response = Request.CreateResponse(HttpStatusCode.Accepted, pontos);

            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetByIdPontoDeVenda([FromUri]int id)
        {
            if (!ServiceValidation.Exists(id, _repositoryPontosDeVenda))
                return Request.CreateResponse(HttpStatusCode.NotFound);
            var ponto = Mapper.Map<PontoDeVenda, PontoDeVendaViewModel>(_repositoryPontosDeVenda.ObterPorId(id));
            var response = Request.CreateResponse(HttpStatusCode.Accepted, ponto);

            return response;
        }


        [HttpPost]
        [Route("")]
        public HttpResponseMessage PostPontoDeVenda([FromBody] PontoDeVendaViewModel pontoDeVendaViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(m => string.Join(",", m.Value.Errors.Select(e => e.ErrorMessage)));
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Errors = errors });
            }
            var ponto = Mapper.Map<PontoDeVendaViewModel, PontoDeVenda>(pontoDeVendaViewModel);

            _repositoryPontosDeVenda.Inserir(ponto);
            ((RepositoryPontoDeVendaDb)_repositoryPontosDeVenda).CookieDbContext.SaveChanges();

            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri("/api/pontos/" + ponto.Id);

            return response;
        }
    }
}
