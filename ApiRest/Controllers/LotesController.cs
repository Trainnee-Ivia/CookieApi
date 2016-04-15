using ApiRest.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Objetos;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRest.Controllers
{
    [RoutePrefix("api/lotes")]
    public class LotesController : ApiController
    {
        private IRepositoryLote _repositoryLotes;

        public LotesController(IRepositoryLote lotes)
        {
            _repositoryLotes = lotes;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllLotes()
        {
            var lotes = new List<object>();
            foreach (var lote in _repositoryLotes.ObterTodos())
                lotes.Add(Mapper.Map<Lote, LoteViewModel>(lote));

            var response = Request.CreateResponse(HttpStatusCode.Accepted, lotes);

            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetByIdLote([FromUri]int id)
        {
            var lote = Mapper.Map<Lote, LoteViewModel>(_repositoryLotes.ObterPorId(id));
            var response = Request.CreateResponse(HttpStatusCode.Accepted, lote);

            return response;
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage PostProduto([FromBody] LoteViewModel loteViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(m => string.Join(",", m.Value.Errors.Select(e => e.ErrorMessage)));
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Errors = errors });
            }
            var lote = Mapper.Map<LoteViewModel, Lote>(loteViewModel);

            _repositoryLotes.Inserir(lote);
            ((RepositoryLoteDb)_repositoryLotes).CookieDbContext.SaveChanges();

            var response = Request.CreateResponse(HttpStatusCode.Created, lote);
            return response;
        }
    }
}
