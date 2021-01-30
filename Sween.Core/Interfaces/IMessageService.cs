using Sween.Core.DTOs;
using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<Messages>> GetMessages(int id);
        Task InsertMessages(int id, MessageDTO ms);
        Task<Messages> GetMessage(int iduser, int idmessage);
        Task<bool> DeleteMessage(int iduser, int idmessage);
        Task<IEnumerable<Messages>> GetMessagesByUser(int iduser, int idmessage);
    }
}
