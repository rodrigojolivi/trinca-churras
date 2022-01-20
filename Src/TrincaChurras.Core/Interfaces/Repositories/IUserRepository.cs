using TrincaChurras.Core.Entities;

namespace TrincaChurras.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User FindUser(string email, string password);
    }
}
