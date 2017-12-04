using System.Threading.Tasks;
using Tsp.Core.Models;
using System.Collections.Generic;

namespace Tsp.Core
{
    public interface IRec_assRepository
    {
        // Task<ContaCorrente> GetContaCorrente(int id);
        void Add(RelatorioRec_ass relatorioRec_ass);
        Task<List<RelatorioRec_ass>> GetRec_assGrid();
        Task<List<Rec_assGrafico>> GetRec_assGraficoUF();
        // void Remove(ContaCorrente contacorrente);


    }
}