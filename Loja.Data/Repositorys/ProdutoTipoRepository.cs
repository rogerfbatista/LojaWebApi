using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Loja.Data.Contexto;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;

namespace Loja.Data.Repositorys
{
    public class ProdutoTipoRepository : RepositoryBase<ProdutoTipo>, IProdutoTipoRepository
    {
        public new async Task<ProdutoTipo> GetById(int id)
        {
            using (var loja = new LojaContext())
            {
                return await loja.ProdutoTipo.Where(tipo => tipo.Ativo == true && tipo.ProdutoTipoId == id)
                    .Include(tipo => tipo.Produtos).FirstOrDefaultAsync();
            }
        }
    }


}
