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
    
    [RoutePrefix("api/pedidos")]
    public class PedidosController : ApiController
    {
        private IUnitOfWork _uow;

        public PedidosController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllPedidos()
        {
            var pedidos = new List<object>();
            foreach (var pedido in _uow.PedidoRepository.ObterTodos())
                pedidos.Add(Mapper.Map<Pedido, PedidoViewModelEnvio>(pedido));

            var response = Request.CreateResponse(HttpStatusCode.Accepted, pedidos);

            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetByIdPedido([FromUri]int id)
        {
            if (!ServiceValidation.Exists(id, _uow.PedidoRepository))
                Request.CreateResponse(HttpStatusCode.NotFound);

            var pedido = Mapper.Map<Pedido, PedidoViewModelEnvio>(_uow.PedidoRepository.ObterPorId(id));
            var response = Request.CreateResponse(HttpStatusCode.Accepted, pedido);

            return response;
        }

        [HttpGet]
        [Route("{id}/itens")]
        public HttpResponseMessage GetItensDoPedido([FromUri]int id)
        {
            var itens = new List<object>();

            if (!ServiceValidation.Exists(id, _uow.PedidoRepository))
                Request.CreateResponse(HttpStatusCode.NotFound);

            foreach (var item in _uow.PedidoRepository.ObterPorIdComItens(id).ItensDoPedido)
                itens.Add(Mapper.Map<ItemDoPedido, ItemDoPedidoViewModelEnvio>(item));

            var response = Request.CreateResponse(HttpStatusCode.Accepted, itens);

            return response;
        }

        [HttpGet]
        [Route("{idPedido}/itens/id")]
        public HttpResponseMessage GetByIdItemDoPedido([FromUri] int idPedido, [FromUri]int id)
        {
            if (!ServiceValidation.Exists(idPedido, _uow.PedidoRepository))
                Request.CreateResponse(HttpStatusCode.NotFound);

            var item = _uow.PedidoRepository.ObterPorIdComItens(idPedido).ItensDoPedido.Find(e => e.Id == id);
            var itemView = Mapper.Map<ItemDoPedido, ItemDoPedidoViewModelEnvio>(item);

            var response = Request.CreateResponse(HttpStatusCode.Accepted, itemView);

            return response;
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage PostProduto([FromBody] PedidoViewModelRecebimento pedidoViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(m => string.Join(",", m.Value.Errors.Select(e => e.ErrorMessage)));
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Errors = errors });
            }
            var pedido = Mapper.Map<PedidoViewModelRecebimento, Pedido>(pedidoViewModel);

            var servicePedido = new ServicePedido(_uow);

            servicePedido.CompletarPedido(pedido);

            var response = Request.CreateResponse(HttpStatusCode.Created);
           

            return response;
        }

        
    }
}
