using TrincaChurras.Core.Entities;

namespace TrincaChurras.Infra.Security
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
