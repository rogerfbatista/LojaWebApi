
using System;
using System.Collections.Generic;
using System.Linq;
using Loja.Domain.Interfaces.Repositorys;

namespace Loja.Data.Strategy.Resolver
{
    public class ProdutoClienteSaidaResolver: IProdutoClienteSaidaResolver
    {
        private readonly IEnumerable<IProdutoClienteSaidaRepository> _produtoClienteSaidaRepositories;

        public ProdutoClienteSaidaResolver(IEnumerable<IProdutoClienteSaidaRepository> produtoClienteSaidaRepositories)
        {
            _produtoClienteSaidaRepositories = produtoClienteSaidaRepositories;
        }

        public IProdutoClienteSaidaRepository ResolveRepository(string name)
        {
            IProdutoClienteSaidaRepository clienteMethod = _produtoClienteSaidaRepositories.FirstOrDefault(method => method.NameMethod == name);

            if (clienteMethod == null)
            {
                throw new ArgumentException("not found", name);
            }

            return clienteMethod;
        }
    }
}
