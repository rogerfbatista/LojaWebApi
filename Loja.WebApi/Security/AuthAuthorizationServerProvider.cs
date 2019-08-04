using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Common.Resources;
using Loja.Domain.Entities;
using Microsoft.Owin.Security.OAuth;

namespace Loja.WebApi.Security
{
    [MyCorsPolicy]
    public class AuthAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        //=> Obter Perfil do usuario no retorno do acces_token
        private Dictionary<string, string> _roles;
        private Usuario _usuario;

        private readonly IUsuarioAppService _usuarioAppService;

        public AuthAuthorizationServerProvider(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        #region Métodos

        public override async  Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            
            context.Validated();


            await Task.FromResult(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var roles = new List<string>();
            _roles = new Dictionary<string, string>();

            context.OwinContext.Response.Headers.Remove("Cache-Control");
           context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            

            try
            {


                _usuario = await _usuarioAppService.Authenticantion(context.UserName, context.Password);

                    if (_usuario == null)
                        throw new Exception(Errors.UserNotFound);


                    identity.AddClaim(new Claim(ClaimTypes.Role, _usuario.UsuarioPerfil.NomeUsuarioPerfil, _usuario.UsuarioPerfil.UsuarioPerfilId.ToString("")));
                    roles.Add(_usuario.UsuarioPerfil.NomeUsuarioPerfil);
                    _roles.Add(_usuario.UsuarioPerfil.NomeUsuarioPerfil, _usuario.UsuarioPerfil.UsuarioPerfilId.ToString(""));
                



                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

                var principal = new GenericPrincipal(identity, roles.ToArray());

                Thread.CurrentPrincipal = principal;
                

                await Task.FromResult(context.Validated(identity));
            }
            catch (Exception ex)
            {

                context.SetError("invalid_grant", ex.Message);
            }
        }

        public override async Task TokenEndpoint(OAuthTokenEndpointContext context)
        {


           
                context.AdditionalResponseParameters.Add("empresaId", _usuario.EmpresaId);
                context.AdditionalResponseParameters.Add("ImagemUsuario", _usuario.ImagemUsuario);
                context.AdditionalResponseParameters.Add("EmpresaImagem", _usuario.Empresa.EmpresaImagem);
                context.AdditionalResponseParameters.Add("NomeEmpresa", _usuario.Empresa.NomeEmpresa);

            foreach (var role in _roles)
            {
                context.AdditionalResponseParameters.Add("roles", role.Key);
                context.AdditionalResponseParameters.Add("IdRole", role.Value);
            }

            await Task.FromResult(context);

        }

        #endregion
    }
}