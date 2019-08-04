using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clienteService;
        private readonly IClienteContatoService _clienteContatoService;
        private readonly IEmpresaClienteService _empresaClienteService;


        public ClienteAppService(IClienteService clienteService, IClienteContatoService clienteContatoService,
            IEmpresaClienteService empresaClienteService)
            : base(clienteService)
        {
            _clienteService = clienteService;
            _clienteContatoService = clienteContatoService;
            _empresaClienteService = empresaClienteService;
        }

        public new async Task RemoveLogic(int id, Cliente obj)
        {
            var cliente = await _clienteService.GetById(id);

            cliente.Ativo = false;

            foreach (var contato in cliente.ClienteContatos)
            {
                contato.Cliente = null;
            }

            await _clienteService.RemoveLogic(id, cliente);

            foreach (var contato in cliente.ClienteContatos)
            {
                contato.Ativo = false;
                contato.Cliente = null;

                await _clienteContatoService.RemoveLogic(id, contato);

            }

            foreach (var empresaCliente in cliente.EmpresaClientes)
            {

                empresaCliente.Cliente = null;
                empresaCliente.Empresa = null;
                empresaCliente.Ativo = false;
                await _empresaClienteService.RemoveLogic(id, empresaCliente);

            }

        }

        public new async Task Update(Cliente obj)
        {
            var listContatoAdd = new List<ClienteContato>();
            var listContatoUpdate = new List<ClienteContato>();

            foreach (var contato in obj.ClienteContatos)
            {
                if (contato.ClienteContatoId == 0)
                    listContatoAdd.Add(contato);


                if (contato.Ativo == false)
                    listContatoUpdate.Add(contato);
            }
            await _clienteService.Update(obj);

            //add fornecedorContato
            foreach (var fornecedorContato in listContatoAdd)
            {
                await _clienteContatoService.Add(fornecedorContato);
            }


            foreach (var fornecedorContato in listContatoUpdate)
            {
                fornecedorContato.Cliente = null;

                await _clienteContatoService.Update(fornecedorContato);
            }
        }



        public async Task<List<Cliente>> GetAllCliente(int empresaId)
        {
            return await _clienteService.GetAllCliente(empresaId);
        }


        public async Task<List<Cliente>> GetCliente(string val, int empresaId)
        {
            return await _clienteService.GetCliente(val, empresaId);
        }
    }

}

