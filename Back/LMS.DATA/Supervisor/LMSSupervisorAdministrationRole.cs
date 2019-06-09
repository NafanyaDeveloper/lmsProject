using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Supervisor
{
    public partial class LMSSupervisor
    {
        public async Task<List<AdministrationRole>> GetAllAdministrationRoleAsync()
        {
            return await _adminRoleRepo.GetAllAsync();
        }

        public async Task<AdministrationRole> GetAdministrationRoleByIdAsync(Guid id)
        {
            AdministrationRole aRole = await _adminRoleRepo.GetByIdAsync(id);
            aRole.Administration = await _adminRepo.GetByRoleIdAsync(id);
            return aRole;
        }

        public async Task<AdministrationRole> CreateAdministrationRoleAsync(AdministrationRole item)
        {
            return await _adminRoleRepo.CreateAsync(item);
        }

        public async Task<bool> UpdateAdministrationRoleAsync(AdministrationRole item)
        {
            return await _adminRoleRepo.UpdateAsync(item);
        }

        public async Task<bool> DeleteAdministrationRoleAsync(Guid id)
        {
            return await _adminRoleRepo.DeleteAsync(id);
        }
    }
}
