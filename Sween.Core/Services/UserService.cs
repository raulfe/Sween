using Microsoft.Extensions.Options;
using Sween.Core.CustomEntities;
using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using Sween.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace Sween.Core.Services
{
    public class UserService : IUserService
    {
        
        private readonly IUnitOfWork _unitofWork;
        private readonly PaginationOptions _paginationOptions;
        public UserService(IUnitOfWork unitofWork, IOptions<PaginationOptions> options)
        {
            _unitofWork = unitofWork;
            _paginationOptions = options.Value;
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _unitofWork.UserRepository.DeleteUser(id);
        }

        public async Task<User> GetUser(int id)
        {
            return await _unitofWork.UserRepository.GetUser(id);
        }

        public async Task<User> GetUserByCredentials(string nick, string password)
        {
            return await _unitofWork.UserRepository.GetUserByCredentials(nick, password);
        }

        public   PageList<User> GetUsers(UserQueryFilter filter)
        {

            filter.PageNumber = filter.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filter.PageNumber; 
            filter.PageSize = filter.PageSize == 0 ? _paginationOptions.DefaultPageSize : filter.PageSize; 
            var data =  _unitofWork.UserRepository.GetUsers();
            if(filter.UserId !=null)
            {
                data = data.Where(x => x.IdUser == filter.UserId);
            }
            if(filter.Name != null)
            {
                data = data.Where(x => x.Name == filter.Name);
            }


            var userPage = PageList<User>.Create(data, filter.PageNumber, filter.PageSize);
            return userPage;

        }

        public async Task InsertUser(User user)
        {
            await _unitofWork.UserRepository.InsertUser(user);
        }

        public async Task<bool> PutUser(UserDTO user)
        {
            return await _unitofWork.UserRepository.PutUser(user);
        }
    }
}
