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
    [RoutePrefix("api/lotes")]
    public class LotesController : ApiController
    {
		private IUnitOfWork _uow;

		public LotesController(IUnitOfWork uow)
        {
			_uow = uow;
		}

        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage GetAllLotes()
        {
            var lotes = new List<object>();
            foreach (var lote in _uow.LoteRepository.ObterTodos())
                lotes.Add(Mapper.Map<Lote, LoteViewModelEnvio>(lote));

            var response = Request.CreateResponse(HttpStatusCode.Accepted, lotes);

            return response;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage GetByIdLote([FromUri]int id)
        {
            Lote lote = ServiceValidation.Exists(id, _uow.LoteRepository);
            if (lote == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            var loteView = Mapper.Map<Lote, LoteViewModelEnvio>(lote);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, loteView);

            return response;
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage PostLote([FromBody] LoteViewModelRecebimento loteViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(m => string.Join(",", m.Value.Errors.Select(e => e.ErrorMessage)));
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Errors = errors });
            }
            var lote = Mapper.Map<LoteViewModelRecebimento, Lote>(loteViewModel);

			lote.DataDeValidade = lote.DataDeFabricacao.AddDays(_uow.ProdutoRepository.ObterPorId(lote.ProdutoId).DiasValidos);
			
            _uow.LoteRepository.Inserir(lote);
			_uow.SalvarAlteracoes();

            var response = Request.CreateResponse(HttpStatusCode.Created);
			response.Headers.Location = new Uri(HttpContext.Current.Request.Url.AbsoluteUri + '/' + lote.Id);
            return response;
        }
    }
}
