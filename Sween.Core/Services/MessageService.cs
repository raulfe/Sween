using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Core.Services
{
    public class MessageService : IMessageService

    {
        private readonly IUnitOfWork _unitofWork;
        public MessageService(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<bool> DeleteMessage(int iduser, int idmessage)
        {
            return await _unitofWork.MessageRepository.DeleteMessage(iduser, idmessage);
        }

        public async Task<Messages> GetMessage(int iduser, int idmessage)
        {
            return await _unitofWork.MessageRepository.GetMessage(iduser, idmessage);
        }

        public async Task<IEnumerable<Messages>> GetMessages(int id)
        {
            return await _unitofWork.MessageRepository.GetMessages(id);
        }

        public async Task<IEnumerable<Messages>> GetMessagesByUser(int iduser, int idmessage)
        {
            return await _unitofWork.MessageRepository.GetMessagesByUser(iduser, idmessage);
        }

        public async Task InsertMessages(int id, MessageDTO ms)
        {
            await _unitofWork.MessageRepository.InsertMessages(id, ms);
        }
    }
}
