using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get;  }
        IMessagesRepository MessageRepository { get;  }
        IGroupRepository GroupRepository { get;  }
        ISecurityRepository SecurityRepository { get;  }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
