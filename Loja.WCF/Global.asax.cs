using System.ServiceModel.Activation;
using System.Web.Routing;
using Loja.WCF.Exemplo;
using Loja.WCF.Services;
using Loja.WCF.Startup;
using Ninject;
using Ninject.Extensions.Wcf;
using Ninject.Web.Common;

namespace Loja.WCF
{
    public class Global : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            // We replace WebServiceHostFactory with NinjectWebServiceHostFactory so Ninject can handle creation of
            // the services using the Ninjection kernel for each inbound request.
            //RouteTable.Routes.Add(new ServiceRoute("Service1", new WebServiceHostFactory(), typeof(Service1)));
            RouteTable.Routes.Add(new ServiceRoute("Service1", new NinjectWebServiceHostFactory(), typeof(Service1)));
            RouteTable.Routes.Add(new ServiceRoute("ClienteService", new NinjectWebServiceHostFactory(), typeof(ClienteService)));
            RouteTable.Routes.Add(new ServiceRoute("EmpresaService", new NinjectWebServiceHostFactory(), typeof(EmpresaService)));
        }


        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new ServiceModule());
        }
    }
}