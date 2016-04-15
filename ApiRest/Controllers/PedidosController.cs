using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRest.Controllers
{
    public class PedidosController : ApiController
    {
        private IUnitOfWork _uow;

        public PedidosController(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
