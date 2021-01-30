using Microsoft.EntityFrameworkCore;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using Sween.Infrastructure.Data;
using System.Threading.Tasks;

namespace Sween.Infrastructure.Repositorios
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly SweenContext _context;
        public SecurityRepository(SweenContext context)
        {
            _context = context;
        }

        public async Task<Security> GetLoginByCredential(UserLogin login)
        {
            return await _context.Securities.FirstOrDefaultAsync(x => x.User == login.User && x.Password == login.Password);
        }

        public async Task Add(Security security)
        {
            _context.Securities.Add(security);

            await _context.SaveChangesAsync();
        }
    }
}
