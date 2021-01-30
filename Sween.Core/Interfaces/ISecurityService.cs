using Sween.Core.Entities;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}