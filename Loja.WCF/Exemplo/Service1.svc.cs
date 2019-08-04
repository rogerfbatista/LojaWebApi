using System;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace Loja.WCF.Exemplo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        [WebGet(RequestFormat = WebMessageFormat.Json)]
        public async Task<string> GetName(string nome)
        {
            Task.Delay(1000);

            return await Task.Factory.StartNew(() => string.Format("Seu Nome é {0}", nome));
        }

        public async Task<CompositeType> GetDataUsingDataContract(CompositeType composite)
        {
            return await Task.Run(() =>
              {
                  if (composite == null)
                  {
                      throw new ArgumentNullException("composite");
                  }
                  if (composite.BoolValue)
                  {
                      composite.StringValue += "Suffix";
                  }
                  return composite;
              });
        }
    }
}
