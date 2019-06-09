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
        public async Task<List<GroupDto>> GetAllGroupAsync()
        {
            return GroupConverter.Convert(await _groupRepo.GetAllAsync());
        }

        public async Task<GroupDto> GetGroupByIdAsync(Guid id)
        {
            GroupDto group = GroupConverter.Convert(await _groupRepo.GetByIdAsync(id));
            group.CourseName = _courseRepo.GetByIdAsync(group.CourseId).Result.Name;
            group.Participant = ParticipantConverter.Convert(await _participantRepo.GetByGroupIdAsync(id));
            return group;
        }

        public async Task<List<GroupDto>> GetGroupByCourseIdAsync(Guid id)
        {
            return GroupConverter.Convert(await _groupRepo.GetByCourseIdAsync(id));
        }

        public async Task<GroupDto> CreateGroupAsync(GroupDto item)
        {
            return GroupConverter.Convert(await _groupRepo.CreateAsync(GroupConverter.Convert(item)));
        }

        public async Task<bool> UpdateGroupAsync(GroupDto item)
        {
            return await _groupRepo.UpdateAsync(GroupConverter.Convert(item));
        }

        public async Task<bool> DeleteGroupAsync(Guid id)
        {
            return await _groupRepo.DeleteAsync(id);
        }
    }
}
