using Microsoft.EntityFrameworkCore;
using Tsp.Core.Models;

namespace Tsp.Persistence
{
    public class TspDbContext : DbContext
    {
        public DbSet<RelatorioRec_ass> Rec_ass { get; set; }

        public TspDbContext(DbContextOptions<TspDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       

        }
    }
}
