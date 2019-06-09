using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Repositories
{
    public interface IGroupRepository: IDisposable
    {
        Task<List<Group>> GetAllAsync();
        Task<Group> GetByIdAsync(Guid id);
        Task<List<Group>> GetByCourseIdAsync(Guid id);
        Task<Group> CreateAsync(Group item);
        Task<bool> UpdateAsync(Group item);
        Task<bool> DeleteAsync(Guid id);
    }
}
