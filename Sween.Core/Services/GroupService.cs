using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Core.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitofWork;
        public GroupService(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<bool> DeleteGroup(int id)
        {
            return await _unitofWork.GroupRepository.DeleteGroup(id);
        }

        public async Task<Groups> GetGroup(int id)
        {
            return await _unitofWork.GroupRepository.GetGroup(id);
        }

        public async Task InsertGroup(GroupDTO gr)
        {
            await _unitofWork.GroupRepository.InsertGroup(gr);
        }
    }
}
