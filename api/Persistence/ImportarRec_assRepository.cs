using api.Core;
using api.Core.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api.Persistence
{
    public class ImportarRec_assRepository : IImportarRec_assRepository
    {
        private readonly TspDbContext context;
        public ImportarRec_assRepository(TspDbContext context)
        {
            this.context = context;
        }

        public void Add(RelatorioRec_ass relatorioRec_ass)
        {
            context.RelatorioRec_ass.Add(relatorioRec_ass);
        }

    }
}
