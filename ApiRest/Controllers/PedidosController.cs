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
        [Authorize(Roles = "Admin, Ponto")]
        public HttpResponseMessage GetAllPedidos()
        {
            var pedidos = new List<object>();
            var userId = User.Identity.Name;
            foreach (var pedido in _uow.PedidoRepository.ObterTodosPedidosDoUsuario(userId))
                pedidos.Add(Mapper.Map<Pedido, PedidoViewModelEnvio>(pedido));

            var response = Request.CreateResponse(HttpStatusCode.Accepted, pedidos);

            return response;
        }



        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin, Ponto")]
        public HttpResponseMessage GetByIdPedido([FromUri]int id)
        {
            var userId = User.Identity.Name;
            Pedido pedido = ServiceValidation.Exists(id, userId, _uow.PedidoRepository);
            if (pedido == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            var pedidoView = Mapper.Map<Pedido, PedidoViewModelEnvio>(pedido);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, pedidoView);

            return response;
        }

        [HttpGet]
        [Route("{id}/itens")]
        public HttpResponseMessage GetItensDoPedido([FromUri]int id)
        {
            var itens = new List<object>();
            var userId = User.Identity.Name;
            Pedido pedido = ServiceValidation.Exists(id, userId, _uow.PedidoRepository);
            if (pedido == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            foreach (var item in pedido.ItensDoPedido)
                itens.Add(Mapper.Map<ItemDoPedido, ItemDoPedidoViewModelEnvio>(item));

            var response = Request.CreateResponse(HttpStatusCode.Accepted, itens);

            return response;
        }

        [HttpGet]
        [Route("{idPedido}/itens/id")]
        public HttpResponseMessage GetByIdItemDoPedido([FromUri] int idPedido, [FromUri]int id)
        {
            var userId = User.Identity.Name;
            Pedido pedido = ServiceValidation.Exists(idPedido, userId, _uow.PedidoRepository);
            if (pedido == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            var item = pedido.ItensDoPedido.Find(e => e.Id == id);
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

            var userId = User.Identity.Name;
            PontoDeVenda ponto = ServiceValidation.Exists(pedido.PontoDeVenda.Id, userId, _uow.PontoDeVendaRepository);
            if (ponto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Usuário do ponto de venda invalido.");

            try
            {
                var servicePedido = new ServicePedido(_uow);

                servicePedido.CompletarPedido(pedido);
                var response = Request.CreateResponse(HttpStatusCode.Created);
				response.Headers.Location = new Uri(HttpContext.Current.Request.Url.AbsoluteUri + '/' + pedido.Id);
                return response;

            }
            catch (InvalidOperationException err)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = err.Message });
            }
        }

        
    }
}
