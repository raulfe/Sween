using Sween.Core.Entities;
using Sween.Core.Interfaces;
using System.Threading.Tasks;

namespace Sween.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitofWork;
        public SecurityService(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }



        public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _unitofWork.SecurityRepository.GetLoginByCredential(userLogin);
        }

        public async Task RegisterUser(Security security)
        {
            await _unitofWork.SecurityRepository.Add(security);
        }
    }

}
