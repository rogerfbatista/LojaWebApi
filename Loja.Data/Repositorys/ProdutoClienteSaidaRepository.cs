using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Loja.Data.Contexto;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;

namespace Loja.Data.Repositorys
{
    public class ProdutoClienteSaidaRepository : RepositoryBase<ProdutoClienteSaida>, IProdutoClienteSaidaRepository
    {
        public new async Task<ProdutoClienteSaida> GetById(int id)
        {
            using (var loja = new LojaContext())
            {
                return await loja.ProdutoClienteSaidas
                    .Include(saida => saida.ProdutoClienteSaidaItems)
                    .Where(saida => saida.ProdutoClienteSaidaId == id && saida.Ativo == true).FirstOrDefaultAsync();
            }
        }


        public async Task<IEnumerable<object>> GetAllProdutoClienteSaida(int empresaId)
        {

            using (var loja = new LojaContext())
            {

                return await (from p in loja.ProdutoClienteSaidas
                              join c in loja.Cliente on p.ClienteId equals c.ClienteId
                              where p.EmpresaId == empresaId
                              select new
                              {
                                  p.ProdutoClienteSaidaId,
                                  p.ValorTotal,
                                  p.DataVenda,
                                  c.ClienteId,
                                  c.ImagemCliente,
                                  c.NomeCliente,
                                  p.Ativo

                              }


                    ).ToListAsync();

            }




        }


        public async Task<ProdutoClienteSaida> GetProdutoClienteSaida(int numeroPedido, int empresaId)
        {
            using (var loja = new LojaContext())
            {
                return await loja.ProdutoClienteSaidas.Include(saida => saida.Cliente)
                    .Include(saida => saida.ProdutoFormasDePagamento)
                    .Include(saida => saida.ProdutoClienteSaidaItems.Select(item => item.Produto))
                    .FirstOrDefaultAsync(saida => saida.ProdutoClienteSaidaId == numeroPedido && saida.EmpresaId == empresaId);

            }




        }


        public async Task<IEnumerable<object>> GetProdutoClienteSaidaPagination(int pageNumber, int pageSize,
            System.Func<ProdutoClienteSaida, int> orderByFunc, System.Func<ProdutoClienteSaida, bool> countFunc,
           int empresaId)
        {
            using (var loja = new LojaContext())
            {


                var recordsTotal = loja.ProdutoClienteSaidas.Count(countFunc);

               
                var list = (from p in loja.ProdutoClienteSaidas
                            join c in loja.Cliente on p.ClienteId equals c.ClienteId
                           select new
                              {
                                  p.ProdutoClienteSaidaId,
                                  p.ValorTotal,
                                  p.DataVenda,
                                  c.ClienteId,
                                  c.ImagemCliente,
                                  c.NomeCliente,
                                  p.Ativo,
                                  p.EmpresaId

                              })
                     .OrderBy(arg => arg.ProdutoClienteSaidaId)
                     .Skip(pageSize * (pageNumber - 1))
                     .Take(pageSize)
                     .Where(arg => arg.EmpresaId == empresaId)
                     .ToList();


                var lista = new List<object>
                {
                    new
                    {
                        recordsTotal,
                        list
                    }
                };

                return await Task.Factory.StartNew(() => lista);

            }
        }
    }

}
