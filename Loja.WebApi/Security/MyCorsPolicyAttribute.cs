using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;
using System.Web.Http.Filters;

namespace Loja.WebApi.Security
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class MyCorsPolicyAttribute : ActionFilterAttribute, ICorsPolicyProvider
    {
        private CorsPolicy _policy;

        public MyCorsPolicyAttribute()
        {
            // Create a CORS policy.
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true,
                SupportsCredentials = true,
                AllowAnyOrigin = true
            };

            // Add allowed origins.
            _policy.Headers.Remove("Cache-Control");
            //TODO implemntar lista do banco de dados ou' web.config
            _policy.Origins.Add("http://192.168.0.105");
            _policy.Origins.Add("http://192.168.0.111");
            _policy.Origins.Add("http://localhost");
            _policy.Origins.Add("http://localhost:3941");
            _policy.Origins.Add("http://localhost:12165");
            _policy.Origins.Add("http://localhost:25372");
            _policy.Origins.Add("http://localhost:25372/");
            _policy.Origins.Add("http://www.sonicfinanceiro.somee.com");
            _policy.Origins.Add("http://sonicfinanceiro.somee.com");
            _policy.Origins.Add("http://www.sonicti.somee.com/");
            _policy.Origins.Add("http://www.sonicti.somee.com");
            _policy.Origins.Add("www.sonicti.somee.com/");
            _policy.Origins.Add("www.sonicti.somee.com");
            _policy.Origins.Add("http://sonicti.somee.com/");
            _policy.Origins.Add("http://sonicti.somee.com");



        }




        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}