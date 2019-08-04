using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Loja.Data.Contexto;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;

namespace Loja.Data.Repositorys
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {

        public new async Task<Cliente> GetById(int id)
        {
            using (var loja = new LojaContext())
            {

                return await loja.Cliente.Where(cliente => cliente.ClienteId == id)
                    .Include(cliente => cliente.ClienteContatos)
                    .Include(cliente => cliente.EmpresaClientes)
                    .FirstAsync();
            }
        }


        public async Task<List<Cliente>> GetAllCliente(int empresaId)
        {
            using (var loja = new LojaContext())
            {
                return await(from cliente in loja.Cliente
                             join empresaCliente in loja.EmpresaClientes
                            on cliente.ClienteId equals empresaCliente.ClienteId
                             where cliente.Ativo == true
                             && empresaCliente.EmpresaId == empresaId
                             select cliente
                    ).ToListAsync();

            }
        }

        public async Task<List<Cliente>> GetCliente(string val, int empresaId)
        {
            using (var loja = new LojaContext())
            {
                return await (from cliente in loja.Cliente
                              join empresaCliente in loja.EmpresaClientes
                             on cliente.ClienteId equals empresaCliente.ClienteId
                              where cliente.Ativo == true
                              && empresaCliente.EmpresaId == empresaId
                              && cliente.NomeCliente.ToLower().Contains(val.ToLower())
                              select cliente
                    ).ToListAsync();
            }
        }

    }

}

