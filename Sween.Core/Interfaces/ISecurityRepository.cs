using Sween.Core.Entities;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface ISecurityRepository
    {
        Task<Security> GetLoginByCredential(UserLogin login);
        Task Add(Security security);
    }
}