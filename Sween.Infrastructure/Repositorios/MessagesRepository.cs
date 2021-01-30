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
    public class MessagesRepository : IMessagesRepository
    {
        private readonly SweenContext _context;

        public MessagesRepository(SweenContext context)
        {
            _context = context;
        }
        public async  Task<IEnumerable<Messages>> GetMessages(int id)
        {
            var message = await _context.Messages.Where(x => x.IdUser == id).ToListAsync(); ;

            return message;
        }

        public async Task<IEnumerable<Messages>> GetMessagesByUser(int iduser, int idmessage)
        {
            var ms = await _context.Messages.Where(x => x.IdUser == iduser && x.IdMessage == idmessage).ToListAsync();
            return ms;
        }

        public async Task<Messages> GetMessage(int iduser, int idmessage)
        {
            Messages ms = await _context.Messages.Where(x => x.IdUser == iduser && x.IdMessage == idmessage).FirstOrDefaultAsync();
            return ms;
        }

        

        public async Task InsertMessages(int id,MessageDTO ms)
        {
            Messages mg = new Messages()
            {
                IdMessage = ms.IdMessage,
                IdUser = id,
                Date = ms.Date,
                Contain = ms.Contain,
                Reaction = ms.Reaction,
                Type = ms.Type,
                View = ms.View
            }; 
            _context.Messages.Add(mg);

            await _context.SaveChangesAsync();
        }

        


        public async Task<bool> DeleteMessage(int iduser ,int idmessage)
        {
            var currentdata = await GetMessage(iduser, idmessage);
            _context.Messages.Remove(currentdata);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;


        }
        
    }
}
