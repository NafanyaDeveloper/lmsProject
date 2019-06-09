using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Supervisor
{
    public partial class LMSSupervisor
    {
        public async Task<List<ParticipantRole>> GetAllParticipantRoleAsync()
        {
            return await _participantRoleRepo.GetAllAsync();
        }

        public async Task<ParticipantRole> GetParticipantRoleByIdAsync(Guid id)
        {
            ParticipantRole pRole = await _participantRoleRepo.GetByIdAsync(id);
            pRole.Participants = await _participantRepo.GetByRoleIdAsync(id);
            return pRole;
        }

        public async Task<ParticipantRole> CreateParticipantRoleAsync(ParticipantRole item)
        {
            return await _participantRoleRepo.CreateAsync(item);
        }

        public async Task<bool> UpdateParticipantRoleAsync(ParticipantRole item)
        {
            return await _participantRoleRepo.UpdateAsync(item);
        }

        public async Task<bool> DeleteParticipantRoleAsync(Guid id)
        {
            return await _participantRoleRepo.DeleteAsync(id);
        }
    }
}
