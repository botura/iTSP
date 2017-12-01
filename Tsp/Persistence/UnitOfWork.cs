using System.Threading.Tasks;
using Tsp.Core;

namespace Tsp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TspDbContext context;

        public UnitOfWork(TspDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
