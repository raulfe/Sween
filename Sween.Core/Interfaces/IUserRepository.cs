using Sween.Core.DTOs;
using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByCredentials(string nick, string password);
        Task InsertUser(User user);
        Task<User> GetUser(int id);
        Task<bool> PutUser(UserDTO user);
        Task<bool> DeleteUser(int id);
        IEnumerable<User> GetUsers();
    }
}
