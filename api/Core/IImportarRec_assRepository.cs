using System.Threading.Tasks;
using api.Core.Models;
using System.Collections.Generic;

namespace api.Core
{
    public interface IImportarRec_assRepository
    {
        // Task<ContaCorrente> GetContaCorrente(int id);
        void Add(RelatorioRec_ass relatorioRec_ass);
        // Task<List<ContaCorrente>> GetContaCorrenteGrid();
        // void Remove(ContaCorrente contacorrente);

    }
}