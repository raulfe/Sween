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
    public class GroupRepository : IGroupRepository
    {

        private readonly SweenContext _context;
        public GroupRepository(SweenContext context)
        {
            _context = context;
        }

        public async Task<Groups> GetGroup(int id)
        {
            var message = await _context.Groups.Where(x => x.IdGroup == id).FirstOrDefaultAsync();

            return message;
        }

        public async Task InsertGroup(GroupDTO gr)
        {
            Groups t = new Groups()
            {
                IdGroup = gr.IdGroup,
                Date = gr.Date,
                NameGroup = gr.NameGroup
            };
            _context.Groups.Add(t);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteGroup(int id)
        {
            var currentdata = await GetGroup(id);
            _context.Groups.Remove(currentdata);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;


        }
    }
}
