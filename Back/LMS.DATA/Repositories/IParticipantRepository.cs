using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Repositories
{
    public interface IParticipantRepository : IDisposable
    {
        Task<List<Participant>> GetAllAsync();
        Task<Participant> GetByIdAsync(Guid userId, Guid groupId);
        Task<List<Participant>> GetByUserIdAsync(Guid id);
        Task<List<Participant>> GetByGroupIdAsync(Guid id);
        Task<List<Participant>> GetByRoleIdAsync(Guid id);
        Task<Participant> CreateAsync(Participant item);
        Task<bool> UpdateAsync(Participant item);
        Task<bool> DeleteAsync(Guid userId, Guid groupId);
    }
}
