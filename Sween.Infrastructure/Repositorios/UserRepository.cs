using Microsoft.EntityFrameworkCore;
using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using Sween.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Infrastructure.Repositorios
{
    public class UserRepository : IUserRepository
    {
        private readonly SweenContext _context;
        public UserRepository(SweenContext context)
        {
            _context= context;
        }
        public async Task<bool> DeleteUser(int id)
        {
            var currentdata = await GetUser(id);
            _context.User.Remove(currentdata);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;


        }

        public async Task<User> GetUserByCredentials(string nick, string password)
        {
            User data = await _context.User.Where(x => x.Nick == nick && x.Password == password).FirstOrDefaultAsync();

            return data;
        }

        public async Task InsertUser(User user)
        {
            _context.User.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(int id)
        {
            User data = await _context.User.FirstOrDefaultAsync(x => x.IdUser == id);
            return data;
        }

        public  IEnumerable<User> GetUsers()
        {
            var data =  _context.User.ToList(); 
            return data;
        }

        public async Task<bool> PutUser(UserDTO user)
        {
            var currentdata = await GetUser(user.IdUser);
            currentdata.IdUser = user.IdUser;
            currentdata.Name = user.Name;
            currentdata.LastName = user.LastName;
            currentdata.Email = user.Email;
            currentdata.Birthday = user.Birthday;
            currentdata.Activo = user.Activo;
            currentdata.ImageURL = user.ImageURL;
            currentdata.Nick = user.Nick;
            currentdata.Password = user.Password;
            currentdata.Tel = user.Tel;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;


        }

    }
}
