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
        public async Task<List<AdministrationDto>> GetAllAdministrationAsync()
        {
            return AdministrationConverter.Convert(await _adminRepo.GetAllAsync());
        }

        public async Task<AdministrationDto> GetAdministrationByIdAsync(Guid userId, Guid directionId)
        {
            AdministrationDto admin = AdministrationConverter.Convert(await _adminRepo.GetByIdAsync(userId, directionId));
            admin.DirectionName = _directionRepo.GetByIdAsync(admin.DirectionId).Result.Name;
            admin.RoleName = _adminRoleRepo.GetByIdAsync(admin.AdministrationRoleId).Result.Name;
            admin.UserName = _userRepo.GetByIdAsync(admin.UserId).Result.Name;
            return admin;
        }

        public async Task<List<AdministrationDto>> GetAdministrationByDirectionIdAsync(Guid id)
        {
            return AdministrationConverter.Convert(await _adminRepo.GetByDirectionIdAsync(id));
        }

        public async Task<List<AdministrationDto>> GetAdministrationByUserIdAsync(Guid id)
        {
            return AdministrationConverter.Convert(await _adminRepo.GetByUserIdAsync(id));
        }
        public async Task<List<AdministrationDto>> GetAdministrationByRoleIdAsync(Guid id)
        {
            return AdministrationConverter.Convert(await _adminRepo.GetByRoleIdAsync(id));
        }

        public async Task<AdministrationDto> CreateAdministrationAsync(AdministrationDto item)
        {
            return AdministrationConverter.Convert(await _adminRepo.CreateAsync(AdministrationConverter.Convert(item)));
        }

        public async Task<bool> UpdateAdministrationAsync(AdministrationDto item)
        {
            return await _adminRepo.UpdateAsync(AdministrationConverter.Convert(item));
        }

        public async Task<bool> DeleteAdministrationAsync(Guid userId, Guid directionId)
        {
            return await _adminRepo.DeleteAsync(userId, directionId);
        }
    }
}
