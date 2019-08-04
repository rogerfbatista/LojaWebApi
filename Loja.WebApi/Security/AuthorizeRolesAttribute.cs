using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Loja.Application.Interfaces;
using Loja.Startup;
using Ninject;

namespace Loja.WebApi.Security
{
      
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            try
            {

                var identity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
                var claims = identity.Claims;
                var idRole = 0;

                var firstOrDefault = claims.FirstOrDefault();

                if (firstOrDefault != null)
                {
                    idRole = Convert.ToInt32(firstOrDefault.ValueType);
                }

                var servico = actionContext.Request.RequestUri.Segments[2].Replace("/","").Trim();


                var kernel = NinjectConfig.CreateKernel();
                using (var servicoUsuarioPerfil = kernel.Get<IServicoUsuarioPerfilAppService>())
                {
                    var listServico = await servicoUsuarioPerfil.GetServicoUsarioPerilList(perfil =>
                        perfil.Ativo == true && perfil.UsuarioPerfilId == idRole && String.Equals(perfil.Servico.NomeServico,servico, StringComparison.OrdinalIgnoreCase));

                    Roles = listServico.Any() ? string.Join(",", new[] { listServico.First().UsuarioPerfil.NomeUsuarioPerfil }) : "AcessoNegado";
                }

                await base.OnAuthorizationAsync(actionContext, cancellationToken);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }





    }
}