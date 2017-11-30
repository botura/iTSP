using System.Threading.Tasks;
using api.Core.Models;
using System.Collections.Generic;

namespace api.Core
{
    public interface IRec_assRepository
    {
        // Task<ContaCorrente> GetContaCorrente(int id);
        void Add(RelatorioRec_ass relatorioRec_ass);
        Task<List<RelatorioRec_ass>> GetRec_assGrid();
        // void Remove(ContaCorrente contacorrente);

    }
}