using api.Core;
using api.Core.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api.Persistence
{
    public class Rec_assRepository : IRec_assRepository
    {
        private readonly TspDbContext context;
        public Rec_assRepository(TspDbContext context)
        {
            this.context = context;
        }

        public void Add(RelatorioRec_ass relatorioRec_ass)
        {
            context.Rec_ass.Add(relatorioRec_ass);
        }

        public async Task<List<RelatorioRec_ass>> GetRec_assGrid()
        {
            return await context.Rec_ass
                .OrderBy(r => r.nomeArquivo)
                .ThenBy(r => r.linhaArquivo)
                .ToListAsync();
        }

    }
}
