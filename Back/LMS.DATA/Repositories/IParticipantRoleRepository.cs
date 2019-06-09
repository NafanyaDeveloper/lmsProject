using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Repositories
{
    public interface IParticipantRoleRepository: IDisposable
    {
        Task<List<ParticipantRole>> GetAllAsync();
        Task<ParticipantRole> GetByIdAsync(Guid id);
        Task<ParticipantRole> CreateAsync(ParticipantRole item);
        Task<bool> UpdateAsync(ParticipantRole item);
        Task<bool> DeleteAsync(Guid id);
    }
}
