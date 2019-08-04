using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Loja.Data.Contexto;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;

namespace Loja.Data.Repositorys
{
    public class ProdutoEstoqueRepository : RepositoryBase<ProdutoEstoque>, IProdutoEstoqueRepository
    {
        public async Task<ProdutoEstoque> GetProdutoEstoque(Func<ProdutoEstoque, bool> predicate)
        {
            using (var loja = new LojaContext())
            {
                return await Task.Factory.StartNew(() => loja.ProdutoEstoques.Where(predicate).FirstOrDefault());
            }
        }

        public async Task<List<ProdutoEstoque>> GetProdutoEstoque(string val, int empresaId)
        {
            using (var loja = new LojaContext())
            {
                return await loja.ProdutoEstoques
                    .Where(estoque => estoque.EmpresaId == empresaId
                     && estoque.Ativo == true
                     && estoque.Produto.NomeProduto.ToLower().Contains(val.ToLower()))
                  .Include(estoque => estoque.Produto)
                  .ToListAsync();
            }
        }

        public new async Task<List<ProdutoEstoque>> GetAll(Func<ProdutoEstoque, bool> predicate)
        {
            using (var loja = new LojaContext())
            {

                return await Task.Factory.StartNew(() => loja.ProdutoEstoques.
                    Include(estoque => estoque.Produto).Where(predicate).ToList());

            }
        }

        public async Task<object> GetByIdProdutoEstoque(int id, int empresaId)
        {
            using (var loja = new LojaContext())
            {
                return await (from e in loja.ProdutoEstoques
                              let QuantidadeVendida = loja.ProdutoClienteSaidaItems.Where(saida => saida.ProdutoId == e.ProdutoId && saida.Ativo == true).Sum(saida => saida.QuantidadeSaida)
                              let QuantidadeEntrada = loja.ProdutoFornecedorEntradas.Where(entrada => entrada.ProdutoId == e.ProdutoId && entrada.Ativo == true).Sum(entrada => entrada.QuantidadeEntrada)
                              join p in loja.Produto on e.ProdutoId equals p.ProdutoId
                              where e.ProdutoEstoqueId == id && e.EmpresaId == empresaId && e.Ativo == true
                              select new
                              {
                                  QuantidadeVendida,
                                  QuantidadeEntrada,
                                  e.QuantidadeEstoque,
                                  e.ValorVenda,
                                  p.ImagemCliente,
                                  p.NomeProduto
                              }

                    ).FirstOrDefaultAsync();


            }

            return null;
        }
    }


}
