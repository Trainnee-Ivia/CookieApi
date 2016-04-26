using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using ApiRest.ViewModels;
using Microsoft.Owin.Security.OAuth;
using ApiRest.App_Start;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

[assembly: OwinStartup(typeof(ApiRest.Startup))]

namespace ApiRest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            AutoMapperConfig.RegisterMappings();
           
            app.UseNinjectMiddleware(() => NinjectWebCommon.CreateKernel.Value).UseNinjectWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
