using System.Threading.Tasks;
using api.Core;

namespace api.Persistence
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
