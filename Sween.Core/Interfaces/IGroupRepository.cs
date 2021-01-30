using Sween.Core.DTOs;
using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface IGroupRepository
    {
        Task<Groups> GetGroup(int id);
        Task InsertGroup(GroupDTO gr);
        Task<bool> DeleteGroup(int id);
    }
}
