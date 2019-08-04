using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Loja.Data.Contexto;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;

namespace Loja.Data.Repositorys
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {

        public new async Task<Fornecedor> GetById(int id)
        {
            using (var loja = new LojaContext())
            {

                return await loja.Fornecedor.Where(fornecedor => fornecedor.FornecedorId == id)
                    .Include(fornecedor => fornecedor.FornecedorContatos)
                    .Include(fornecedor => fornecedor.EmpresaFornecedores)
                    .FirstAsync();
            }
        }

        public async Task<List<Fornecedor>> GetAllFornecedor(int empresaId)
        {

            using (var loja = new LojaContext())
            {
                return await (from fornecedor in loja.Fornecedor
                              join empresaFornecedor in loja.EmpresaFornecedor
                             on fornecedor.FornecedorId equals empresaFornecedor.FornecedorId
                              where fornecedor.Ativo == true
                              && empresaFornecedor.EmpresaId == empresaId
                              select fornecedor
                    ).ToListAsync();
            }

        }

        public async Task<List<Fornecedor>> GetForncedor(string val, int empresaId)
        {
            using (var loja = new LojaContext())
            {
                return await (from fornecedor in loja.Fornecedor
                              join empresaFornecedor in loja.EmpresaFornecedor
                             on fornecedor.FornecedorId equals empresaFornecedor.FornecedorId
                              where fornecedor.Ativo == true
                              && empresaFornecedor.EmpresaId == empresaId
                              &&  fornecedor.NomeFornecedor.ToLower().Contains(val.ToLower())
                              select fornecedor
                    ).ToListAsync();
            }
        }

       
    }



}
