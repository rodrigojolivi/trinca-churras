using System.Threading.Tasks;
using TrincaChurras.Core.Interfaces.Repositories;
using TrincaChurras.Infra.Contexts;

namespace TrincaChurras.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TrincaChurrasContext _context;

        public UnitOfWork(TrincaChurrasContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
