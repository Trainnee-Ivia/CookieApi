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
        [Authorize(Roles = "Admin, Ponto")]
        public HttpResponseMessage GetAllPontoDeVendas()
        {

            var pontos = new List<object>();
            var idUser = User.Identity.Name;
            foreach (var pontoDeVenda in _uow.PontoDeVendaRepository.ObterTodos(p => p.UserId == idUser))
                pontos.Add(Mapper.Map<PontoDeVenda, PontoDeVendaViewModel>(pontoDeVenda));

            var response = Request.CreateResponse(HttpStatusCode.Accepted, pontos);

            return response;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin, Ponto")]
        public HttpResponseMessage GetByIdPontoDeVenda([FromUri]int id)
        {
            var idUser = User.Identity.Name;
            PontoDeVenda ponto = ServiceValidation.Exists(id, idUser, _uow.PontoDeVendaRepository);
            if (ponto == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            
            var pontoView = Mapper.Map<PontoDeVenda, PontoDeVendaViewModel>(ponto);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, pontoView);

            return response;
        }


        [HttpPost]
        [Route("")]
        [Authorize(Roles = "Admin, Ponto")]
        public HttpResponseMessage PostPontoDeVenda([FromBody] PontoDeVendaViewModel pontoDeVendaViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(m => string.Join(",", m.Value.Errors.Select(e => e.ErrorMessage)));
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Errors = errors });
            }
            var ponto = Mapper.Map<PontoDeVendaViewModel, PontoDeVenda>(pontoDeVendaViewModel);
            var idUser = User.Identity.Name;
            ponto.UserId = idUser;
			_uow.PontoDeVendaRepository.Inserir(ponto);
			_uow.SalvarAlteracoes();

            var response = Request.CreateResponse(HttpStatusCode.Created);
			response.Headers.Location = new Uri(HttpContext.Current.Request.Url.AbsoluteUri + '/' + ponto.Id);

            return response;
        }
    }
}
