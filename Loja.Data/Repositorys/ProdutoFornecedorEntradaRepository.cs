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
    public class ProdutoFornecedorEntradaRepository : RepositoryBase<ProdutoFornecedorEntrada>, IProdutoFornecedorEntradaRepository
    {

        public async Task<IEnumerable<object>> GetAllProdutoFornecedorEntrada(int empresaId)
        {
            using (var loja = new LojaContext())
            {
                return await (from p in loja.ProdutoFornecedorEntradas
                              join f in loja.Fornecedor on p.FornecedorId equals f.FornecedorId
                              where p.Ativo == true && f.Ativo == true
                              && p.EmpresaId == empresaId
                              group p by new { p.NotaFiscalId, f.NomeFornecedor,f.FornecedorId, p.DataEmissao, p.DataVencimento ,f.ImagemCliente} into pf
                              select new
                              {
                                  pf.Key.NomeFornecedor,
                                  Notafiscal = pf.Key.NotaFiscalId,
                                  Total = pf.Sum(entrada => entrada.ValorUnitario * entrada.QuantidadeEntrada),
                                  pf.Key.DataEmissao,
                                  pf.Key.DataVencimento,
                                  pf.Key.FornecedorId,
                                  pf.Key.ImagemCliente
                              }
                    ).ToListAsync();
            }

        }

        public new async Task<List<ProdutoFornecedorEntrada>> GetAll(Func<ProdutoFornecedorEntrada, bool> predicate)
        {
            using (var loja = new LojaContext())
            {
                return await Task.Factory.StartNew(() =>
                    (from pfe in loja.ProdutoFornecedorEntradas.Where(predicate)
                     join f in loja.Fornecedor on pfe.FornecedorId equals f.FornecedorId
                     join p in loja.Produto on pfe.ProdutoId equals p.ProdutoId
                     select new ProdutoFornecedorEntrada(pfe.ProdutoEntradaId, p.ProdutoId, f.FornecedorId,
                         pfe.EmpresaId, pfe.NotaFiscalId, pfe.QuantidadeEntrada, pfe.ValorUnitario, pfe.DataEntrada,
                         pfe.DataEmissao, pfe.DataVencimento, pfe.Ativo, null,
                         new Fornecedor(f.FornecedorId, f.NomeFornecedor, f.Cnpj, f.InscricaoEstadual,
                             f.Endereco, f.Numero, f.Estado, f.Cidade, f.ImagemCliente, f.Ativo),
                         new Produto(p.ProdutoId, p.ProdutoTipoId, p.EmpresaId, p.CodigoReferencia, p.NomeProduto, p.DataCastro, p.ImagemCliente, p.Ativo))

                    ).ToList()
                    );



            }
        }
    }


}
