using ApiRest.ViewModels;
using AutoMapper;
using Domain.Objetos;
using Infrastructure.Model;
using Infrastructure.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ApiRest.Controllers
{
    [RoutePrefix("api/contas")]
    public class ContasController : ApiController
    {
        public RepositoryAuthDb _repositoryAuth;
        public RepositoryUsuarioDb _repositoryUsuario;
        public ContasController(RepositoryAuthDb repositoryAuth, RepositoryUsuarioDb repositoryUser)
        {
            _repositoryAuth = repositoryAuth;
            _repositoryUsuario = repositoryUser;
        }

        [AllowAnonymous]
        [Route("registrar")]
        [HttpPost]
        public HttpResponseMessage Registrar(UserModel userModel)
        {

            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            IdentityResult result = _repositoryAuth.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, errorResult);
            }
            var user = _repositoryUsuario.ObterPorEmail(userModel.Email);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(HttpContext.Current.Request.Url.AbsoluteUri.Replace("registrar", "") + "user");
            return response;
        }
        
        [HttpGet]
        [Route("user")]
        [Authorize(Roles = "Ponto")]
        public HttpResponseMessage GetUser()
        {
            var userId = User.Identity.Name;
            var pedido = Mapper.Map<Usuario, UsuarioViewModel>(_repositoryUsuario.ObterPorId(userId));
            var response = Request.CreateResponse(HttpStatusCode.Accepted, pedido);

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repositoryAuth.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}

