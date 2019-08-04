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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmpresaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmpresaService.svc or EmpresaService.svc.cs at the Solution Explorer and start debugging.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class EmpresaService : IEmpresaContractService
    {
        private readonly IEmpresaAppService _empresaAppService;

        public EmpresaService(IEmpresaAppService empresaAppService)
        {
            _empresaAppService = empresaAppService;
        }


        [WebGet(RequestFormat = WebMessageFormat.Json)]
        public async Task<List<Empresa>> GetAll()
        {
            try
            {

                return await _empresaAppService.GetAll(empresa => empresa.Ativo == true);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        public async Task<Empresa> Get(int id)
        {
            try
            {
                return await _empresaAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Add(Empresa obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Empresa obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Empresa obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            try
            {
                _empresaAppService.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
