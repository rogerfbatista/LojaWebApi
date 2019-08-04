using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class FornecedorService : ServiceBase<Fornecedor>, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
            : base(fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<List<Fornecedor>> GetAllFornecedor(int id)
        {
            return await _fornecedorRepository.GetAllFornecedor(id);
        }


        public async Task<List<Fornecedor>> GetForncedor(string val, int empresaId)
        {
            return await _fornecedorRepository.GetForncedor(val, empresaId);
        }
    }



}
