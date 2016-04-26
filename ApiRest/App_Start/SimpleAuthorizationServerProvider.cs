using Infrastructure.Model;
using Infrastructure.Repository;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiRest.App_Start
{
    internal class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var tipo = "";
            var id = "";

            using (RepositoryAuthDb _repo = new RepositoryAuthDb())
            {
                ApplicationUser user = await _repo.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
                id = user.Id;
                tipo = user.TipoUser;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            
            identity.AddClaim(new Claim("sub", context.UserName));
            
            identity.AddClaim(new Claim(ClaimTypes.Name, id));
            identity.AddClaim(new Claim(ClaimTypes.Role, tipo));
            
           
            context.Validated(identity);

        }
    }
}