
using Loja.Startup;
using Ninject.Extensions.Wcf;

namespace Loja.WCF.Startup
{
    public class ServiceModule:WcfModule
    {
        public override void Load()
        {
           
           
         NinjectConfig.CreateKernelWcf(this);

        }
    }
}