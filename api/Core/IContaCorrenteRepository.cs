using System.Threading.Tasks;
using api.Core.Models;
using System.Collections.Generic;

namespace api.Core
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> GetContaCorrente(int id);
        void Add(ContaCorrente contacorrente);
        Task<List<ContaCorrente>> GetContaCorrenteGrid();
        void Remove(ContaCorrente contacorrente);

    }
}