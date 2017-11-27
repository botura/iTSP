using api.Core;
using api.Core.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api.Persistence
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly EdgeDbContext context;
        public ContaCorrenteRepository(EdgeDbContext context)
        {
            this.context = context;
        }

        public async Task<ContaCorrente> GetContaCorrente(int id)
        {
            return await context.ContaCorrentes
            .Include(b => b.Banco)
            .SingleOrDefaultAsync(c => c.Id == id);
        }

        public void Add(ContaCorrente contacorrente)
        {
            context.ContaCorrentes.Add(contacorrente);
        }

        public async Task<List<ContaCorrente>> GetContaCorrenteGrid()
        {
            // return await context.ContaCorrentes.FromSql("SELECT c.ContaCorrenteID, c.Apelido, c.Ativa, c.NumeroAgencia, c.NumeroConta, b.BancoID, b.Nome, b.NumeroFebraban FROM contacorrente as c inner join banco as b on c.BancoID = b.BancoID")
            return await context.ContaCorrentes
                .Include(b => b.Banco)
                .OrderByDescending(c => c.Ativa)
                .ThenBy(c => c.Apelido)
                .ToListAsync();
        }

        public void Remove(ContaCorrente contacorrente)
        {
            context.Remove(contacorrente);
        }

    }
}
