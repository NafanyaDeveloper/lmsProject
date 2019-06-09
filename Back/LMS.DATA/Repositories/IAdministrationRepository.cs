using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Repositories
{
    public interface IAdministrationRepository: IDisposable
    {
        Task<List<Administration>> GetAllAsync();
        Task<Administration> GetByIdAsync(Guid userId, Guid directionId);
        Task<List<Administration>> GetByUserIdAsync(Guid id);
        Task<List<Administration>> GetByDirectionIdAsync(Guid id);
        Task<List<Administration>> GetByRoleIdAsync(Guid id);
        Task<Administration> CreateAsync(Administration item);
        Task<bool> UpdateAsync(Administration item);
        Task<bool> DeleteAsync(Guid userId, Guid directionId);
    }
}
