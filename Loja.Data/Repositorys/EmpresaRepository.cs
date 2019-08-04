using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Loja.Data.Contexto;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;

namespace Loja.Data.Repositorys
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        private readonly LojaContext _lojaContext;

        public EmpresaRepository(LojaContext lojaContext)
        {
            _lojaContext = lojaContext;
        }


        public new async Task<Empresa> GetById(int id)
        {
            using (var loja = _lojaContext)
            {


                return await loja.Empresas.Where(empresa => empresa.EmpresaId == id )
                    .Include(empresa => empresa.EmpresaContatos)
                    .FirstAsync();
            }
        }


    }

}
