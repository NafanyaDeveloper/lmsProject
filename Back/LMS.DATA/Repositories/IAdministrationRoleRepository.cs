using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Repositories
{
    public interface IAdministrationRoleRepository: IDisposable
    {
        Task<List<AdministrationRole>> GetAllAsync();
        Task<AdministrationRole> GetByIdAsync(Guid id);
        Task<AdministrationRole> CreateAsync(AdministrationRole item);
        Task<bool> UpdateAsync(AdministrationRole item);
        Task<bool> DeleteAsync(Guid id);
    }
}
