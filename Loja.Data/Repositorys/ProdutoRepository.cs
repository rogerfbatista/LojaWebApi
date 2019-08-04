using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Loja.Data.Contexto;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;

namespace Loja.Data.Repositorys
{
  
    public class ProdutoRepository :RepositoryBase<Produto>,IProdutoRepository
    {
        public new async Task<Produto> GetById(int id)
        {
            using (var loja = new LojaContext())
            {
                return await loja.Produto.Where(produto => produto.ProdutoId == id)
                    .Include(produto => produto.ProdutoEstoques)
                    .Include(produto => produto.ProdutoClienteSaidaItems)
                    .Include(produto => produto.ProdutoFornecedorEntradas)
                    .FirstOrDefaultAsync();
            }
        }


        public async Task<List<Produto>> GetProduto(string val, int empresaId)
        {
            using (var loja = new LojaContext())
            {
                return await (from produto in loja.Produto
                              where produto.Ativo == true
                              && produto.EmpresaId == empresaId
                              && produto.NomeProduto.ToLower().Contains(val.ToLower())
                              select produto
                    ).ToListAsync();
            }
        }


    }
}
