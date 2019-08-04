using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.WCF.InterfaceContract;

namespace Loja.WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ClienteService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ClienteService.svc or ClienteService.svc.cs at the Solution Explorer and start debugging.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ClienteService :  IClienteContractService
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteService(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }



        [WebGet(RequestFormat = WebMessageFormat.Json)]
        public async Task<List<Cliente>> GetAll()
        {
            try
            {
                return await _clienteAppService.GetAll(cliente => cliente.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<Cliente> Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _clienteAppService.Dispose();
        }
    }
}
