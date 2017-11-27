using api.Core;
using api.Core.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api.Persistence
{
    public class BancoRepository : IBancoRepository
    {
        private readonly EdgeDbContext context;
        public BancoRepository(EdgeDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Banco>> GetList()
        {
            return await context.Bancos
                    .OrderBy(b => b.Nome)
                    .ToListAsync();
        }
    }
}
