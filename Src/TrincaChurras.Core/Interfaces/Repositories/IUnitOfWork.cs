using System.Threading.Tasks;

namespace TrincaChurras.Core.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
