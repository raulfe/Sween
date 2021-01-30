using Sween.Core.CustomEntities;
using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface IUserService
    {
        Task InsertUser(User user);
        Task<User> GetUserByCredentials(string nick, string password);
        Task<User> GetUser(int id);
        Task<bool> PutUser(UserDTO user);
        Task<bool> DeleteUser(int id);
        PageList<User> GetUsers(UserQueryFilter filter);
    }
}