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
		private IUnitOfWork _uow;

        public PontosDeVendaController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllPontoDeVendas()
        {
            var pontos = new List<object>();
            foreach (var pontoDeVenda in _uow.PontoDeVendaRepository.ObterTodos())
                pontos.Add(Mapper.Map<PontoDeVenda, PontoDeVendaViewModel>(pontoDeVenda));

            var response = Request.CreateResponse(HttpStatusCode.Accepted, pontos);

            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetByIdPontoDeVenda([FromUri]int id)
        {
            if (!ServiceValidation.Exists(id, _uow.PontoDeVendaRepository))
                return Request.CreateResponse(HttpStatusCode.NotFound);
            var ponto = Mapper.Map<PontoDeVenda, PontoDeVendaViewModel>(_uow.PontoDeVendaRepository.ObterPorId(id));
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

			_uow.PontoDeVendaRepository.Inserir(ponto);
			_uow.SalvarAlteracoes();

            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri("http://localhost:52058/api/pontos/" + ponto.Id);

            return response;
        }
    }
}
