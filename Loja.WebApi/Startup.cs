
using System;
using System.Web.Http;
using Loja.Application.Interfaces;
using Loja.Startup;
using Loja.WebApi.Security;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

namespace Loja.WebApi
{

    public class Startup
    {

        #region Métodos

        public void Configuration(IAppBuilder app)
        {


            var config = new HttpConfiguration();
            ConfigureOAuth(app,CreateKernel());
            WebApiConfig.Register(config);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);
          app.UseCors(CorsOptions.AllowAll);
           //  app.UseWebApi(config);
            app.MapSignalR();

        }

        private IKernel CreateKernel()
        {
            return NinjectConfig.CreateKernel();
        }

        public void ConfigureOAuth(IAppBuilder app, IKernel kernel)
        {
            var usuarioAppService = kernel.Get<IUsuarioAppService>();

            var oAuth = new OAuthAuthorizationServerOptions()
            {

                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new AuthAuthorizationServerProvider(usuarioAppService),
            };
            app.UseOAuthAuthorizationServer(oAuth);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        #endregion

    }
}