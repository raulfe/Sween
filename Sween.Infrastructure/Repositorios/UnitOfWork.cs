using Sween.Core.Interfaces;
using Sween.Infrastructure.Data;
using System.Threading.Tasks;

namespace Sween.Infrastructure.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly SweenContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IMessagesRepository _messageRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly ISecurityRepository _securityRepository;
        public UnitOfWork(SweenContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);
        public IMessagesRepository MessageRepository => _messageRepository ?? new MessagesRepository(_context);
        public IGroupRepository GroupRepository => _groupRepository ?? new GroupRepository(_context);
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }   
}
