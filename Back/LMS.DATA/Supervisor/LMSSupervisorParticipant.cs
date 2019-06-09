using LMS.DATA.Converters;
using LMS.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Supervisor
{
    public partial class LMSSupervisor
    {
        public async Task<List<ParticipantDto>> GetAllParticipantAsync()
        {
            return ParticipantConverter.Convert(await _participantRepo.GetAllAsync());
        }

        public async Task<ParticipantDto> GetParticipantByIdAsync(Guid userId, Guid groupId)
        {
            ParticipantDto participant = ParticipantConverter.Convert(await _participantRepo.GetByIdAsync(userId, groupId));
            participant.GroupName = _groupRepo.GetByIdAsync(participant.GroupId).Result.Name;
            participant.RoleName = _participantRoleRepo.GetByIdAsync(participant.ParticipantRoleId).Result.Name;
            participant.UserName = _userRepo.GetByIdAsync(participant.UserId).Result.Name;
            return participant;
        }

        public async Task<List<ParticipantDto>> GetParticipantByGroupIdAsync(Guid id)
        {
            return ParticipantConverter.Convert(await _participantRepo.GetByGroupIdAsync(id));
        }

        public async Task<List<ParticipantDto>> GetParticipantByUserIdAsync(Guid id)
        {
            return ParticipantConverter.Convert(await _participantRepo.GetByUserIdAsync(id));
        }
        public async Task<List<ParticipantDto>> GetParticipantByRoleIdAsync(Guid id)
        {
            return ParticipantConverter.Convert(await _participantRepo.GetByRoleIdAsync(id));
        }

        public async Task<ParticipantDto> CreateParticipantAsync(ParticipantDto item)
        {
            return ParticipantConverter.Convert(await _participantRepo.CreateAsync(ParticipantConverter.Convert(item)));
        }

        public async Task<bool> UpdateParticipantAsync(ParticipantDto item)
        {
            return await _participantRepo.UpdateAsync(ParticipantConverter.Convert(item));
        }

        public async Task<bool> DeleteParticipantAsync(Guid userId, Guid groupId)
        {
            return await _participantRepo.DeleteAsync(userId, groupId);
        }
    }
}
