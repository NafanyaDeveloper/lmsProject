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
        public async Task<List<UserDto>> GetAllUserAsync()
        {
            return UserConverter.Convert(await _userRepo.GetAllAsync());
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            UserDto user = UserConverter.Convert(await _userRepo.GetByIdAsync(id));
            user.Administration = AdministrationConverter.Convert(await _adminRepo.GetByUserIdAsync(id));
            user.Participant = ParticipantConverter.Convert(await _participantRepo.GetByUserIdAsync(id));
            return user;
        }

        public async Task<UserDto> CreateUserAsync(UserDto item)
        {
            return UserConverter.Convert(await _userRepo.CreateAsync(UserConverter.Convert(item), item.Password));
        }

        public async Task<bool> UpdateUserAsync(UserDto item)
        {
            return await _userRepo.UpdateAsync(UserConverter.Convert(item));
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            return await _userRepo.DeleteAsync(id);
        }
    }
}
