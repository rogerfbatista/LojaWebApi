using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Loja.Data.Contexto;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;

namespace Loja.Data.Strategy.Dal
{
    public class ProdutoClienteSaidaDal : DalBase, IProdutoClienteSaidaRepository
    {
        public ProdutoClienteSaidaDal()
        {
            NameMethod = "Dal";
        }
        public string NameMethod { get; private set; }

        public async Task<IEnumerable<object>> GetAllProdutoClienteSaida(int empresaId)
        {

            using (var loja = new LojaContext())
            {

                return await (from p in loja.ProdutoClienteSaidas
                              join pi in loja.ProdutoClienteSaidaItems on p.ProdutoClienteSaidaId equals pi.ProdutoClienteSaidaId
                              join c in loja.Cliente on p.ClienteId equals c.ClienteId
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


                    ).Distinct().ToListAsync();

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

        public Task Add(ProdutoClienteSaida obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Add(List<ProdutoClienteSaida> obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProdutoClienteSaida> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ProdutoClienteSaida>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ProdutoClienteSaida>> GetAll(System.Func<ProdutoClienteSaida, bool> predicate)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(ProdutoClienteSaida obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(List<ProdutoClienteSaida> obj)
        {
            throw new System.NotImplementedException();
        }

        public Task RemovePhysical(ProdutoClienteSaida obj)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveLogic(int id, ProdutoClienteSaida obj)
        {
            throw new System.NotImplementedException();
        }

        public new Task Dispose()
        {
            throw new System.NotImplementedException();
        }
    }

}
